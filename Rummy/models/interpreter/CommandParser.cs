using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class CommandParser
    {
        private string input;
        private IPlayerCommand player;
        private string error;

        public CommandParser(string input, IPlayerCommand player) {
            this.input = input;
            this.player = player;
            this.error = "";
        }

        public void parse() {            
            string[] tokens = this.input.Split(' ');            
            if (this.isInstructionSimple(tokens)) {
                this.parseInstructionSimple(tokens[0]);
            } else {                
               string[] actionArguments = this.getActionArguments();
               string actionName = this.getActionNameInstructionCompound(actionArguments);
               switch (actionName.ToUpper()) {
                    case CommandString.PUT: 
                        this.parsePut(actionArguments); break;
                    case CommandString.MOV: 
                        this.parseMov(actionArguments); break;
                    default:
                        this.error = ErrorMessage.COMMAND_NOT_RECOGNIZED;
                        break;
               }               
            }
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

        private string getActionNameInstructionCompound(string[] actionArguments) {
            return (actionArguments[0].Split(' '))[0];
        }

        private void parseInstructionSimple(string instruction)
        {
            switch (instruction)
            {
                case CommandString.END: new ExpEnd().interpret(this.player);
                    break;
                case CommandString.HELP:
                    break;
                case CommandString.UNDO:
                    break;
                case CommandString.REDO:
                    break;
                case CommandString.RESUME:
                    break;
                case CommandString.EXIT:
                    break;
            }
        }

        private void parsePut(string[] argumentsGroups) {            
            List<ExpPutIn> lstExpIn = new List<ExpPutIn>();
            for (int i = 0; i < argumentsGroups.Length; i++) {                
                string[] tilesAndTargetGroup = argumentsGroups[i].Split(' ');
                string targetGroup = "";
                List<ExpTileRack> tilesExp = null;
                if (this.hasSubcommandIn(tilesAndTargetGroup))
                {
                    targetGroup = tilesAndTargetGroup[tilesAndTargetGroup.Length - 1];
                    tilesExp = getRackTiles(tilesAndTargetGroup, 2);
                } else
                {
                    tilesExp = getRackTiles(tilesAndTargetGroup, 0);
                }                                
                Group tGroup = new Group(targetGroup);
                ExpPutIn expIn = new ExpPutIn(tilesExp, tGroup);                                    
                lstExpIn.Add(expIn);                                    
            }
            ExpPut expPut = new ExpPut(lstExpIn);
            if (!this.hasError())
            {
                expPut.interpret(this.player);
                this.error = expPut.getError();
            }
        }

        private bool hasSubcommandIn(string[] tilesAndTargetGroup) {            
            return (tilesAndTargetGroup[tilesAndTargetGroup.Length - 2].ToUpper() == SubcommandString.IN);
        }

        private List<ExpTileRack> getRackTiles(string[] tiles, int beforeEnd) {
            List<ExpTileRack> tilesExp = new List<ExpTileRack>();
            for (int i = 1; i < tiles.Length - beforeEnd; i++) {
                if (Regex.IsMatch(tiles[i], "[0-9]{1,2}[R|G|B|Y]") || Regex.IsMatch(tiles[i], "[J|j]"))
                {
                    tilesExp.Add(new ExpTileRack(tiles[i]));
                } else
                {
                    this.error = ErrorMessage.SUBCOMMAND_IN_NOT_RECOGNIZED;
                    break;
                }
            }
            return tilesExp;
        }

        private List<ExpTileGroup> getGroupTiles(string[] tiles, int indexStart)
        {
            List<ExpTileGroup> tilesExp = new List<ExpTileGroup>();
            for (int i = indexStart; i < tiles.Length - 2; i++)
            {
                tilesExp.Add(new ExpTileGroup(tiles[i]));
            }
            return tilesExp;
        }

        private void parseMov(string[] argumentsGroups) {
            List<ExpMovIn> lstExpFrom = new List<ExpMovIn>();
            for (int i = 1; i < argumentsGroups.Length; i++) {
                string[] tilesAndOriginAndTarget = argumentsGroups[i].Split(' ');
                if (this.hasSubcommandFrom(tilesAndOriginAndTarget) && this.hasSubcommandIn(tilesAndOriginAndTarget)) {
                   string originGroup = tilesAndOriginAndTarget[1];
                   string targetGroup = tilesAndOriginAndTarget[tilesAndOriginAndTarget.Length - 1];
                    List<ExpTileGroup> tilesExp = getGroupTiles(tilesAndOriginAndTarget, 2);
                    Group tgroup = new Group(targetGroup);
                    Group ogroup = new Group(originGroup);
                    ExpMovIn expIn = new ExpMovIn(tilesExp, ogroup, tgroup);                            
                }
            }
            ExpMov expMov = new ExpMov(lstExpFrom);
            expMov.interpret(this.player);
        }

        private bool hasSubcommandFrom(string[] tilesAndOriginAndTarget) {
            return (tilesAndOriginAndTarget[0].ToUpper() == SubcommandString.FROM);
        }

        private bool hasError(Expression exp) {
            return exp.getError() != null && exp.getError() != "";
        }
    }
}
