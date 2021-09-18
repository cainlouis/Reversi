using System;

namespace EightNeighbourReversi 
{
    public class Game
    {
        private IPlayer humanPlayer;
        private IPlayer botPlayer;

        public Game(HumanPlayer humanPlayer, BotPlayer botPlayer)
        {
            this.humanPlayer = humanPlayer;
            this.botPlayer = botPlayer;
        }

        public Result Play() 
        {
            int size;
            bool success;
            int counter = 0;
            do
            {
                if (counter > 0)
                {
                    Console.WriteLine("Make sure to enter a number, try again");
                }
                //Ask the player to enter the size of board
                Console.WriteLine("Enter the size of the board");
                success = int.TryParse(Console.ReadLine(), out size);
                counter++;
            } while (!success);
            //create the board according to the size 
            Board gameBoard = new Board(size);
            //Create the copy of the board
            Board boardCopy = gameBoard.Copy();
            Result winner;
            Position position;
            //As long as the board is not full
            while (!boardCopy.isFull())
            {
                try
                {
                    //Human player choose move 
                    position = humanPlayer.ChooseMove(boardCopy);
                    //then place the disc if possible
                    boardCopy.PlaceDisc(position.getRow(), position.getColumn(), humanPlayer.MyDisc);

                    position = botPlayer.ChooseMove(boardCopy);
                    boardCopy.PlaceDisc(position.getRow(), position.getColumn(), botPlayer.MyDisc);
                }
                catch (InvalidOperationException)
                {  
                    //If the human player throw the exception catch and calculate the winner
                    winner = boardCopy.GetWinner();
                    Console.WriteLine(boardCopy.ToString());
                    return winner;
                }
            }
            //Once the board is full calculate the winner
            winner = boardCopy.GetWinner();
            Console.WriteLine(boardCopy.ToString());
            return winner;
        }
    }
}