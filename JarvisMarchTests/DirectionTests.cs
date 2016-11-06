using System.Drawing;
using JarvisMarchLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JarvisMarchTests
{
    [TestClass]
    public class DirectionTests
    {
        [TestMethod]
        public void TestCalculate()
        {
            var a = new Point(0, 0);
            var b = new Point(1, 1);
            var c = new Point(2, 1);

            var actual = Direction.Calculate(a, b, c);
            Assert.AreEqual(Direction.Value.Right, actual);

            a = new Point(-2, -10);
            b = new Point(-30, -9);
            c = new Point(-30, -50);

            actual = Direction.Calculate(a, b, c);
            Assert.AreEqual(Direction.Value.Left, actual);

            a = new Point(-100, -100);
            b = new Point(-2, -2);
            c = new Point(30, 30);

            actual = Direction.Calculate(a, b, c);
            Assert.AreEqual(Direction.Value.Straight, actual);
        }
    }
}
