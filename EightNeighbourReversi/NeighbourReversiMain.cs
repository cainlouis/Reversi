using System;

namespace EightNeighbourReversi
{
    class NeighbourReversiMain
    {
        static void Main(string[] args)
        {
            HumanPlayer humanPlayer = new HumanPlayer(Disc.WHITE);
            Console.WriteLine("Your disc is white");
            BotPlayer botPlayer = new BotPlayer(Disc.RED);
            Game reversi = new Game(humanPlayer, botPlayer);
            Console.WriteLine("Winner is " + reversi.Play() + "!");
        }
    }
}
