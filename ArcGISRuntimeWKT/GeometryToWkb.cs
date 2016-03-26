using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArcGISRuntimeWKT.Utilities;
using Esri.ArcGISRuntime.Geometry;

namespace ArcGISRuntimeWKT
{
    /// <summary>
    ///     Converts a <see cref="Geometry" /> instance to a Well-known Binary string representation.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The Well-known Binary Representation for <see cref="Geometry" /> (WKBGeometry) provides a portable
    ///         representation of a <see cref="Geometry" /> value as a contiguous stream of bytes. It permits
    ///         <see cref="Geometry" />
    ///         values to be exchanged between an ODBC client and an SQL database in binary form.
    ///     </para>
    ///     <para>
    ///         The Well-known Binary Representation for <see cref="Geometry" /> is obtained by serializing a
    ///         <see cref="Geometry" />
    ///         instance as a sequence of numeric types drawn from the set {Unsigned Integer, Double} and
    ///         then serializing each numeric type as a sequence of bytes using one of two well defined,
    ///         standard, binary representations for numeric types (NDR, XDR). The specific binary encoding
    ///         (NDR or XDR) used for a geometry byte stream is described by a one byte tag that precedes
    ///         the serialized bytes. The only difference between the two encodings of geometry is one of
    ///         byte order, the XDR encoding is Big Endian, the NDR encoding is Little Endian.
    ///     </para>
    /// </remarks>
    public class GeometryToWkb
    {
        /// <summary>
        ///     Writes an unsigned integer to the binarywriter using the specified encoding
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="writer">Binary Writer</param>
        /// <param name="byteOrder">byteorder</param>
        private static void WriteUInt32(uint value, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                writer.Write(BitConverter.ToUInt32(bytes, 0));
            }
            else
            {
                writer.Write(value);
            }
        }

        /// <summary>
        ///     Writes a double to the binarywriter using the specified encoding
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="writer">Binary Writer</param>
        /// <param name="byteOrder">byteorder</param>
        private static void WriteDouble(double value, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                writer.Write(BitConverter.ToDouble(bytes, 0));
            }
            else
            {
                writer.Write(value);
            }
        }

        #region Methods

        /// <summary>
        ///     Writes the type number for this geometry.
        /// </summary>
        /// <param name="geometry">The geometry to determine the type of.</param>
        /// <param name="bWriter">Binary Writer</param>
        /// <param name="byteorder">Byte order</param>
        internal static void WriteType(Geometry geometry, BinaryWriter bWriter, WkbByteOrder byteorder)
        {
            //Determine the type of the geometry.
            switch (geometry.GetType().FullName)
            {
                //Points are type 1.
                case "SharpMap.Geometries.Point":
                    WriteUInt32((uint) WkbGeometryType.WkbPoint, bWriter, byteorder);
                    break;
                //Linestrings are type 2.
                case "SharpMap.Geometries.LineString":
                    WriteUInt32((uint) WkbGeometryType.WkbLineString, bWriter, byteorder);
                    break;
                //Polygons are type 3.
                case "SharpMap.Geometries.Polygon":
                    WriteUInt32((uint) WkbGeometryType.WkbPolygon, bWriter, byteorder);
                    break;
                //Mulitpoints are type 4.
                case "SharpMap.Geometries.MultiPoint":
                    WriteUInt32((uint) WkbGeometryType.WkbMultiPoint, bWriter, byteorder);
                    break;
                //Multilinestrings are type 5.
                case "SharpMap.Geometries.MultiLineString":
                    WriteUInt32((uint) WkbGeometryType.WkbMultiLineString, bWriter, byteorder);
                    break;
                //Multipolygons are type 6.
                case "SharpMap.Geometries.MultiPolygon":
                    WriteUInt32((uint) WkbGeometryType.WkbMultiPolygon, bWriter, byteorder);
                    break;
                //Geometrycollections are type 7.
                case "ESRI.ArcGIS.Client.GeometryCollection":
                    WriteUInt32((uint) WkbGeometryType.WkbGeometryCollection, bWriter, byteorder);
                    break;
                //If the type is not of the above 7 throw an exception.
                default:
                    throw new ArgumentException("Invalid Geometry Type");
            }
        }

        /// <summary>
        ///     Writes the geometry to the binary writer.
        /// </summary>
        /// <param name="geometry">The geometry to be written.</param>
        /// <param name="bWriter"></param>
        /// <param name="byteorder">Byte order</param>
        internal static void WriteGeometry(Geometry geometry, BinaryWriter bWriter, WkbByteOrder byteorder)
        {
            switch (geometry.GetType().FullName)
            {
                //Write the point.
                case "SharpMap.Geometries.Point":
                    WritePoint((MapPoint) geometry, bWriter, byteorder);
                    break;
                case "SharpMap.Geometries.LineString":
                    var ls = (Polyline) geometry;
                    WriteLineString(ls.Parts[0].GetPoints(), bWriter, byteorder);
                    break;
                case "SharpMap.Geometries.Polygon":
                    WriteMultiPolygon((Polygon) geometry, bWriter, byteorder);
                    break;
                //Write the Multipoint.
                case "SharpMap.Geometries.MultiPoint":
                    throw new NotImplementedException();
                //Write the Multilinestring.
                case "SharpMap.Geometries.MultiLineString":
                    WriteMultiLineString((Polyline) geometry, bWriter, byteorder);
                    break;
                //Write the Multipolygon.
                case "SharpMap.Geometries.MultiPolygon":
                    WriteMultiPolygon((Polygon) geometry, bWriter, byteorder);
                    break;
                //Write the Geometrycollection.
                //case "ESRI.ArcGIS.Client.GeometryCollection":
                //    WriteGeometryCollection((GeometryCollection) geometry, bWriter, byteorder);
                //    break;
                //If the type is not of the above 7 throw an exception.
                default:
                    throw new ArgumentException("Invalid Geometry Type");
            }
        }

        /// <summary>
        ///     Writes a point.
        /// </summary>
        /// <param name="point">The point to be written.</param>
        /// <param name="bWriter">Stream to write to.</param>
        /// <param name="byteorder">Byte order</param>
        private static void WritePoint(MapPoint point, BinaryWriter bWriter, WkbByteOrder byteorder)
        {
            //Write the x coordinate.
            WriteDouble(point.X, bWriter, byteorder);
            //Write the y coordinate.
            WriteDouble(point.Y, bWriter, byteorder);
        }


        /// <summary>
        ///     Writes a linestring.
        /// </summary>
        /// <param name="ls">The linestring to be written.</param>
        /// <param name="bWriter">Stream to write to.</param>
        /// <param name="byteorder">Byte order</param>
        private static void WriteLineString(IEnumerable<MapPoint> ls, BinaryWriter bWriter, WkbByteOrder byteorder)
        {
            //Write the number of points in this linestring.
            WriteUInt32((uint) ls.Count(), bWriter, byteorder);

            //Loop on each vertices.
            foreach (var p in ls)
            {
                WritePoint(p, bWriter, byteorder);
            }
        }


        /// <summary>
        ///     Writes a polygon.
        /// </summary>
        /// <param name="poly">The polygon to be written.</param>
        /// <param name="bWriter">Stream to write to.</param>
        /// <param name="byteorder">Byte order</param>
        private static void WritePolygon(Polygon poly, BinaryWriter bWriter, WkbByteOrder byteorder)
        {
            //Get the number of rings in this polygon.
            var numRings = poly.Parts.Count;

            //Write the number of rings to the stream (add one for the shell)
            WriteUInt32((uint) numRings, bWriter, byteorder);

            //Loop on the number of rings - agnostic of whether its the shell.
            foreach (var pc in poly.Parts)
            {
                //Write the (lineString)LinearRing.
                WriteLineString(pc.GetPoints(), bWriter, byteorder);
            }
        }

        /// <summary>
        ///     Writes a multilinestring.
        /// </summary>
        /// <param name="mls">The multilinestring to be written.</param>
        /// <param name="bWriter">Stream to write to.</param>
        /// <param name="byteorder">Byte order</param>
        private static void WriteMultiLineString(Polyline mls, BinaryWriter bWriter, WkbByteOrder byteorder)
        {
            //Write the number of linestrings.
            WriteUInt32((uint) mls.Parts.Count, bWriter, byteorder);

            //Loop on the number of linestrings.
            foreach (var ls in mls.Parts.GetPartsAsPoints())
            {
                //Write LineString Header
                bWriter.Write((byte) byteorder);
                WriteUInt32((uint) WkbGeometryType.WkbLineString, bWriter, byteorder);
                //Write each linestring.
                WriteLineString(ls, bWriter, byteorder);
            }
        }

        /// <summary>
        ///     Writes a multipolygon.
        /// </summary>
        /// <param name="mp">The mulitpolygon to be written.</param>
        /// <param name="bWriter">Stream to write to.</param>
        /// <param name="byteorder">Byte order</param>
        private static void WriteMultiPolygon(Polygon mp, BinaryWriter bWriter, WkbByteOrder byteorder)
        {
            //Write the number of polygons.
            WriteUInt32((uint) mp.Parts.Count, bWriter, byteorder);

            //Loop on the number of polygons.
            for (var i = 0; i < mp.Parts.Count; i++)
            {
                var poly = mp.Parts[i];

                //create a polygon and remember its orientation
                var singlePolygon = new PolygonBuilder(poly);

                var exteriorRingOrientation = Algorithms.IsCcw(poly);

                //Add any interior rings
                while (++i < mp.Parts.Count && Algorithms.IsCcw(mp.Parts[i]) != exteriorRingOrientation)
                {
                    singlePolygon.AddPart(mp.Parts[i]);
                }

                //Write polygon header
                bWriter.Write((byte) byteorder);
                WriteUInt32((uint) WkbGeometryType.WkbPolygon, bWriter, byteorder);
                //Write each polygon.
                WritePolygon(singlePolygon.ToGeometry(), bWriter, byteorder);
            }
        }

        #endregion
    }
}