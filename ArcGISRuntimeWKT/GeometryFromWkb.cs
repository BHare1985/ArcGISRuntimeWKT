using System;
using System.Diagnostics;
using System.IO;
using Esri.ArcGISRuntime.Geometry;

namespace ArcGISRuntimeWKT
{
    /// <summary>
    ///     Converts Well-known Binary representations to a <see cref="Geometry" /> instance.
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
    public class GeometryFromWkb
    {
        /// <summary>
        ///     Creates a <see cref="Geometry" /> based on the Well-known binary representation.
        /// </summary>
        /// <param name="reader">
        ///     A <see cref="System.IO.BinaryReader">BinaryReader</see> used to read the Well-known binary
        ///     representation.
        /// </param>
        /// <returns>A <see cref="Geometry" /> based on the Well-known binary representation.</returns>
        internal static Geometry Parse(BinaryReader reader)
        {
            // Get the first Byte in the array. This specifies if the WKB is in
            // XDR (big-endian) format of NDR (little-endian) format.
            var byteOrder = reader.ReadByte();

            // Get the type of this geometry.
            var type = ReadUInt32(reader, (WkbByteOrder) byteOrder);

            switch ((WkbGeometryType) type)
            {
                case WkbGeometryType.WkbPoint:
                    return CreateWkbPoint(reader, (WkbByteOrder) byteOrder);

                case WkbGeometryType.WkbLineString:
                    return CreateWkbLineString(reader, (WkbByteOrder) byteOrder);

                case WkbGeometryType.WkbPolygon:
                    return CreateWkbPolygon(reader, (WkbByteOrder) byteOrder);

                case WkbGeometryType.WkbMultiPoint:
                    throw new NotImplementedException();

                case WkbGeometryType.WkbMultiLineString:
                    return CreateWkbMultiLineString(reader, (WkbByteOrder) byteOrder);

                case WkbGeometryType.WkbMultiPolygon:
                    return CreateWkbMultiPolygon(reader, (WkbByteOrder) byteOrder);

                //case WKBGeometryType.wkbGeometryCollection:
                //    return CreateWKBGeometryCollection(reader, (WkbByteOrder) byteOrder);

                default:
                    if (!Enum.IsDefined(typeof (WkbGeometryType), type))
                    {
                        throw new ArgumentException("Geometry type not recognized");
                    }
                    throw new NotSupportedException("Geometry type '" + type + "' not supported");
            }
        }

        private static MapPoint CreateWkbPoint(BinaryReader reader, WkbByteOrder byteOrder)
        {
            // Create and return the point.
            return new MapPoint(ReadDouble(reader, byteOrder), ReadDouble(reader, byteOrder));
        }

        private static MapPoint[] ReadCoordinates(BinaryReader reader, WkbByteOrder byteOrder)
        {
            // Get the number of points in this linestring.
            var numPoints = (int) ReadUInt32(reader, byteOrder);

            // Create a new array of coordinates.
            var coords = new MapPoint[numPoints];

            // Loop on the number of points in the ring.
            for (var i = 0; i < numPoints; i++)
            {
                // Add the coordinate.
                coords[i] = new MapPoint(ReadDouble(reader, byteOrder), ReadDouble(reader, byteOrder));
            }
            return coords;
        }

        private static Polyline CreateWkbLineString(BinaryReader reader, WkbByteOrder byteOrder)
        {
            var arrPoint = ReadCoordinates(reader, byteOrder);
            return new Polyline(arrPoint);
        }

        private static PointCollection CreateWkbLinearRing(BinaryReader reader, WkbByteOrder byteOrder)
        {
            var l = new PointCollection();
            foreach (var mapPoint in ReadCoordinates(reader, byteOrder))
            {
                l.Add(mapPoint);
            }

            //if polygon isn't closed, add the first point to the end (this shouldn't occur for correct WKB data)
            if (Math.Abs(l[0].X - l[l.Count - 1].X) > 0.0 ||
                Math.Abs(l[0].Y - l[l.Count - 1].Y) > 0.0)
            {
                l.Add(new MapPoint(l[0].X, l[0].Y));
            }
            return l;
        }

        private static Polygon CreateWkbPolygon(BinaryReader reader, WkbByteOrder byteOrder)
        {
            // Get the Number of rings in this Polygon.
            var numRings = (int) ReadUInt32(reader, byteOrder);

            Debug.Assert(numRings >= 1, "Number of rings in polygon must be 1 or more.");

            var polygonBuilder = new PolygonBuilder(CreateWkbLinearRing(reader, byteOrder));

            // Create a new array of linearrings for the interior rings.
            for (var i = 0; i < numRings - 1; i++)
            {
                polygonBuilder.AddPart(CreateWkbLinearRing(reader, byteOrder));
            }
            // Create and return the Poylgon.
            return polygonBuilder.ToGeometry();
        }

        private static Polyline CreateWkbMultiLineString(BinaryReader reader, WkbByteOrder byteOrder)
        {
            // Get the number of linestrings in this multilinestring.
            var numLineStrings = (int) ReadUInt32(reader, byteOrder);

            if (numLineStrings < 1)
            {
                throw new Exception("Could not create linestring");
            }

            // Read linestring header
            reader.ReadByte();
            ReadUInt32(reader, byteOrder);

            var mline = new PolylineBuilder(CreateWkbLineString(reader, byteOrder));

            // Loop on the number of linestrings.
            for (var i = 1; i < numLineStrings; i++)
            {
                // Read linestring header
                reader.ReadByte();
                ReadUInt32(reader, byteOrder);

                mline.AddParts(CreateWkbLineString(reader, byteOrder).Parts);
            }

            // Create and return the MultiLineString.
            return mline.ToGeometry();
        }

        private static Polygon CreateWkbMultiPolygon(BinaryReader reader, WkbByteOrder byteOrder)
        {
            // Get the number of Polygons.
            var numPolygons = (int) ReadUInt32(reader, byteOrder);


            if (numPolygons < 1)
            {
                throw new Exception("Could not create MultiPolygon");
            }

            // Read linestring header
            reader.ReadByte();
            ReadUInt32(reader, byteOrder);


            // Create a new array for the Polygons.
            var polygons = new PolygonBuilder(CreateWkbPolygon(reader, byteOrder));

            // Loop on the number of polygons.
            for (var i = 1; i < numPolygons; i++)
            {
                // read polygon header
                reader.ReadByte();
                ReadUInt32(reader, byteOrder);

                // TODO: Validate type

                polygons.AddParts(CreateWkbPolygon(reader, byteOrder).Parts);
            }

            //Create and return the MultiPolygon.
            return polygons.ToGeometry();
        }

        private static uint ReadUInt32(BinaryReader reader, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                var bytes = BitConverter.GetBytes(reader.ReadUInt32());
                Array.Reverse(bytes);
                return BitConverter.ToUInt32(bytes, 0);
            }
            if (byteOrder == WkbByteOrder.Ndr)
            {
                return reader.ReadUInt32();
            }
            throw new ArgumentException("Byte order not recognized");
        }

        private static double ReadDouble(BinaryReader reader, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                var bytes = BitConverter.GetBytes(reader.ReadDouble());
                Array.Reverse(bytes);
                return BitConverter.ToDouble(bytes, 0);
            }
            if (byteOrder == WkbByteOrder.Ndr)
            {
                return reader.ReadDouble();
            }
            throw new ArgumentException("Byte order not recognized");
        }
    }
}