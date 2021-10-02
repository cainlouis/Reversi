using System;

namespace EightNeighbourReversi
{
    public class Board 
    {
        private Disc[,] board;

        private int size;
        //indexer to access the board
        public Disc this[int i, int j]
        {
            get { return board[i, j]; }
        }

        /*Parameterized constructor that get the dimension of the board
        set the field for the size and call setStarting disc */
        public Board(int size)
        {
           this.board = new Disc[size, size];
           this.size = size;
           SetStartingDisc(); 
        }

        //Set the starting disc for both player and disc.empty for the rest of the board
        private void SetStartingDisc()
        {
            for (int i = 0; i < size; i++)
           {
               for (int j = 0; j < size; j++)
               {
                   //Check if it's the extremities of the first or last row
                   if ((i == 0 || i == size - 1) && (j == 0 || j == size - 1))
                   {
                       //Set the extremities of the first row as Disc.Red
                       if (i == 0 && (j == 0 || j == size - 1))
                       {
                           this.board[i, j] = Disc.RED;
                       }
                       //Set the extremities of the last row as Disc.White
                       else 
                       {
                            this.board[i,j] = Disc.WHITE;    
                       }
                   }
                   //If it's none of the extremities of the first or last row set as Disc.Empty
                   else {
                       this.board[i, j] = Disc.EMPTY;
                   }
               }
           }
        }

        /*Check if the position given by players is legal and convert the neighbour in their Disc if it is 
        return true once it's done, else return false.*/
        public bool PlaceDisc(int row, int column, Disc toPlace)
        {
            //If the position is empty, proceed to isLegal
            if (board[row, column] == Disc.EMPTY)
            {
                //If the position is legal
                if (IsLegal(row, column, toPlace))
                {   
                    //Then position equals player's Disc
                    board[row, column] = toPlace;
                    //Convert all neighbours and return true
                    ConvertNeighbours(row, column, toPlace);
                    return true;
                }
            }
            //return false if none of the condition are met
            return false;
        }

        //Check if the position is legal and return true if it is, else return false
        public bool IsLegal(int row, int column, Disc toPlace) {
            //TO DO: check if on of the 8 neighbouring discs have the same value as toPlace
            if (this.board[row,column] == Disc.EMPTY)
            {   
                /*If the row + 1 is equal to the size, hence greater than the last index
                Then the maximum index to check is the last index
                If not, then the maximum index to check is the next row*/
                int maxRow = row + 1 == size ? size - 1 : row + 1;
                /*If the row - 1 is smaller than 0, hence out of bounds, then minRow is 0
                If not, then minRow is row -1*/
                int minRow = row - 1 < 0 ? 0 : row - 1;
            
                int maxColumn = column + 1 == size ? size - 1 : column + 1;
                int minColumn = column - 1 < 0 ? 0 : column - 1; 

                /*for any of the disc withing the bounds created check if there is a neighbour 
                that has the player's disc. return true if there is*/
                for (int i = minRow; i < maxRow + 1; i++) 
                {
                    for (int j = minColumn; j <= maxColumn; j++)
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

        //Convert any neighbour of the player's disc into their disc
        private void ConvertNeighbours(int row, int column, Disc toPlace)
        {
            int maxRow = row + 1 == size ? size - 1 : row + 1;
            int minRow = row - 1 < 0 ? 0 : row - 1;

            int maxColumn = column + 1 == size ? size - 1 : column + 1;
            int minColumn = column - 1 < 0 ? 0 : column - 1; 
            
            //For any of the disc within the bounds created    
            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minColumn; j <= maxColumn; j++)
                {
                    //check if there is a disc that is not the player's disc and is not Disc.empty   
                    if (!(board[i,j] == Disc.EMPTY) && !(board[i,j] == toPlace))
                    {   
                        //Then convert it into the player's disc
                        board[i,j] = toPlace;
                    }
                }
            }
        }

        //Calculate which player has the most Disc and return the winner
        public Result GetWinner() 
        {
            int red = 0;
            int white = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //if the disc is not Disc.Empty check which color it is an increment the int accordingly
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
            //Check which one has the most and return the Result accordingly
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

        //Creates a copy of the board object and returns it
        public Board Copy() 
        {   
            //Create the object and a new disc array accordingly
            Board boardCopy = new Board(size);
            Disc[,] copied = new Disc[size, size];
            //Assign each value of the original disc array to the copy
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    copied[i,j] = board[i,j];
                }
            }
            //Assign the copy to the copied board
            boardCopy.board = copied;
            return boardCopy;
        }

        //Override the ToString() and return the built string
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
                strboard += "\n";
            }
            strboard += "   ";
            for (int i = 0; i < size; i++) {
                strboard += " " + i;
            }
            return strboard;
        }

        //Getter method for the dimension of the board
        public int GetSize() {
            return size;
        }

        //Check if the board is full and return a bool accordingly
        public bool IsFull() {
            for (int i = 0; i < size; i++) 
            {
                for (int j = 0; j < size; j++) 
                {   
                    //If there is an empty disc return false
                    if (board[i,j] == Disc.EMPTY)
                    {
                        return false;
                    }
                }
            }
            //else return true
            return true;
        }

        
    }
}