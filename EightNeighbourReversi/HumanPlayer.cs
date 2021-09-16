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
                Console.WriteLine("Enter a number for the row");
                int row = int.Parse(Console.ReadLine());
                //Verify that their choice for the row is within bound, if not ask them to select another
                if (row >= dimension)
                {
                    Console.WriteLine("Invalid number, insert a number smaller than " + dimension);
                    row = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter a number for the column");
                int column = int.Parse(Console.ReadLine());
                //Verify that their choice for the column is within bound, if not ask them to select another 
                if (row >= dimension)
                {
                    Console.WriteLine("Invalid number, insert a number smaller than " + dimension);
                    column = int.Parse(Console.ReadLine());
                }
                //create position with their choice and return
                position = new Position(row, column);
                return position;
            }
            //Throw an exception if the board is full or there is no legal placement left
            else 
            {
                throw new InvalidOperationException("Board full, cannot play");
            }
        }
    }
}