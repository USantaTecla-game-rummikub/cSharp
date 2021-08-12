using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace Rummy.models.interpreter
{    
    public class CommandBuilder
    {
        private string input;        
        private string error;
        private Dictionary<string, Command> simpleCommands;        

        public CommandBuilder(string input) {
            this.simpleCommands = new Dictionary<string, Command>();
            this.input = input.ToUpper();            
            this.error = "";
            this.createCommandsTable();            
        }

        private void createCommandsTable()
        {
            this.simpleCommands.Add(CommandString.END, new EndCommand());
            this.simpleCommands.Add(CommandString.UNDO, new UndoCommand());
            this.simpleCommands.Add(CommandString.REDO, new RedoCommand());
            this.simpleCommands.Add(CommandString.SAVE, new SaveCommand());
            this.simpleCommands.Add(CommandString.LOAD, new LoadCommand());
            this.simpleCommands.Add(CommandString.RESUME, new ResumeCommand());
            this.simpleCommands.Add(CommandString.EXIT, new ExitCommand());
        }

        public Command create() {
            Command command = null;
            string[] tokens = this.input.Split(' ');            
            if (this.isInstructionSimple(tokens)) {
                command = this.simpleCommands[tokens[0]];
            } else {                
               string[] actionArguments = this.getActionArguments();
               string actionName = this.getActionName(actionArguments);
               switch (actionName.ToUpper()) {
                    case CommandString.PUT: 
                        command = this.createPut(actionArguments); break;
                    case CommandString.MOV: 
                        command = this.createMov(actionArguments); break;
                    default:
                        this.error = ErrorMessage.COMMAND_NOT_RECOGNIZED;
                        break;
               }               
            }
            return command;
        }

        public string getError()
        {
            return this.error;
        }

        public bool hasError()
        {
            return this.error != null && this.error != "";
        }

        private bool isInstructionSimple(string[] tokens) {
            return tokens.Length == 1 && tokens[0] != null;
        }

        private string[] getActionArguments() {
            return this.input.Split(',');
        }

        private string getActionName(string[] actionArguments) {
            return (actionArguments[0].Split(' '))[0];
        }
       
        private Command createPut(string[] argumentsGroups) {            
            List<PutIn> lstExpIn = new List<PutIn>();
            for (int i = 0; i < argumentsGroups.Length; i++) {                
                string[] tilesAndTargetGroup = argumentsGroups[i].Split(' ');
                string targetGroup = "";
                List<TileRack> tilesExp = null;
                if (this.hasSubcommandIn(tilesAndTargetGroup))
                {
                    targetGroup = tilesAndTargetGroup[tilesAndTargetGroup.Length - 1];
                    tilesExp = getRackTiles(tilesAndTargetGroup, 2);
                } else
                {
                    tilesExp = getRackTiles(tilesAndTargetGroup, 0);
                }                                
                Group tGroup = new Group(targetGroup);
                PutIn expIn = new PutIn(tilesExp, tGroup);                                    
                lstExpIn.Add(expIn);                                    
            }
            return new PutCommand(lstExpIn);            
        }

        private bool hasSubcommandIn(string[] tilesAndTargetGroup) {            
            return (tilesAndTargetGroup[tilesAndTargetGroup.Length - 2].ToUpper() == SubcommandString.IN);
        }

        private List<TileRack> getRackTiles(string[] tiles, int beforeEnd) {
            List<TileRack> tilesExp = new List<TileRack>();
            for (int i = 1; i < tiles.Length - beforeEnd; i++) {
                if (Regex.IsMatch(tiles[i], "[0-9]{1,2}[R|G|B|Y]") || Regex.IsMatch(tiles[i], "[J|j]"))
                {
                    tilesExp.Add(new TileRack(tiles[i]));
                } else
                {
                    this.error = ErrorMessage.SUBCOMMAND_IN_NOT_RECOGNIZED;
                    break;
                }
            }
            return tilesExp;
        }

        private List<TileGroup> getGroupTiles(string[] tiles, int indexStart, int indexEnd)
        {
            List<TileGroup> tilesExp = new List<TileGroup>();
            for (int i = indexStart; i <= indexEnd; i++)
            {
                tilesExp.Add(new TileGroup(tiles[i]));
            }
            return tilesExp;
        }

        private Command createMov(string[] argumentsGroups) {
            List<MovIn> lstExpFrom = new List<MovIn>();
            for (int i = 0; i < argumentsGroups.Length; i++) {
                string[] tilesAndOriginAndTarget = argumentsGroups[i].Split(' ');
                if (this.hasSubcommandFrom(tilesAndOriginAndTarget)) {                    
                    string originGroup = tilesAndOriginAndTarget[2];
                    string targetGroup = "";
                    List<TileGroup> tilesExp = null;
                    if (this.hasSubcommandIn(tilesAndOriginAndTarget))
                    {
                        targetGroup = tilesAndOriginAndTarget[tilesAndOriginAndTarget.Length - 1];
                        tilesExp = getGroupTiles(tilesAndOriginAndTarget, 3, tilesAndOriginAndTarget.Length - 3);
                    } else
                    {
                        tilesExp = getGroupTiles(tilesAndOriginAndTarget, 3, tilesAndOriginAndTarget.Length - 1);
                    }                    
                    Group tgroup = new Group(targetGroup);
                    Group ogroup = new Group(originGroup);
                    MovIn expIn = new MovIn(tilesExp, ogroup, tgroup);
                    lstExpFrom.Add(expIn);
                }
            }
            return new MovCommand(lstExpFrom);            
        }
      
        private bool hasSubcommandFrom(string[] tilesAndOriginAndTarget) {
            return (tilesAndOriginAndTarget[1].ToUpper() == SubcommandString.FROM);
        }
    }
}
