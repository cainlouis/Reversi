using System;

namespace EightNeighbourReversi 
{
    interface IPlayer 
    {
        Disc MyDisc{get;}
        Position ChooseMove(Board board);
    }
}