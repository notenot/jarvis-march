using System.Drawing;

namespace JarvisMarchLib
{
    public static class Direction
    {
        public enum Value { Left, Straight, Right }

        /// <summary>
        /// Calculate rotate direction from line (a,b) to line (b,c).
        /// </summary>
        public static Value Calculate(Point a, Point b, Point c)
        {
            // move points b and c to origin
            var newB = new Point(b.X - a.X, b.Y - a.Y);
            var newC = new Point(c.X - a.X, c.Y - a.Y);
            // calculate pseudoinner product
            var prod = newC.Y * newB.X - newB.Y * newC.Y;

            if (prod > 0)
                return Value.Left;

            if (prod < 0)
                return Value.Right;

            return Value.Straight;
        }
    }
}
