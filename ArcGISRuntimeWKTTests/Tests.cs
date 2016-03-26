using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArcGISRuntimeWKT.Converters.WellKnownText;
using Esri.ArcGISRuntime.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace UnitTestsSL
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void PointFromWKT()
        {
            string wktPoint = "POINT(25.48828125 -1.93359375)";
            MapPoint actual = GeometryFromWKT.Parse(wktPoint) as MapPoint;
            MapPoint expected = new MapPoint(25.48828125, -1.93359375);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void LineFromWKT()
        {
            string wktLine = "LINESTRING(19.51171875 -3.515625, 17.05078125 10.37109375, 15.64453125 -8.26171875, 19.51171875 -16.171875)";
            Polyline actual = GeometryFromWKT.Parse(wktLine) as Polyline;
            Polyline expected = new Polyline();

            MapPoint mp1 = new MapPoint(19.51171875, -3.515625);
            MapPoint mp2 = new MapPoint(17.05078125, 10.37109375);
            MapPoint mp3 = new MapPoint(15.64453125, -8.26171875);
            MapPoint mp4 = new MapPoint(19.51171875, -16.171875);
            PointCollection pc = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3, mp4 });
            ObservableCollection<PointCollection> oc = new ObservableCollection<PointCollection>() { pc };
            
            expected.Paths = oc;
            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void PolyFromWKT()
        {
            string wktPoly = "POLYGON((15.29296875 23.203125, 25.13671875 22.67578125, 19.51171875 16.34765625, 15.29296875 23.203125))";
            Polygon actual = GeometryFromWKT.Parse(wktPoly) as Polygon;
            Polygon expected = new Polygon();
            MapPoint mp1 = new MapPoint(15.29296875, 23.203125);
            MapPoint mp2 = new MapPoint(25.13671875, 22.67578125);
            MapPoint mp3 = new MapPoint(19.51171875, 16.34765625);
            MapPoint mp4 = new MapPoint(15.29296875, 23.203125);
            MapPoint mp5 = new MapPoint(15.29296875, 23.203125);
            PointCollection pc = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3, mp4, mp5 });
            ObservableCollection<PointCollection> oc = new ObservableCollection<PointCollection>(new List<PointCollection>() { pc });
            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void PolyWithHoleFromWKT()
        {
            string wktPolyWithHole = "POLYGON((3.8671875 30.5859375, 35.33203125 23.90625, 20.390625 -2.109375, -6.6796875 8.4375, 3.8671875 30.5859375),(15.29296875 23.203125, 25.13671875 22.67578125, 19.51171875 16.34765625, 15.29296875 23.203125))";
            Polygon actual = GeometryFromWKT.Parse(wktPolyWithHole) as Polygon;

            MapPoint mp1 = new MapPoint(3.8671875, 30.5859375);
            MapPoint mp2 = new MapPoint(35.33203125, 23.90625);
            MapPoint mp3 = new MapPoint(20.390625, -2.109375);
            MapPoint mp4 = new MapPoint(-6.6796875, 8.4375);
            MapPoint mp5 = new MapPoint(3.8671875, 30.5859375);
            PointCollection pc1 = new PointCollection(new List<MapPoint>() {mp1, mp2, mp3, mp4, mp5});
            
            MapPoint mp6 = new MapPoint(15.29296875, 23.203125);
            MapPoint mp7 = new MapPoint(25.13671875, 22.67578125);
            MapPoint mp8 = new MapPoint(19.51171875, 16.34765625);
            MapPoint mp9 = new MapPoint(15.29296875, 23.203125);
            PointCollection pc2 = new PointCollection(new List<MapPoint>() { mp6, mp7, mp8, mp9 });

            ObservableCollection<PointCollection> oc = new ObservableCollection<PointCollection>(new List<PointCollection>() { pc1, pc2 });
            Polygon expected = new Polygon();
            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPointFromWKT1()
        {
            string wktMultiPoint1 = "MULTIPOINT ((10 40), (40 30), (20 20), (30 10))";
            MultiPoint actual = GeometryFromWKT.Parse(wktMultiPoint1) as MultiPoint;

            MapPoint mp1 = new MapPoint(10, 40);
            MapPoint mp2 = new MapPoint(40, 30);
            MapPoint mp3 = new MapPoint(20, 20);
            MapPoint mp4 = new MapPoint(30, 10);
            PointCollection pc = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3, mp4 });
            MultiPoint expected = new MultiPoint(pc);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPointFromWKT2()
        {
            string wktMultiPoint2 = "MULTIPOINT (10 40, 40 30, 20 20, 30 10)";
            MultiPoint actual = GeometryFromWKT.Parse(wktMultiPoint2) as MultiPoint;

            MapPoint mp1 = new MapPoint(10, 40);
            MapPoint mp2 = new MapPoint(40, 30);
            MapPoint mp3 = new MapPoint(20, 20);
            MapPoint mp4 = new MapPoint(30, 10);
            PointCollection pc = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3, mp4 });
            MultiPoint expected = new MultiPoint(pc);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPointFromWKT3()
        {
            string wktMultiPoint2 = "MULTIPOINT ((10 40), 40 30, (20 20), 30 10)";
            MultiPoint actual = GeometryFromWKT.Parse(wktMultiPoint2) as MultiPoint;

            MapPoint mp1 = new MapPoint(10, 40);
            MapPoint mp2 = new MapPoint(40, 30);
            MapPoint mp3 = new MapPoint(20, 20);
            MapPoint mp4 = new MapPoint(30, 10);
            PointCollection pc = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3, mp4 });
            MultiPoint expected = new MultiPoint(pc);

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiLineFromWKT()
        {
            string wktMultiLineString = "MULTILINESTRING ((10 10, 20 20, 10 40),(40 40, 30 30, 40 20, 30 10))";
            Polyline actual = GeometryFromWKT.Parse(wktMultiLineString) as Polyline;

            MapPoint mp1 = new MapPoint(10, 10);
            MapPoint mp2 = new MapPoint(20, 20);
            MapPoint mp3 = new MapPoint(10, 40);

            MapPoint mp4 = new MapPoint(40, 40);
            MapPoint mp5 = new MapPoint(30, 30);
            MapPoint mp6 = new MapPoint(40, 20);
            MapPoint mp7 = new MapPoint(30, 10);
            PointCollection pc = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3 });
            PointCollection pc2 = new PointCollection(new List<MapPoint>() { mp4, mp5, mp6, mp7 });

            Polyline expected = new Polyline();
            expected.Paths = new ObservableCollection<PointCollection>() { pc, pc2 };

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPolyFromWKT()
        {
            string wktMultiPoly = "MULTIPOLYGON (((30 20, 10 40, 45 40, 30 20)),((15 5, 40 10, 10 20, 5 10, 15 5)))";
            Polygon actual = GeometryFromWKT.Parse(wktMultiPoly) as Polygon;
            Polygon expected = new Polygon();
            MapPoint mp1 = new MapPoint(30, 20);
            MapPoint mp2 = new MapPoint(10, 40);
            MapPoint mp3 = new MapPoint(45, 40);
            PointCollection pc = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3, mp1 });
            MapPoint mp6 = new MapPoint(15, 5);
            MapPoint mp7 = new MapPoint(40, 10);
            MapPoint mp8 = new MapPoint(10, 20);
            MapPoint mp9 = new MapPoint(5, 10);
            PointCollection pc2 = new PointCollection(new List<MapPoint>() { mp6, mp7, mp8, mp9, mp6 });

            ObservableCollection<PointCollection> oc = new ObservableCollection<PointCollection>(new List<PointCollection>() { pc, pc2 });
            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }

        [TestMethod]
        public void MultiPolyWithHoleFromWKT()
        {
            string wktMultiPolyWithHole = "MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)),((20 35, 45 20, 30 5, 10 10, 10 30, 20 35),(30 20, 20 25, 20 15, 30 20)))";
            Polygon actual = GeometryFromWKT.Parse(wktMultiPolyWithHole) as Polygon;
            Polygon expected = new Polygon();

            //(40 40, 20 45, 45 30, 40 40)
            MapPoint mp1 = new MapPoint(40, 40);
            MapPoint mp2 = new MapPoint(20, 45);
            MapPoint mp3 = new MapPoint(45, 30);
            PointCollection pc1 = new PointCollection(new List<MapPoint>() { mp1, mp2, mp3, mp1 });
            
            //(20 35, 45 20, 30 5, 10 10, 10 30, 20 35)
            MapPoint mp6 = new MapPoint(20, 35);
            MapPoint mp7 = new MapPoint(45, 20);
            MapPoint mp8 = new MapPoint(30, 5);
            MapPoint mp9 = new MapPoint(10, 10);
            MapPoint mp10 = new MapPoint(10, 30);
            PointCollection pc2 = new PointCollection(new List<MapPoint>() { mp6, mp7, mp8, mp9, mp10, mp6 });

            //(30 20, 20 25, 20 15, 30 20)
            MapPoint mp11 = new MapPoint(30, 20);
            MapPoint mp12 = new MapPoint(20, 25);
            MapPoint mp13 = new MapPoint(20, 15);
            PointCollection pc3 = new PointCollection(new List<MapPoint>() { mp11, mp12, mp13, mp11 });

            ObservableCollection<PointCollection> oc = new ObservableCollection<PointCollection>(new List<PointCollection>() { pc1, pc2, pc3 });

            expected.Rings = oc;

            PolygonComparer.Compare(actual, expected);
        }
    }
}