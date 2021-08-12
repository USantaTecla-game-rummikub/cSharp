using System;
using Rummy.controllers;
using Rummy.types;

namespace Rummy.views.console
{
    public class StartView: View
    {
        public override void interact(AcceptorController controller)
        {
            this.showOptionsMenu();
            this.selectOptionMenu(controller);
        }

        private void showOptionsMenu()
        {
            Console.WriteLine(Message.RUMMY_GAME);
            Console.WriteLine();
            Console.WriteLine(Message.MENU_OPTION_PLAY);
            Console.WriteLine(Message.MENU_OPTION_LOAD);
            Console.WriteLine(Message.MENU_OPTION_EXIT);
            Console.Write(Message.SELECT_MENU_OPTION);            
        }

        private void selectOptionMenu(AcceptorController controller)
        {
            StartController startController = (StartController)controller;
            string option = Console.ReadLine();
            switch (int.Parse(option))
            {
                case 1:
                    this.executePlayOption(controller);
                    break;

                case 2:                    
                    startController.load();
                    break;

                case 3:                    
                    startController.exit();
                    break;
            }
        }    
        
        private void executePlayOption(AcceptorController controller)
        {
            bool optionValid = false;
            while (!optionValid) {
                Console.Write(Message.INTRODUCE_NUMBER_PLAYERS);
                try
                {
                    int numPlayers = int.Parse(Console.ReadLine());
                    StartController startController = (StartController)controller;
                    optionValid = startController.isNumberPlayersValid(numPlayers);
                    if (optionValid)
                    {                        
                        startController.play(numPlayers);                        
                    } else
                    {
                        Console.WriteLine(ErrorMessage.WRONG_NUMBER_PLAYERS_OPTION);
                    }
                } catch (Exception )
                {
                    Console.WriteLine(ErrorMessage.WRONG_NUMBER_PLAYERS_OPTION);
                }
             }
        }
    }
}