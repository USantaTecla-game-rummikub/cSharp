using System;
using Rummy.controllers;
using Rummy.controllers.implementation;
using Rummy.models.interpreter;
using Rummy.models.interpreter.InputParser;

namespace Rummy.views.console
{
    public class PlayView: View
    {
        public override void interact(AcceptorController controller)
        {            
            this.showHelpText();
            this.showTurn(controller);
            this.requestUserAction(controller);
        }

        private void requestUserAction(AcceptorController controller) {
            PlayController playController = (PlayController)controller;
            string inputText = Console.ReadLine();
            Input input = new Input(inputText);
            new CommandParser(input).parse();            
            if (input.hasSintaxErrors()) {
                Console.WriteLine(input.errorToString());
            }
            else {                           
                playController.executeAction(new CommandBuilder(inputText).create());
                this.applyLogicPostExecutionCommand(playController);
            }
        }

        private void applyLogicPostExecutionCommand(PlayController playController) {
            if (playController.hasErrorLastAction()) {
                this.showError(playController);
            }
            else if (playController.hasWinner()) {
                Console.WriteLine(Message.CONGRATULATIONS);
                playController.next();
            }
            else if (playController.isLastActionAnExtraction() || playController.isLastActionEndTurn()) {
                if (playController.isLastActionAnExtraction())
                {
                    Console.Write(Message.TILE_EXTRACTION);
                    Console.Write(playController.getLastExtractionTile());
                }
                playController.changeTurn();
            }
            else if (playController.isLastActionSave()) {
                playController.save();
            }
            else if (playController.isLastActionLoad()) {
                playController.load();
            }
        }       

        private void showError(PlayController playController)
        {
            Console.WriteLine();
            Console.WriteLine(playController.getActionError());
            Console.WriteLine();
        }       
       
        private void showTurn(AcceptorController controller)
        {
            PlayController playController = (PlayController)controller;
            Console.WriteLine(Message.POUNCH + playController.getPounchTilesNumber());
            Console.WriteLine();
            Console.WriteLine(Message.TABLE);
            Console.WriteLine(playController.getTable());
            if (playController.hasPlayed30FirstPoints())
            {
                Console.Write(Message.ASTERISK);
            }
            Console.WriteLine(Message.PLAYER + playController.getCurrentPlayerNumber() + " " + Message.TWO_POINTS + playController.getCurrentPlayerRackByGroups());
            Console.Write(Message.REQUEST_ACTION);              
        }

        private void showHelpText()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("¡¡ R U M M Y     G A M E !!");
            Console.WriteLine();
            Console.WriteLine("Main options: PUT to put tiles on the table, MOV to move tiles between groups, END to end turn or extract tile. ");            
            Console.WriteLine("Other options: UNDO to undo move, REDO to redo move, SAVE to save the game, EXIT to exit the game.");
            Console.WriteLine();
            Console.WriteLine("Example: Put on group 2 of the table the combination 10B 10G 10R");
            Console.WriteLine("PUT 10B 10G 10R IN 2");
            Console.WriteLine("Example: Move two tiles of a group at other group");
            Console.WriteLine("MOV FROM 1 10B 10G IN 2");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}