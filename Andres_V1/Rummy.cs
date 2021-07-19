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
                    p.addNewTile(pounch.take());
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
                        case 1: player.moveTilesFromRackToTable(table); break;
                        case 2: table.moveTilesFromGroupToGroup(); break;
                        case 3: player.addNewTile(pounch.take()); break;
                        case 4: break;
                    }
                } while (menu.finishTurn() || menu.finishPlay() || !player.isWinner());

            } while (menu.finishPlay() || !player.isWinner());
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

        static void Main(string[] args)
        {
            new Rummy().play();
        }
    }
}
