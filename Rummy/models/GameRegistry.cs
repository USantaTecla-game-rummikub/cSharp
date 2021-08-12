using Rummy.types;
using System;
using System.Collections.Generic;

namespace Rummy.models
{
    public class GameRegistry
    {
        private Game game;
        private List<GameMemento> mementos;
        private int pointer;
        
        public GameRegistry(Game game)
        {
            this.game = game;
            this.reset();
        }

        private void reset()
        {
            this.mementos = new List<GameMemento>();
            this.pointer = 0;            
        }

        public void register()
        {
            if (this.game.canCreateMemento())
            {
                this.mementos.Add(this.game.getMemento());                
            }
        }

        public void undo()
        {            
            this.pointer--;
            this.game.set(this.mementos[this.mementos.Count - 1 + this.pointer]);
            this.game.undo();
        }

        public void redo()
        {            
            this.game.set(this.mementos[this.mementos.Count - 1 + this.pointer]);
            this.pointer++;
            this.game.redo();
        }

        public bool isRedoable()
        {
            return this.pointer < 0;
        }

        public bool isUndoable()
        {
            return -this.pointer < this.mementos.Count - 1;
        }
    }
}