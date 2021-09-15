using System;

namespace EightNeighbourReversi
{

    class HumanPlayer : IPlayer
    {
        public Disc MyDisc{get;}

        public Position ChooseMove(Board board) {
            board.ToString();
            Position position;
            int dimension = board.getSize();
            if (!board.isFull(MyDisc))
            {   
                /*string[] arr = new string[2];
                arr[0] = "row";
                arr[] */
                Console.WriteLine("Enter a number for the row");
                int row = int.Parse(Console.ReadLine());
                if (row >= dimension)
                {
                    Console.WriteLine("Invalid number, insert a number smaller than " + dimension);
                    row = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter a number for the column");
                int column = int.Parse(Console.ReadLine());
                if (row >= dimension)
                {
                    Console.WriteLine("Invalid number, insert a number smaller than " + dimension);
                    column = int.Parse(Console.ReadLine());
                }
                position = new Position(row, column);
                return position;
            }
            else 
            {
                throw new InvalidOperationException("Board full, cannot play");
            }
        }
        
    }
}