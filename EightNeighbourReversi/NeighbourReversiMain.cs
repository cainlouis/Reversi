using System;

namespace EightNeighbourReversi
{
    class NeighbourReversiMain
    {
        static void Main(string[] args)
        {
            //Create both Player objects
            HumanPlayer humanPlayer = new HumanPlayer(Disc.WHITE);
            //Tell the player which one they are
            Console.WriteLine("Your disc is white");
            BotPlayer botPlayer = new BotPlayer(Disc.RED);
            //Create the game object
            Game reversi = new Game(humanPlayer, botPlayer);
            //Write the winner from the return result of play()
            Console.WriteLine("Winner is " + reversi.Play() + "!");
        }
    }
}
