using System;

namespace EightNeighbourReversi
{
    class Board 
    {
        private Disc[,] board;

        private int size;
        public Disc this[int i, int j]
        {
            get { return board[i, j]; }
        }

        public Board(int size)
        {
           this.board = new Disc[size, size];
           this.size = size;
           setStartingDisc(); 
        }

        private void setStartingDisc()
        {
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
                   Console.Write(board[i,j]);
                   Console.Write(" ");
               }
               Console.WriteLine("");
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
                /*if (row == 0 || row == size -1 || column == 0 || column == size -1)
                {
                    if ()
                }
                Disc[] offsets = {board[row -1, column -1], board[row, column -1], board[row +1, column -1], board[row -1, column], board[row +1, column], board[row -1, column +1], board[row, column +1], board[row +1, column +1]};
                foreach(Disc dc in offsets) 
                {
                    if (dc == toPlace)
                    {
                        return true;
                    }
                }*/
                for (int i = 0; i < size; i++) 
                {
                    for (int j = 0; i < size; j++)
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
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == row || i == row - 1 || i == row + 1)
                    {
                        if (j == column || j == column + 1 || j == column - 1)
                        {
                            if (!(board[i,j] == Disc.EMPTY && board[i,j] == toPlace))
                            {
                                board[i,j] = toPlace;
                            }
                        }
                    }
                }
            } 
        }

        public Result GetWinner() 
        {
            int red = 0;
            int white = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!(board[i,j] == Disc.EMPTY))
                    {
                        if (board[i,j] == Disc.RED)
                        {
                            red++;
                        }
                        else
                        {
                            white++;
                        }
                    }
                }
            }
            if (red > white)
            {
                return Result.RED;
            }
            else if (red < white)
            {
                return Result.WHITE;
            }
            else
            {
                return Result.TIE;
            }
        }

        public Disc[,] Copy() 
        {
            Disc[,] copied = new Disc[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    copied[i,j] = board[i,j];
                }
            }
            return copied;
        }

        public override string ToString()
        {
            string strboard = "|"; 
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++)
                {
                    if (board[i,j] == Disc.RED)
                    {
                        strboard += "R|";
                    }
                    else if (board[i,j] == Disc.WHITE)
                    {
                        strboard += "W|";
                    }
                    else
                    {
                        strboard += "-|";
                    }
                }
                if (!(i == size -1)) {
                    strboard += "\n|";
                }
            }
            return strboard;
        }
    }
}