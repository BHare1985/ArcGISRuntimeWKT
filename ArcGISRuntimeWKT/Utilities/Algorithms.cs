using System;
using System.Collections.Generic;
using System.Linq;
using Esri.ArcGISRuntime.Geometry;

namespace ArcGISRuntimeWKT.Utilities
{
    public class Algorithms
    {
        public static bool IsCcw(ReadOnlySegmentCollection ring)
        {
            return IsCcw(ring.GetPoints().ToList());
        }

        public static bool IsCcw(IEnumerable<MapPoint> ring)
        {
            return IsCcw(ring.ToList());
        }

        /// <summary>
        ///     Tests whether a ring is oriented counter-clockwise.
        /// </summary>
        /// <param name="ring">Ring to test.</param>
        /// <returns>Returns true if ring is oriented counter-clockwise.</returns>
        public static bool IsCcw(List<MapPoint> ring)
        {
            // Check if the ring has enough vertices to be a ring
            if (ring.Count < 3)
            {
                throw new ArgumentException("Invalid LinearRing");
            }

            // find the point with the largest Y coordinate
            var hip = ring[0];
            var hii = 0;
            for (var i = 1; i < ring.Count; i++)
            {
                var p = ring[i];
                if (p.Y > hip.Y)
                {
                    hip = p;
                    hii = i;
                }
            }
            // Point left to Hip
            var iPrev = hii - 1;
            if (iPrev < 0)
            {
                iPrev = ring.Count - 2;
            }
            // Point right to Hip
            var iNext = hii + 1;
            if (iNext >= ring.Count)
            {
                iNext = 1;
            }
            var prevPoint = ring[iPrev];
            var nextPoint = ring[iNext];

            // translate so that hip is at the origin.
            // This will not affect the area calculation, and will avoid
            // finite-accuracy errors (i.e very small vectors with very large coordinates)
            // This also simplifies the discriminant calculation.
            var prev2X = prevPoint.X - hip.X;
            var prev2Y = prevPoint.Y - hip.Y;
            var next2X = nextPoint.X - hip.X;
            var next2Y = nextPoint.Y - hip.Y;
            // compute cross-product of vectors hip->next and hip->prev
            // (e.g. area of parallelogram they enclose)
            var disc = next2X*prev2Y - next2Y*prev2X;
            // If disc is exactly 0, lines are collinear.  There are two possible cases:
            //	(1) the lines lie along the x axis in opposite directions
            //	(2) the line lie on top of one another
            //  (2) should never happen, so we're going to ignore it!
            //	(Might want to assert this)
            //  (1) is handled by checking if next is left of prev ==> CCW

            if (disc == 0.0)
            {
                // poly is CCW if prev x is right of next x
                return prevPoint.X > nextPoint.X;
            }
            // if area is positive, points are ordered CCW
            return disc > 0.0;
        }
    }
}