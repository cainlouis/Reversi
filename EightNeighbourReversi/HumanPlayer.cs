using System;

namespace EightNeighbourReversi
{

    public class HumanPlayer : IPlayer
    {
        public Disc MyDisc{get;}

        public HumanPlayer(Disc disc) 
        {
            MyDisc = disc;
        }

        public Position ChooseMove(Board board) {
            //Display the board
            Console.WriteLine(board.ToString());
            Position position;
            //Get the size of the board
            int dimension = board.getSize();
            //Check that there are legal place to place the disc
            bool continueGame = false;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (board.IsLegal(i,j, MyDisc))
                    {
                        continueGame = true;
                    }
                }
            }
            /*If the board is not full and there are legal placements still proceed to ask the player
            for the position they want to place their disc in */
            if ((!board.isFull()) && continueGame)
            {   
                //As the player to enter a legal position until they do
                do {
                bool success;
                int row;
                int column;
                int counter = 0;
                //Verify that their choice for the row is within bound and a number, if not ask them to select another
                do
                {
                    if (counter > 0)
                    {
                        Console.WriteLine("Make sure to enter a number in bound, choose again.");
                    }
                    Console.WriteLine("Enter a number for the row");
                    success = int.TryParse(Console.ReadLine(), out row);
                    counter++;
                } while (row >= dimension || !(success));
                counter = 0;
                //Verify that their choice for the column is within bound, if not ask them to select another 
                do
                {
                    if (counter > 0)
                    {
                        Console.WriteLine("Make sure to enter a number in bound, choose again.");
                    }
                    Console.WriteLine("Enter a number for the column");
                    success = int.TryParse(Console.ReadLine(), out column);
                    counter++;
                } while (column >= dimension || !(success));
                //create position with their choice and return
                position = new Position(row, column);
                //If the position is not a legal move then print a message 
                if (!board.IsLegal(position.getRow(), position.getColumn(), MyDisc))
                {
                    Console.WriteLine("Illegal move, select another");
                }
                } while(!board.IsLegal(position.getRow(), position.getColumn(), MyDisc));
                return position;
            }
            //Throw an exception if the board is full or there is no legal placement left
            throw new InvalidOperationException("Board full, cannot play");
        }
    }
}