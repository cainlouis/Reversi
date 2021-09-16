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
        public Position ChooseMove(Board board) {
            if (!board.isFull()) {
                int dimension = board.getSize();
                Position[] legalPos;
                int counter = 0;
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        if (board.IsLegal(i,j,MyDisc)) {
                            counter++;
                        }
                    }
                }
                if (counter > 0)
                {
                    legalPos = new Position[counter];
                    int index = 0;
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
                    Random random = new Random();
                    int rand = random.Next(counter);
                    return legalPos[rand];
                }
            }
            throw new InvalidOperationException("Board full, cannot play");
        }
    }
}