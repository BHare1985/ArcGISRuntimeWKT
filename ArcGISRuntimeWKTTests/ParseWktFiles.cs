using System;
using System.IO;
using System.Reflection;
using Esri.ArcGISRuntime.Geometry;
using NUnit.Framework;
using TDMS.Library.Esri.Helpers.Wkt.Converters.WellKnownText;

namespace TDMS.Library.Test.Esri.Wkt
{
	[TestFixture]
	[Category("BuildIgnore")]
	public class ParseWktFiles : EsriBaseTest
	{
		readonly Assembly _assembly = Assembly.GetExecutingAssembly();

		[Test]
		[TestCase("DataDoors187_aoi_wktOutputFile.txt")]
		[TestCase("Huge_Point_Poly_test_wktOutputFile.txt")]
		[TestCase("NYS_wktOutputFile.txt")]
		[TestCase("zz_wktOutputFile.txt")]
		[TestCase("wicket_default.txt")]
		public void ParseWktFilesTest(string path)
		{
			var resource = _assembly.GetManifestResourceStream("TDMS.Library.Test.Esri.Wkt.wktsForTesting." + path);

			using (var reader = new StreamReader(resource))
			{
				var wkt = reader.ReadToEnd();

				var geom = GeometryFromWkt.Parse(wkt);

				var poly = geom as Polygon;
				var newWkt = GeometryToWkt.Write(geom);

				var geom2 = GeometryFromWkt.Parse(newWkt);
				var poly2 = geom2 as Polygon;

				PolygonComparer.Compare(poly, poly2);
				PolygonComparer.Compare(geom, geom2);
				PolygonComparer.Compare(wkt, newWkt);
			}
		}
	}
}