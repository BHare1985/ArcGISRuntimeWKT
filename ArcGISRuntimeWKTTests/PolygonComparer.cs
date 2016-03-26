using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Esri.ArcGISRuntime.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcGISRuntimeWKTTests
{
    public class PolygonComparer
    {
        private static bool DeepEquals(object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                return obj1 == null && obj2 == null;
            }

            if (obj1.GetType() != obj2.GetType())
            {
                return false;
            }

            var type = obj1.GetType();
            if (type.IsPrimitive || typeof (string) == type)
            {
                return obj1.Equals(obj2);
            }
            if (type.IsArray)
            {
                var first = obj1 as Array;
                var second = obj2 as Array;
                var en = first.GetEnumerator();
                var i = 0;
                while (en.MoveNext())
                {
                    if (!DeepEquals(en.Current, second.GetValue(i)))
                    {
                        return false;
                    }
                    i++;
                }
            }
            else
            {
                foreach (
                    var pi in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    if (pi.Name == "Extent" || pi.Name == "Capacity")
                    {
                        continue;
                    }

                    try
                    {
                        var expected = pi.GetValue(obj1);
                        var actual = pi.GetValue(obj2);

                        if (!DeepEquals(expected, actual))
                        {
                            return false;
                        }
                    }
                    catch
                    {
                    }
                }
                foreach (var fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    var expected = fi.GetValue(obj1);
                    var actual = fi.GetValue(obj2);
                    if (!DeepEquals(expected, actual))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static int Compare(MapPoint mp1, MapPoint mp2)
        {
            Assert.IsTrue(DeepEquals(mp1, mp2));


            Assert.AreEqual(mp1.X, mp2.X);
            Assert.AreEqual(mp1.Y, mp2.Y);

            return 0;
        }

        public static int Compare(Polygon poly1, Polygon poly2)
        {
            Assert.IsTrue(DeepEquals(poly1, poly2));

            var poly1X = new List<double>();
            var poly1Y = new List<double>();
            var poly2X = new List<double>();
            var poly2Y = new List<double>();
            for (var i = 0; i < poly1.Parts.Count; i++)
            {
                var pt1 = poly1.Parts[i].GetPoints().ToList();
                var pt2 = poly2.Parts[i].GetPoints().ToList();
                for (var j = 0; j < pt1.Count; j++)
                {
                    PopulatePointLists(poly1X, poly1Y, poly2X, poly2Y, pt1, pt2, j);
                }
            }

            return ComparePointLists(poly1X, poly1Y, poly2X, poly2Y);
        }


        public static int Compare(Polyline poly1, Polyline poly2)
        {
            Assert.IsTrue(DeepEquals(poly1, poly2));

            var poly1X = new List<double>();
            var poly1Y = new List<double>();
            var poly2X = new List<double>();
            var poly2Y = new List<double>();

            for (var i = 0; i < poly1.Parts.Count; i++)
            {
                var pt1 = poly1.Parts[i].GetPoints().ToList();
                var pt2 = poly2.Parts[i].GetPoints().ToList();
                for (var j = 0; j < pt1.Count; j++)
                {
                    PopulatePointLists(poly1X, poly1Y, poly2X, poly2Y, pt1, pt2, j);
                }
            }

            return ComparePointLists(poly1X, poly1Y, poly2X, poly2Y);
        }

        public static int Compare(Geometry geom1, Geometry geom2)
        {
            if (geom1.SpatialReference != null && geom2.SpatialReference != null)
            {
                Assert.AreEqual(geom1.SpatialReference.Wkid, geom2.SpatialReference.Wkid);
                if (geom1.SpatialReference.WkText != null && geom2.SpatialReference.WkText != null)
                {
                    Assert.AreEqual(geom1.SpatialReference.WkText, geom2.SpatialReference.WkText);
                }
            }

            if (geom1.Extent != null && geom2.Extent != null)
            {
                Assert.AreEqual(geom1.Extent.Height, geom2.Extent.Height);
                Assert.AreEqual(geom1.Extent.Width, geom2.Extent.Width);
                Assert.AreEqual(geom1.Extent.XMax, geom2.Extent.XMax);
                Assert.AreEqual(geom1.Extent.XMin, geom2.Extent.XMin);
                Assert.AreEqual(geom1.Extent.YMax, geom2.Extent.YMax);
                Assert.AreEqual(geom1.Extent.YMin, geom2.Extent.YMin);
            }

            return 0;
        }

        public static bool Compare(string wkt1, string wkt2)
        {
            if (wkt2.Equals(wkt1))
            {
                Assert.AreEqual(wkt1, wkt2);
                return true;
            }
            // check to see if the MULTI* sign is present and if it even matters.
            // sometimes the input is listed as a multipolygon but it really is just a polygon
            var wkt1Multi = wkt1.StartsWith("MULTI", StringComparison.CurrentCultureIgnoreCase);
            var wkt2Multi = wkt2.StartsWith("MULTI", StringComparison.CurrentCultureIgnoreCase);
            if (wkt1Multi && !wkt2Multi)
            {
                wkt1 = wkt1.Substring(5);
            }
            else if (!wkt1Multi && wkt2Multi)
            {
                wkt2 = wkt2.Substring(5);
            }

            // do some more cleaning on the wkt's
            wkt1 = wkt1.Replace(" (", "(");
            wkt1 = wkt1.Replace(", ", ",");
            wkt2 = wkt2.Replace(" (", "(");
            wkt2 = wkt2.Replace(", ", ",");

            var array = RemoveRedundantParens(wkt1, wkt2);
            wkt1 = array[0];
            wkt2 = array[1];

            Assert.AreEqual(wkt1, wkt2);
            var same = wkt1.Equals(wkt2, StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(same);
            return same;
        }

        #region Helper Methods

        private static string[] RemoveRedundantParens(string wkt1, string wkt2)
        {
            // If you take 2 sets of parentheses and want to see if the outer ones are
            // needed, take the larger set, remove the outer pair of parens and then compare
            // the result to the other set. If they are the same, you can safely remove the 
            // outer pair for an equivalent set.

            if (wkt1.Length == wkt2.Length)
            {
                return new[] {wkt1, wkt2};
            }

            var parens1 = GetParenCharListFromWkt(wkt1);
            var parens2 = GetParenCharListFromWkt(wkt2);
            var wkt1Larger = false;

            if (parens1.Count > parens2.Count)
            {
                parens1.RemoveAt(0);
                parens1.RemoveAt(parens1.Count - 1);
                parens1.TrimExcess();
                wkt1Larger = true;
            }
            else if (parens2.Count > parens1.Count)
            {
                parens2.RemoveAt(0);
                parens2.RemoveAt(parens2.Count - 1);
                parens2.TrimExcess();
                wkt1Larger = false;
            }

            // now compare the inner char array of the large list against the small list
            var same = CompareCharLists(parens1, parens2);
            // remove the first open paren and last close paren:
            if (wkt1Larger)
            {
                wkt1 = wkt1.Remove(wkt1.IndexOf('('), 1);
                wkt1 = wkt1.Remove(wkt1.LastIndexOf(')'), 1);
            }
            else
            {
                wkt2 = wkt2.Remove(wkt2.IndexOf('('), 1);
                wkt2 = wkt2.Remove(wkt2.LastIndexOf(')'), 1);
            }
            return new[] {wkt1, wkt2};
        }

        private static bool CompareCharLists(List<char> parens1, List<char> parens2)
        {
            var same = true;
            if (parens1.Count == parens2.Count)
            {
                for (var i = 0; i < parens1.Count; i++)
                {
                    if (parens1[i] != parens2[i])
                    {
                        same = false;
                        break;
                    }
                }
            }
            else
            {
                same = false;
            }
            return same;
        }

        private static List<char> GetParenCharListFromWkt(string wkt)
        {
            var wktChars = wkt.ToCharArray();
            var parens = new List<char>();
            foreach (var c in wktChars)
            {
                if (c == '(' || c == ')')
                {
                    parens.Add(c);
                }
            }
            return parens;
        }

        private static void PopulatePointLists(List<double> poly1X, List<double> poly1Y, List<double> poly2X,
            List<double> poly2Y, List<MapPoint> pt1, List<MapPoint> pt2, int j)
        {
            var mp1 = pt1[j];
            var mp2 = pt2[j];

            poly1X.Add(mp1.X);
            poly1Y.Add(mp1.Y);
            poly2X.Add(mp2.X);
            poly2Y.Add(mp2.Y);
        }

        private static int ComparePointLists(List<double> poly1X, List<double> poly1Y, List<double> poly2X,
            List<double> poly2Y)
        {
            poly1X.Sort();
            poly1Y.Sort();
            poly2X.Sort();
            poly2Y.Sort();

            if (poly1X.Count != poly2X.Count || poly1Y.Count != poly2Y.Count)
            {
                return 1;
            }

            for (var k = 0; k < poly1X.Count; k++)
            {
                Assert.AreEqual(poly1X[k], poly2X[k]);
                Assert.AreEqual(poly1Y[k], poly2Y[k]);
            }

            return 0;
        }

        #endregion
    }
}