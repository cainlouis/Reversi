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
            if (this.board[row,column] == Disc.EMPTY)
            {
                for (int i = 0; i < this.board.Length; i++) 
                {
                    for (int j = 0; i < this.board.Length; j++)
                    {
                        if (board[i,j] == toPlace)
                        {
                            if (i == row || i == row + 1 || i == row -1)
                            {
                                if (j == column || j == column + 1 || j == column -1)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            //else return false
            return false;
        }

        private void ConvertNeighbours(int row, int column, Disc toPlace)
        {
            //TO DO: Convert all neighbouring Disc to toPlace
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (i == row || i == row - 1 || i == row + 1)
                    {
                        if (j == column || j == column + 1 || j == column - 1)
                        {
                            if (!(board[i,j] == Disc.EMPTY))
                            {
                                board[i,j] = toPlace;
                            }
                        }
                    }
                }
            }
        }
    }
}