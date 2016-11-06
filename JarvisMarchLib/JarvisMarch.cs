﻿using System.Collections.Generic;
using System.Drawing;

namespace JarvisMarchLib
{
    public static class JarvisMarch
    {
        private static LinkedList<Point> _points;
        private static LinkedList<Point> _convexHull;

        public static LinkedList<Point> Calculate(LinkedList<Point> points)
        {
            if (points.Count < 3)
                return null;

            _points = new LinkedList<Point>(points);
            _convexHull = new LinkedList<Point>();

            var s0 = GetLowerLeftPoint();
            _convexHull.AddLast(s0);
            _points.Remove(s0);
            _points.AddLast(s0);

            while (true)
            {
                var s1 = _points.First.Value;
                foreach (var p in _points) 
                    if (Direction.Calculate(s0, s1, p) == Direction.Value.Left)
                        s1 = p;
                if (s1 == _convexHull.First.Value)
                    break;
                
                _convexHull.AddLast(s1);
                _points.Remove(s1);
                s0 = s1;
            } 

            return _convexHull;
        }

        private static Point GetLowerLeftPoint()
        {
            // _points have more then 2 elements
            var res = _points.First;
            var node = res.Next;

            while (node != null)
            {
                if (node.Value.X < res.Value.X)
                    res = node;

                if (node.Value.X == res.Value.X &&
                    node.Value.Y < res.Value.Y)
                    res = node;

                node = node.Next;
            }

            return res.Value;
        }
    }
}
