using System;

namespace EightNeighbourReversi
{
    class Board 
    {
        private Disc[,] board;
        private int arraylength;
        public Disc this[int i, int j]
        {
            get { return board[i, j]; }
        }

        public Board(int size)
        {
           this.board = new Disc[size, size];
           for (int i = 0; i < size; i++)
           {
               for (int j = 0; j < size; j++)
               {
                   if ((i == 0 || i == size - 1) && (j == 0 || j == size - 1))
                   {
                       if (i == 0 && (j == 0 || j == size - 1))
                       {
                           this.board[i, j] = Disc.RED;
                       }
                       else 
                       {
                            this.board[i,j] = Disc.WHITE;    
                       }
                   }
                   else {
                       this.board[i, j] = Disc.EMPTY;
                   }
               }
           } 
        }

        public bool PlaceDisc(int row, int column, Disc toPlace)
        {
            if (board[row, column] == Disc.EMPTY)
            {
                if (IsLegal(row, column, toPlace))
                {
                    board[row, column] = toPlace;
                    ConvertNeighbours(row, column, toPlace);
                    return true;
                }
            }
            return false;
        }

        private bool IsLegal(int row, int column, Disc toPlace) {
            //TO DO: check if on of the 8 neighbouring discs have the same value as toPlace
            //for (int i = 0; i < )
            //else return false
            return false;
        }

        private void ConvertNeighbours(int row, int column, Disc toPlace)
        {
            //TO DO: Convert all neighbouring Disc to toPlace
        }
    }
}