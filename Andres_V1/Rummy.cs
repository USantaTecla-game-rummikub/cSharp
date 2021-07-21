using System;

namespace escuela_it
{
    class Rummy
    {
        const int PLAYERS_COUNT = 2;
        const int INIT_TILES_BY_PLAYER = 14;
        Table table;
        Pounch pounch;
        Turn turn;
        public Rummy()
        {
            pounch = new Pounch();
            turn = new Turn(new Player[PLAYERS_COUNT] { new Player("1"), new Player("2") });
            table = new Table();
        }

        private void initGame()
        {
            for (int i = 0; i < INIT_TILES_BY_PLAYER; i++)
            {
                for (int j = 0; j < PLAYERS_COUNT; i++)
                {
                    Player p = turn.nextPlayer();
                    p.insert(pounch.take());
                }
            }
        }
        private void play()
        {
            this.initGame();
            Menu menu = new Menu();
            Player player;
            do
            {
                player = turn.nextPlayer();
                this.show(player);
                int opt;
                do
                {
                    menu.show();
                    opt = menu.getOption();
                    switch (opt)
                    {
                        case 1: moveTilesFromRackToTable(player); break;
                        case 2: moveFromGroupToGroupTiles(); break;
                        case 3: player.insert(pounch.take()); break;
                        case 4: break;
                    }
                    table.clean();
                } while (menu.finishTurn() || menu.finishPlay() || !player.isWinner());

            } while (menu.finishPlay() || !player.isWinner());
        }

        static void Main(string[] args)
        {
            new Rummy().play();
        }

        private void moveTilesFromRackToTable(Player player)
        {
            new Mover(table).from(player).to(this.readGroupDest()).these(this.readTiles());
        }

        private void moveFromGroupToGroupTiles()
        {
            new Mover(table).from(this.readGroupOrigin()).to(this.readGroupDest())
                .these(this.readTiles()).move();
        }

        private Tile[] readTiles()
        {
            throw new NotImplementedException();
        }

        private int readGroupDest()
        {
            throw new NotImplementedException();
        }

        private int readGroupOrigin()
        {
            throw new NotImplementedException();
        }

        private void show(Player player)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Rummy");
            Console.WriteLine("--------------------------------------------------------------------------------");
            pounch.show();
            player.show();
            table.show();
        }
       
    }
}
