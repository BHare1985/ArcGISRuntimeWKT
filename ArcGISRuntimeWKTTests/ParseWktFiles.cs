

using System.Reflection;
using ArcGISRuntimeWKT;
using Esri.ArcGISRuntime.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcGISRuntimeWKTTests
{
	[TestClass]
	public class ParseWktFiles 
	{
		readonly Assembly _assembly = Assembly.GetExecutingAssembly();

		[TestMethod]
		[DataRow("DataDoors187_aoi_wktOutputFile.txt")]
		[DataRow("Huge_Point_Poly_test_wktOutputFile.txt")]
		[DataRow("NYS_wktOutputFile.txt")]
		[DataRow("zz_wktOutputFile.txt")]
		public void ParseWktFilesTest(string path)
		{
			var resource = _assembly.GetManifestResourceStream("ArcGISRuntimeWKTTests.wktsForTesting." + path);

			using (var reader = new System.IO.StreamReader(resource))
			{
				var wkt = reader.ReadToEnd();

				var geom = Parser.GeometryFromWkt(wkt);

				var poly = geom as Polygon;
				var newWkt = Parser.GeometryToWkt(geom);

				var geom2 = Parser.GeometryFromWkt(newWkt);
				var poly2 = geom2 as Polygon;

				PolygonComparer.Compare(poly, poly2);
				PolygonComparer.Compare(geom, geom2);
				PolygonComparer.Compare(wkt, newWkt);
			}
		}
	}
}