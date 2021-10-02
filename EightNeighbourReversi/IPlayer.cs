using System;

namespace EightNeighbourReversi 
{   
    //Interface used by HumanPlayer and BotPlayer classes
    interface IPlayer 
    {
        Disc MyDisc{get;}
        Position ChooseMove(Board board);
    }
}