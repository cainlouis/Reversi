using System;

namespace EightNeighbourReversi
{
    public class BotPlayer : IPlayer
    {
        public Disc MyDisc{get;}
        public Position ChooseMove(Board board) {
            int dimension = board.getSize();
            Position position;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (board.IsLegal(i,j,MyDisc)) {
                        position = new Position(i, j);
                        return position;
                    }
                }
            }
            return null;
        }

    }
}