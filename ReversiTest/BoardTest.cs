using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EightNeighbourReversi;

namespace ReversiTest
{
    [TestClass]
    public class BoardTest
    {
        Board board = new Board(4);
        Disc myDisc; 
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PlaceRedOutOfBounds_ThrowIndexOutOfRangeException()
        {
            myDisc = Disc.RED;
            bool result = board.PlaceDisc(3, 4, myDisc);
            Assert.IsFalse(result, "This red disc was able to be placed out of bounds");
        }

        [TestMethod]
        public void PlaceRedInlegalPosition_ReturnTrue()
        {
            myDisc = Disc.WHITE;
            bool result = board.PlaceDisc(1, 0, myDisc);
            Assert.IsTrue(result, "The disc was not able to be in legal position");
        }

        [TestMethod]
        public void PlaceDiscInIllegalPosition_ReturnFalse()
        {
            myDisc = Disc.WHITE;
            bool result = board.PlaceDisc(1, 2, myDisc);
            Assert.IsFalse(result, "Was able to place disc in illegal position");
        }

        [TestMethod]
        public void PlaceDiscOnTakenPosition_ReturnFalse()
        {
            myDisc = Disc.WHITE;
            bool result = board.PlaceDisc(3,0, myDisc);
            Assert.IsFalse(result, "Was able to place disc on a taken position");
        }
    }
}
