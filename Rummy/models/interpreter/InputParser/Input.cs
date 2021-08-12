using Rummy.types;
using Rummy.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser
{
    public class Input
    {
        private string text;
        private int pointer;
        private List<string> errors;

        public Input(string text)
        {
            this.text = text.ToUpper();
            this.pointer = 0;
            this.errors = new List<string>();
        }
   
        internal bool isNotEqual(string character)
        {
            string substring = this.getSubstring(character);
            return substring != character || substring == null;            
        }

        public bool isEqual(string character)
        {
            string substring = this.getSubstring(character);
            return substring == character && substring != null;
        }

        private string getSubstring(string character)
        {
            if (this.pointer + character.Length - 1 < this.text.Length)
            {
                return this.text.Substring(this.pointer, character.Length);
            } else
            {
                return null;
            }
        }

        internal void back()
        {
            this.pointer--;
        }

        internal void movePointer(int advance)
        {
            this.pointer += advance;
        }

        public void jumpSpaces()
        {
            while (!this.isEnd() && this.text.Substring(this.pointer, 1) == Message.SPACE)
            {
                this.pointer++;
            }
        }

        public string getToken()
        {
            if (this.pointer < this.text.Length)
            {
                return this.text.Substring(this.pointer++, 1);
            } else {
                return null;
            }
        }
       
        public void next()
        {
            this.pointer++;
        }

        internal bool isEnd()
        {
            return this.pointer >= this.text.Length;
        }

        internal bool isSpace()
        {
            if (this.pointer < this.text.Length)
            {
                return this.text.Substring(this.pointer, 1) == " ";
            } else
            {
                return false;
            }
        }

        public void generateError(string error)
        {
            this.errors.Add(ErrorMessage.CARACTER_ERROR_COLUMN + this.pointer + Message.TWO_POINTS + error);
        }

        public bool hasSintaxErrors()
        {
            return this.errors.Count > 0;
        }

        public string errorToString()
        {
            string result = "";
            foreach (string error in this.errors)
            {
                result += error + "\n";
            }
            return result;
        }
    }
}
