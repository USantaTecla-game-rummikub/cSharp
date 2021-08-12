using Rummy.models.interpreter.InputParser.Commands;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser
{
    /// <summary>
    /// Gramática:     
    ///     Command ::= END | UNDO | REDO | SAVE | LOAD | EXIT    
    ///     Command ::= PUT PutArgumentsList    
    ///     PutArgumentsList ::= Tiles TargetGroup restPutArgumentsList
    ///     restPutArgumentsList ::= "," PutArgumentsList
    ///     restPutArgumentsList ::= ""
    ///     
    ///     Command ::= MOV MovArgumentsList
    ///     MovArgumentsList ::= FROM Group Tiles TargetGroup restMovArgumentsList
    ///     restMoveArgumentsList ::= "," MovArgumentsList
    ///     restMoveArgumentsList ::= ""
    /// 
    ///     TargetGroup ::= ""
    ///     TargetGroup ::= IN Group
    ///     
    ///     Tiles ::= Tile RestTiles
    ///     RestTiles ::= " " Tiles
    ///     RestTiles ::= ""
    ///              
    ///     Tile ::= [1-13][R|G|B|Y] | J    
    ///     Group ::= [1-9]+
    /// 
    ///    Example: 
    ///       PUT 4R 5R 6R, 10R 10B 10G
    ///       
    ///        Command --> Name ExpressionList --> PUT ExpressionList --> PUT PutArgumentsList 
    /// </summary>
    public class CommandParser
    {
        private Input input;
        private Dictionary<string, Parser> commandNames;

        public CommandParser(Input input)
        {
            this.input = input;
            this.commandNames = new Dictionary<string, Parser>();
            this.commandNames.Add(CommandString.PUT, new PutArgumentsList(this.input));
            this.commandNames.Add(CommandString.MOV, new MovArgumentsList(this.input));
            this.commandNames.Add(CommandString.END, new NullArgument());
            this.commandNames.Add(CommandString.UNDO, new NullArgument());
            this.commandNames.Add(CommandString.REDO, new NullArgument());
            this.commandNames.Add(CommandString.RESUME, new NullArgument());
            this.commandNames.Add(CommandString.LOAD, new NullArgument());
            this.commandNames.Add(CommandString.SAVE, new NullArgument());
            this.commandNames.Add(CommandString.EXIT, new NullArgument());
        }

        public void parse()
        {
            this.input.jumpSpaces();            
            string token = "";
            while (!this.input.isEnd() && !this.commandNames.ContainsKey(token))
            {
                token += this.input.getToken();                 
            }
            if (this.commandNames.ContainsKey(token))
            {
                this.commandNames[token].parse();
            } else
            {
                this.input.generateError(ErrorMessage.COMMAND_NOT_RECOGNIZED);
            }
        }
    }
}
