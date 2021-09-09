using System;

namespace EightNeighbourReversi
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(6);
            Console.WriteLine("");
            Console.Write(b.ToString());
        }
    }
}
