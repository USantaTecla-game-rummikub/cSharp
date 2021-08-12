using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser
{
    public class Tile: Parser
    {
        private const int MIN_TILE_NUMBER = 1;
        private const int MAX_TILE_NUMBER = 13;        

        public Tile(Input input) : base(input)
        {
            
        }

        public override void parse()
        {                              
            string numberOrJoker = this.input.getToken();            
            string numberOrLetter = this.input.getToken();
            string tile = numberOrJoker + numberOrLetter;    // tile con número de 1 dígito más la letra
            if (int.TryParse(numberOrLetter, out int result))
            {
                tile = tile + this.input.getToken();  // tile con número de 2 dígitos y la letra
            }  
            if (this.notMatchWithJoker(numberOrJoker.Trim()) && this.notMatchWithTile(tile.Trim()))
            {
                this.input.generateError(ErrorMessage.WRONG_TILE);
            } else if (this.matchWithJoker(numberOrJoker) && !this.input.isEnd())
            {
                this.input.back();
            }
        }

        private bool matchWithJoker(string character)
        {
            return !this.notMatchWithJoker(character);
        }

        private bool notMatchWithJoker(string character)
        {
            Regex regExJoker = new Regex(@"[J]$");
            return (!regExJoker.IsMatch(character));
        }
        private bool notMatchWithTile(string tile)
        {
            string pattern = @"[1-9]{1,2}[RGBY]";
            Regex regExTile = new Regex(pattern);
            bool isMatch = !regExTile.IsMatch(tile);
            if (isMatch) {
                int number = 0;
                if (tile.Length == 3)
                {
                    number = int.Parse(tile.Substring(0, 2));
                }             
                isMatch = !(number >= MIN_TILE_NUMBER && number <= MAX_TILE_NUMBER);
            }
            return isMatch;
        }
    }
}
