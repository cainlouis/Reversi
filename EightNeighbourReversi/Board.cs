using System;

namespace EightNeighbourReversi
{
    public class Board 
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

        public bool IsLegal(int row, int column, Disc toPlace) {
            //TO DO: check if on of the 8 neighbouring discs have the same value as toPlace
            if (this.board[row,column] == Disc.EMPTY)
            {   
                //Create max variable for the index of the neighbouring disc to have the same value as toPlace
                int maxRow;
                //If the row + 1 is equal to the size, hence greater than the last index
                if (row + 1 > size - 1)
                {
                    //Then the maximum index to check is the last index
                    maxRow = size - 1;
                //if not,
                } else
                {
                    //Then the maximum index to check is the next row
                    maxRow = row + 1;
                }
                int maxColumn;
                if (column + 1 > size - 1)
                {
                    maxColumn = size - 1;
                } else
                {
                    maxColumn = column + 1;
                }
                //Create a variable for the minimun index of the neighbouring disc to have the same value as toPlace
                int minRow;
                //If the row - 1 is smaller than 0, hence out of bounds, then minRow is 0
                if (row - 1 < 0)
                {
                    minRow = 0;
                //if not,
                } else
                {
                    //then minRow is row -1
                    minRow = row - 1;
                }
                int minColumn;
                if (column - 1 < 0)
                {
                    minColumn = 0;
                } else
                {
                    minColumn = column - 1;
                }

                //
                for (int i = minRow; i < maxRow + 1; i++) 
                {
                    for (int j = minColumn; j < maxColumn; j++)
                    {
                        if (board[i, j] == toPlace)
                        {
                            return true;
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
            int maxRow;
            //If the row + 1 is equal to the size, hence greater than the last index
            if (row + 1 == size)
            {
                //Then the maximum index to check is the last index
                maxRow = size - 1;
            //if not,
            } else
            {
                //Then the maximum index to check is the next row
                maxRow = row + 1;
            }
            int maxColumn;
            if (column + 1 == size)
            {
                maxColumn = size - 1;
            } else
            {
                maxColumn = column + 1;
            }
            //Create a variable for the minimun index of the neighbouring disc to have the same value as toPlace
            int minRow;
            //If the row - 1 is smaller than 0, hence out of bounds, then minRow is 0
            if (row - 1 < 0)
            {
                minRow = 0;
            //if not,
            } else
            {
                //then minRow is row -1
                minRow = row - 1;
            }
            int minColumn;
            if (column - 1 < 0)
            {
                minColumn = 0;
            } else
            {
                minColumn = column - 1;
            }   
            for (int i = minRow; i < maxRow; i++)
            {
                for (int j = minColumn; j < maxColumn; j++)
                {
                    
                    if (!(board[i,j] == Disc.EMPTY && board[i,j] == toPlace))
                    {
                        board[i,j] = toPlace;
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

        public Board Copy() 
        {   
            Board boardCopy = new Board(size);
            Disc[,] copied = new Disc[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    copied[i,j] = board[i,j];
                }
            }
            boardCopy.board = copied;
            return boardCopy;
        }

        public override string ToString()
        {
            string strboard = ""; 
            for (int i = 0; i < size; i++) {
                strboard += i < 10 ? i + "  |" : i + " |";
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
                    strboard += "\n";
                }
            }
            return strboard;
        }

        public int getSize() {
            return size;
        }

        public bool isFull() {
            for (int i = 0; i < size; i++) 
            {
                for (int j = 0; j < size; j++) 
                {
                    if (board[i,j] == Disc.EMPTY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        
    }
}