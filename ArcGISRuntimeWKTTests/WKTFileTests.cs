using System;
using System.IO;
using System.Reflection;
using System.Security;
using Esri.ArcGISRuntime.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: SecurityTransparent]
namespace UnitTestsSL
{
	[TestClass]
	public class WKTFileTests
	{
		[SecuritySafeCritical]
		[TestMethod]
		public void TestWKTfiles()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();

			string root = "UnitTestsSL.wktsForTesting.";
			string[] paths = new string[]
            {
                root + @"DataDoors187_aoi_wktOutputFile.txt",
                root + @"Huge_Point_Poly_test_wktOutputFile.txt",
                root + @"NYS_wktOutputFile.txt",
                root + @"zz_wktOutputFile.txt"
            };

			foreach (string path in paths)
			{
				Console.WriteLine(string.Format("Current WKT file: "), path);
				var resource = assembly.GetManifestResourceStream(path);

				using (StreamReader reader = new StreamReader(resource))
				{
					string line = reader.ReadToEnd();

					Console.WriteLine(string.Format("\tWKT:\n{0}", line));
					Geometry geom = ArcGISRuntimeWKT.Converters.WellKnownText.GeometryFromWKT.Parse(line);
					Polygon poly = geom as Polygon;
					string newWkt = ArcGISRuntimeWKT.Converters.WellKnownText.GeometryToWKT.Write(geom);
					Console.WriteLine(string.Format("\tA polygon was created from the above WKT. Then WKT was extracted from that object. THe new WKT is:\n{0}", newWkt));
					Geometry geom2 = ArcGISRuntimeWKT.Converters.WellKnownText.GeometryFromWKT.Parse(newWkt);
					Polygon poly2 = geom2 as Polygon;

					PolygonComparer.Compare(poly, poly2);
					PolygonComparer.Compare(geom, geom2);
					bool sameWkt = PolygonComparer.Compare(line, newWkt);
					if (sameWkt)
						Console.WriteLine("The WKT's are the same!!!!!");
					else
						Console.WriteLine("The WKT's are NOT the same. Sad day.");
				}
			}
		}
	}
}
