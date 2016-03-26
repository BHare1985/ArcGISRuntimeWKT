using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using EsriSlWkt.Converters.WellKnownText;
using EsriSlWkt.Converters.WellKnownBinary;
using EsriSlWkt.Utilities;
using EsriSlWkt.Converters;
using ESRI.ArcGIS.Client.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsSL
{
    public class PolygonComparer
    {
        public static int Compare(MapPoint mp1, MapPoint mp2)
        {
            Assert.AreEqual(mp1.X, mp2.X);
            Assert.AreEqual(mp1.Y, mp2.Y);

            return 0;
        }

        public static int Compare(Polygon poly1, Polygon poly2)
        {
            bool isTheSame = poly1.Equals(poly2);
            List<double> poly1X = new List<double>();
            List<double> poly1Y = new List<double>();
            List<double> poly2X = new List<double>();
            List<double> poly2Y = new List<double>();
            isTheSame = poly1.Equals(poly2);
            for (int i = 0; i < poly1.Rings.Count; i++)
            {
                PointCollection pt1 = poly1.Rings[i];
                PointCollection pt2 = poly2.Rings[i];
                for (int j = 0; j < pt1.Count; j++)
                {
                    PopulatePointLists(poly1X, poly1Y, poly2X, poly2Y, pt1, pt2, j);
                }
            }

            return ComparePointLists(poly1X, poly1Y, poly2X, poly2Y);
        }

        public static int Compare(MultiPoint mp1, MultiPoint mp2)
        {
            List<double> poly1X = new List<double>();
            List<double> poly1Y = new List<double>();
            List<double> poly2X = new List<double>();
            List<double> poly2Y = new List<double>();

            PointCollection pt1 = mp1.Points;
            PointCollection pt2 = mp2.Points;
            for (int j = 0; j < pt1.Count; j++)
            {
                PopulatePointLists(poly1X, poly1Y, poly2X, poly2Y, pt1, pt2, j);
            }

            return ComparePointLists(poly1X, poly1Y, poly2X, poly2Y);
        }

        public static int Compare(Polyline poly1, Polyline poly2)
        {
            List<double> poly1X = new List<double>();
            List<double> poly1Y = new List<double>();
            List<double> poly2X = new List<double>();
            List<double> poly2Y = new List<double>();

            for (int i = 0; i < poly1.Paths.Count; i++)
            {
                PointCollection pt1 = poly1.Paths[i];
                PointCollection pt2 = poly2.Paths[i];
                for (int j = 0; j < pt1.Count; j++)
                {
                    PopulatePointLists(poly1X, poly1Y, poly2X, poly2Y, pt1, pt2, j);
                }
            }

            return ComparePointLists(poly1X, poly1Y, poly2X, poly2Y);
        }

        public static int Compare(Geometry geom1, Geometry geom2)
        {
            if(geom1.SpatialReference != null && geom2.SpatialReference != null)
            {
                if(geom1.SpatialReference.WKID != null && geom2.SpatialReference.WKID != null)
                    Assert.AreEqual(geom1.SpatialReference.WKID, geom2.SpatialReference.WKID);
                if (geom1.SpatialReference.WKT != null && geom2.SpatialReference.WKT != null)
                    Assert.AreEqual(geom1.SpatialReference.WKT, geom2.SpatialReference.WKT);
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
            else
            {
                // check to see if the MULTI* sign is present and if it even matters.
                // sometimes the input is listed as a multipolygon but it really is just a polygon
                bool wkt1Multi = wkt1.StartsWith("MULTI", StringComparison.CurrentCultureIgnoreCase);
                bool wkt2Multi = wkt2.StartsWith("MULTI", StringComparison.CurrentCultureIgnoreCase);
                if (wkt1Multi && !wkt2Multi)
                    wkt1 = wkt1.Substring(5);
                else if (!wkt1Multi && wkt2Multi)
                    wkt2 = wkt2.Substring(5);

                // do some more cleaning on the wkt's
                wkt1 = wkt1.Replace(" (", "(");
                wkt1 = wkt1.Replace(", ", ",");
                wkt2 = wkt2.Replace(" (", "(");
                wkt2 = wkt2.Replace(", ", ",");

                string[] array = RemoveRedundantParens(wkt1, wkt2);
                wkt1 = array[0];
                wkt2 = array[1];

                bool same = wkt1.Equals(wkt2, StringComparison.CurrentCultureIgnoreCase);
                Assert.IsTrue(same);
                return same;
            }
        }

        #region Helper Methods

        private static string[] RemoveRedundantParens(string wkt1, string wkt2)
        {
            // If you take 2 sets of parentheses and want to see if the outer ones are
            // needed, take the larger set, remove the outer pair of parens and then compare
            // the result to the other set. If they are the same, you can safely remove the 
            // outer pair for an equivalent set.

            if (wkt1.Length == wkt2.Length)
                return new string[] { wkt1, wkt2 };

            List<char> parens1 = GetParenCharListFromWkt(wkt1);
            List<char> parens2 = GetParenCharListFromWkt(wkt2);
            bool wkt1Larger = false;

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
            bool same = CompareCharLists(parens1, parens2);
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
            return new string[] { wkt1, wkt2 };
        }

        private static bool CompareCharLists(List<char> parens1, List<char> parens2)
        {
            bool same = true;
            if (parens1.Count == parens2.Count)
            {
                for (int i = 0; i < parens1.Count; i++)
                {
                    if (parens1[i] != parens2[i])
                    {
                        same = false;
                        break;
                    }
                }
            }
            else
                same = false;
            return same;
        }

        private static List<char> GetParenCharListFromWkt(string wkt)
        {
            char[] wktChars = wkt.ToCharArray();
            List<char> parens = new List<char>();
            int i = 0;
            foreach (char c in wktChars)
            {
                if (c == '(' || c == ')')
                    parens.Add(c);
                i++;
            }
            return parens;
        }

        private static void PopulatePointLists(List<double> poly1X, List<double> poly1Y, List<double> poly2X, List<double> poly2Y, PointCollection pt1, PointCollection pt2, int j)
        {
            MapPoint mp1 = pt1[j];
            MapPoint mp2 = pt2[j];

            poly1X.Add(mp1.X);
            poly1Y.Add(mp1.Y);
            poly2X.Add(mp2.X);
            poly2Y.Add(mp2.Y);
        }

        private static int ComparePointLists(List<double> poly1X, List<double> poly1Y, List<double> poly2X, List<double> poly2Y)
        {
            poly1X.Sort();
            poly1Y.Sort();
            poly2X.Sort();
            poly2Y.Sort();

            if (poly1X.Count != poly2X.Count || poly1Y.Count != poly2Y.Count)
                return 1;

            for (int k = 0; k < poly1X.Count; k++)
            {
                Assert.AreEqual(poly1X[k], poly2X[k]);
                Assert.AreEqual(poly1Y[k], poly2Y[k]);
            }

            return 0;
        }

        #endregion
    }
}
