using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class Turn
    {
        private Player[] players;
        private int currentTurn;
        
        public Turn(Player[] players)
        {
            this.players = players;
            this.currentTurn = 0;
        }

        internal Player take()
        {            
            return this.players[this.currentTurn];
        }
       
        internal void change()
        {
            this.currentTurn = this.currentTurn % (this.players.Length - 1);
        }

        internal Action requestAction()
        {
            this.writeRequestAction();
            return null;
        }

        private void writeRequestAction()
        {
            Console.WriteLine("What action do you want to do?: ");
        }

        internal bool isEnd()
        {
            return false;
        }
    }
}
