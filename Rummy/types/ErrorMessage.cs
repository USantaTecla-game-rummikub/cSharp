using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.types
{
    public class ErrorMessage
    {
        public const string WRONG_NUMBER_PLAYERS_OPTION = "Wrong players number !!";
        public const string COMMAND_NOT_RECOGNIZED = "The command name is not recognized !!";
        public const string SUBCOMMAND_IN_NOT_RECOGNIZED = "IN Subcommand not recognized !!";
        public const string WRONG_TILE = "Wrong Tile !!";
        public const string WRONG_TILE_NOT_EXIST_IN_RACK = "Wrong Tile. Not exists in Rack !!";
        public const string WRONG_GROUP = "Wrong Group !!";
        public const string WRONG_FILE_INDEX = "Wrong file index !!";
        public const string CARACTER_ERROR_COLUMN = "Caracter Error. In Column ";
        public const string ILEGAL_MOVEMENT = "Ilegal movement !!";
        public const string WRONG_POINTS = "You don't have your first 30 points yet";
        public const string WRONG_POINTS_OR_ILEGAL_MOVEMENT = "Ilegal movement or You don't have your first 30 points yet";
        public const string SPACE_REQUIRED = "Missing space required";
    }
}
