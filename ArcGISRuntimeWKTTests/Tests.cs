using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArcGISRuntimeWKT.Converters.WellKnownText;
using Esri.ArcGISRuntime.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcGISRuntimeWKTTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void PointFromWkt()
        {
            var wktPoint = "POINT(25.48828125 -1.93359375)";
            var actual = GeometryFromWKT.Parse(wktPoint) as MapPoint;
            var expected = new MapPoint(25.48828125, -1.93359375);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void LineFromWkt()
        {
            var wktLine =
                "LINESTRING(19.51171875 -3.515625, 17.05078125 10.37109375, 15.64453125 -8.26171875, 19.51171875 -16.171875)";
            var actual = GeometryFromWKT.Parse(wktLine) as Polyline;
            var expected = new Polyline();

            var mp1 = new MapPoint(19.51171875, -3.515625);
            var mp2 = new MapPoint(17.05078125, 10.37109375);
            var mp3 = new MapPoint(15.64453125, -8.26171875);
            var mp4 = new MapPoint(19.51171875, -16.171875);
            var pc = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp4});
            var oc = new ObservableCollection<PointCollection> {pc};

            expected.Paths = oc;
            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void PolyFromWkt()
        {
            var wktPoly =
                "POLYGON((15.29296875 23.203125, 25.13671875 22.67578125, 19.51171875 16.34765625, 15.29296875 23.203125))";
            var actual = GeometryFromWKT.Parse(wktPoly) as Polygon;
            var expected = new Polygon();
            var mp1 = new MapPoint(15.29296875, 23.203125);
            var mp2 = new MapPoint(25.13671875, 22.67578125);
            var mp3 = new MapPoint(19.51171875, 16.34765625);
            var mp4 = new MapPoint(15.29296875, 23.203125);
            var mp5 = new MapPoint(15.29296875, 23.203125);
            var pc = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp4, mp5});
            var oc = new ObservableCollection<PointCollection>(new List<PointCollection> {pc});
            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void PolyWithHoleFromWkt()
        {
            var wktPolyWithHole =
                "POLYGON((3.8671875 30.5859375, 35.33203125 23.90625, 20.390625 -2.109375, -6.6796875 8.4375, 3.8671875 30.5859375),(15.29296875 23.203125, 25.13671875 22.67578125, 19.51171875 16.34765625, 15.29296875 23.203125))";
            var actual = GeometryFromWKT.Parse(wktPolyWithHole) as Polygon;

            var mp1 = new MapPoint(3.8671875, 30.5859375);
            var mp2 = new MapPoint(35.33203125, 23.90625);
            var mp3 = new MapPoint(20.390625, -2.109375);
            var mp4 = new MapPoint(-6.6796875, 8.4375);
            var mp5 = new MapPoint(3.8671875, 30.5859375);
            var pc1 = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp4, mp5});

            var mp6 = new MapPoint(15.29296875, 23.203125);
            var mp7 = new MapPoint(25.13671875, 22.67578125);
            var mp8 = new MapPoint(19.51171875, 16.34765625);
            var mp9 = new MapPoint(15.29296875, 23.203125);
            var pc2 = new PointCollection(new List<MapPoint> {mp6, mp7, mp8, mp9});

            var oc = new ObservableCollection<PointCollection>(new List<PointCollection> {pc1, pc2});
            var expected = new Polygon();
            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPointFromWkt1()
        {
            var wktMultiPoint1 = "MULTIPOINT ((10 40), (40 30), (20 20), (30 10))";
            MultiPoint actual = GeometryFromWKT.Parse(wktMultiPoint1) as MultiPoint;

            var mp1 = new MapPoint(10, 40);
            var mp2 = new MapPoint(40, 30);
            var mp3 = new MapPoint(20, 20);
            var mp4 = new MapPoint(30, 10);
            var pc = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp4});
            MultiPoint expected = new MultiPoint(pc);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPointFromWkt2()
        {
            var wktMultiPoint2 = "MULTIPOINT (10 40, 40 30, 20 20, 30 10)";
            MultiPoint actual = GeometryFromWKT.Parse(wktMultiPoint2) as MultiPoint;

            var mp1 = new MapPoint(10, 40);
            var mp2 = new MapPoint(40, 30);
            var mp3 = new MapPoint(20, 20);
            var mp4 = new MapPoint(30, 10);
            var pc = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp4});
            MultiPoint expected = new MultiPoint(pc);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPointFromWkt3()
        {
            var wktMultiPoint2 = "MULTIPOINT ((10 40), 40 30, (20 20), 30 10)";
            MultiPoint actual = GeometryFromWKT.Parse(wktMultiPoint2) as MultiPoint;

            var mp1 = new MapPoint(10, 40);
            var mp2 = new MapPoint(40, 30);
            var mp3 = new MapPoint(20, 20);
            var mp4 = new MapPoint(30, 10);
            var pc = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp4});
            MultiPoint expected = new MultiPoint(pc);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiLineFromWkt()
        {
            var wktMultiLineString = "MULTILINESTRING ((10 10, 20 20, 10 40),(40 40, 30 30, 40 20, 30 10))";
            var actual = GeometryFromWKT.Parse(wktMultiLineString) as Polyline;

            var mp1 = new MapPoint(10, 10);
            var mp2 = new MapPoint(20, 20);
            var mp3 = new MapPoint(10, 40);

            var mp4 = new MapPoint(40, 40);
            var mp5 = new MapPoint(30, 30);
            var mp6 = new MapPoint(40, 20);
            var mp7 = new MapPoint(30, 10);
            var pc = new PointCollection(new List<MapPoint> {mp1, mp2, mp3});
            var pc2 = new PointCollection(new List<MapPoint> {mp4, mp5, mp6, mp7});

            var expected = new Polyline();
            expected.Paths = new ObservableCollection<PointCollection> {pc, pc2};

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPolyFromWkt()
        {
            var wktMultiPoly = "MULTIPOLYGON (((30 20, 10 40, 45 40, 30 20)),((15 5, 40 10, 10 20, 5 10, 15 5)))";
            var actual = GeometryFromWKT.Parse(wktMultiPoly) as Polygon;
            var expected = new Polygon();
            var mp1 = new MapPoint(30, 20);
            var mp2 = new MapPoint(10, 40);
            var mp3 = new MapPoint(45, 40);
            var pc = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp1});
            var mp6 = new MapPoint(15, 5);
            var mp7 = new MapPoint(40, 10);
            var mp8 = new MapPoint(10, 20);
            var mp9 = new MapPoint(5, 10);
            var pc2 = new PointCollection(new List<MapPoint> {mp6, mp7, mp8, mp9, mp6});

            var oc = new ObservableCollection<PointCollection>(new List<PointCollection> {pc, pc2});
            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPolyWithHoleFromWkt()
        {
            var wktMultiPolyWithHole =
                "MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)),((20 35, 45 20, 30 5, 10 10, 10 30, 20 35),(30 20, 20 25, 20 15, 30 20)))";
            var actual = GeometryFromWKT.Parse(wktMultiPolyWithHole) as Polygon;
            var expected = new Polygon();

            //(40 40, 20 45, 45 30, 40 40)
            var mp1 = new MapPoint(40, 40);
            var mp2 = new MapPoint(20, 45);
            var mp3 = new MapPoint(45, 30);
            var pc1 = new PointCollection(new List<MapPoint> {mp1, mp2, mp3, mp1});

            //(20 35, 45 20, 30 5, 10 10, 10 30, 20 35)
            var mp6 = new MapPoint(20, 35);
            var mp7 = new MapPoint(45, 20);
            var mp8 = new MapPoint(30, 5);
            var mp9 = new MapPoint(10, 10);
            var mp10 = new MapPoint(10, 30);
            var pc2 = new PointCollection(new List<MapPoint> {mp6, mp7, mp8, mp9, mp10, mp6});

            //(30 20, 20 25, 20 15, 30 20)
            var mp11 = new MapPoint(30, 20);
            var mp12 = new MapPoint(20, 25);
            var mp13 = new MapPoint(20, 15);
            var pc3 = new PointCollection(new List<MapPoint> {mp11, mp12, mp13, mp11});

            var oc = new ObservableCollection<PointCollection>(new List<PointCollection> {pc1, pc2, pc3});

            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }
    }
}