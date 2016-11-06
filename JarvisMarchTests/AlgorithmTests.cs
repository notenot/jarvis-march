using System.Collections.Generic;
using System.Drawing;
using JarvisMarchLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JarvisMarchTests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void TestCalculate()
        {
            var a = new Point(1, 6);
            var b = new Point(7, 5);
            var c = new Point(1, 1);
            var d = new Point(2, 4);
            var e = new Point(4, 7);

            var points = new LinkedList<Point>(new Point[5] 
                { a, b, c, d, e }); 
            var expected = new LinkedList<Point>(new Point[4] 
                { c, a, e, b });
            var actual = JarvisMarch.Calculate(points);

            AreEqualLinkedLists(actual, expected);

            a = new Point(6, 6);
            b = new Point(5, 5);
            c = new Point(7, 7);
            d = new Point(3, 1);
            e = new Point(7, 2);
            var f = new Point(6, 3);
            var j = new Point(3, 5);

            points = new LinkedList<Point>(new Point[7] 
                { a, b, c, d, e, f, j });
            expected = new LinkedList<Point>(new Point[4] 
                { d, j, c, e});
            actual = JarvisMarch.Calculate(points);

            AreEqualLinkedLists(actual, expected);

            a = new Point(-71, -56);
            b = new Point(-72, -59);
            c = new Point(-75, -56);
            d = new Point(-70, -55);
            e = new Point(-72, -58);

            points = new LinkedList<Point>(new Point[5] 
                { a, b, c, d, e });
            expected = new LinkedList<Point>(new Point[3] 
                { c, d, b });
            actual = JarvisMarch.Calculate(points);

            AreEqualLinkedLists(actual, expected);
        }

        private static void AreEqualLinkedLists(LinkedList<Point> expected, 
            LinkedList<Point> actual)
        {
            if (expected.Count != actual.Count)
                Assert.Fail();

            if (expected.Count == 0)
                return;

            var nodeExp = expected.First;
            var nodeAct = actual.First;

            while (nodeExp != null)
            {
                Assert.AreEqual(nodeExp.Value, nodeAct.Value);
                nodeExp = nodeExp.Next;
                nodeAct = nodeAct.Next;
            }
        }
    }
}
