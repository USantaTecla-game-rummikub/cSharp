using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.DAO
{
    public class GameDAO
    {
        private Game game;
        
        public GameDAO(Game game)
        {
            this.game = game;
        }

        public void save(StreamWriter file )
        {            
            GameMemento memento = this.game.getMemento();
            file.WriteLine(memento.getPlayersNumber());
            file.WriteLine(memento.getCurrentPlayer());
            file.WriteLine(memento.getTurnsAfterEmptyPounch());
            this.savePlayersStates(file, memento);
            file.WriteLine(memento.getTilesPounch());
            file.WriteLine(memento.getTilesGroup());
        }

        private void savePlayersStates(StreamWriter file, GameMemento memento)
        {
            for (int i = 0; i < memento.getPlayersNumber(); i++)
            {
                file.WriteLine(memento.getPlayerState(i));
            }
        }

        public void load(StreamReader file)
        {
            string playersNumber = file.ReadLine();
            string currentPlayer = file.ReadLine();
            string turnsAfterEmptyPounch = file.ReadLine();
            List<string> playersStates = this.loadPlayersStates(file, int.Parse(playersNumber));
            string tilesPounch = file.ReadLine();
            string tilesGroup = file.ReadLine();
            this.game.setNumberPlayers(int.Parse(playersNumber));
            this.game.set(new GameMemento(int.Parse(playersNumber), int.Parse(currentPlayer), int.Parse(turnsAfterEmptyPounch), playersStates, tilesPounch, tilesGroup));
        }

        private List<string> loadPlayersStates(StreamReader file, int playersNumber)
        {
            List<string> playersStates = new List<string>();
            for (int i = 0; i < playersNumber; i++)
            {
                 playersStates.Add( file.ReadLine());
            }
            return playersStates;
        }
    }
}
