using System;

namespace EightNeighbourReversi
{
    public class BotPlayer : IPlayer
    {
        public Disc MyDisc{get;}

        public BotPlayer(Disc disc) 
        {
            MyDisc = disc;
        }

        /*Get the boar copy and choose a move to make and return the position chosen*/
        public Position ChooseMove(Board board) {
            //if board not full proceed 
            if (!board.IsFull()) {
                int dimension = board.GetSize();
                Position[] legalPos;
                int counter = 0;
                //Check every disc of the board to get a legal position to choose
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        //if it is legal add to the counter
                        if (board.IsLegal(i,j,MyDisc)) {
                            counter++;
                        }
                    }
                }
                //If there is legal moves to make
                if (counter > 0)
                {
                    //create an array of the legal position to choose
                    legalPos = new Position[counter];
                    int index = 0;
                    //assign the position to the array
                    for (int i = 0; i < dimension; i++)
                    {
                        for (int j = 0; j < dimension; j++)
                        {
                            if (board.IsLegal(i,j,MyDisc)) {
                                legalPos[index] = new Position(i, j);
                                index++;
                            }
                        }
                    }
                    //Create a random object to get a random int
                    Random random = new Random();
                    int rand = random.Next(counter);
                    //and return random position
                    return legalPos[rand];
                }
            }
            //If board is full or there is not legal position throw exception
            throw new InvalidOperationException("Board full, cannot play");
        }
    }
}