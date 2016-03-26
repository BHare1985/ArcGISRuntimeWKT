using System.IO;
using Esri.ArcGISRuntime.Geometry;

namespace ArcGISRuntimeWKT
{
    /// <summary>
    ///     convert Well Known Text (WKT) / Well Known Binary (WKB) to and from
    ///     <see cref="Geometry" />
    /// </summary>
    public static class Parser
    {
        /// <summary>
        ///     Converts a Well-known text representation to a <see cref="Geometry" />.
        /// </summary>
        /// <param name="wellKnownText">
        ///     A <see cref="Geometry" /> tagged text string ( see the OpenGIS Simple Features
        ///     Specification. )
        /// </param>
        /// <returns>
        ///     Returns a <see cref="Geometry" /> specified by wellKnownText.  Throws an exception if
        ///     there is a parsing
        ///     problem.
        /// </returns>
        public static Geometry GeometryFromWkt(string wellKnownText)
        {
            // throws a parsing exception is there is a problem.
            var reader = new StringReader(wellKnownText);
            return GeometryFromWkt(reader);
        }

        /// <summary>
        ///     Converts a Well-known Text representation to a <see cref="Geometry" />.
        /// </summary>
        /// <param name="reader">
        ///     A Reader which will return a Geometry Tagged Text
        ///     string (see the OpenGIS Simple Features Specification)
        /// </param>
        /// <returns>
        ///     Returns a <see cref="Geometry" /> read from StreamReader.
        ///     An exception will be thrown if there is a parsing problem.
        /// </returns>
        public static Geometry GeometryFromWkt(TextReader reader)
        {
            var tokenizer = new WktStreamTokenizer(reader);
            return ArcGISRuntimeWKT.GeometryFromWkt.ReadGeometryTaggedText(tokenizer);
        }


        /// <summary>
        ///     Converts a Geometry to its Well-known Text representation.
        /// </summary>
        /// <param name="geometry">A Geometry to write.</param>
        /// <returns>
        ///     A &lt;Geometry Tagged Text&gt; string (see the OpenGIS Simple
        ///     Features Specification)
        /// </returns>
        public static string GeometryToWkt(Geometry geometry)
        {
            var sw = new StringWriter();
            GeometryToWkt(geometry, sw);
            return sw.ToString();
        }

        /// <summary>
        ///     Converts a Geometry to its Well-known Text representation.
        /// </summary>
        /// <param name="geometry">A geometry to process.</param>
        /// <param name="writer">Stream to write out the geometry's text representation.</param>
        /// <remarks>
        ///     Geometry is written to the output stream as &lt;Gemoetry Tagged Text&gt; string (see the OpenGIS
        ///     Simple Features Specification).
        /// </remarks>
        public static void GeometryToWkt(Geometry geometry, StringWriter writer)
        {
            ArcGISRuntimeWKT.GeometryToWkt.AppendGeometryTaggedText(geometry, writer);
        }

        /// <summary>
        ///     Writes a geometry to a byte array using little endian byte encoding
        /// </summary>
        /// <param name="g">The geometry to write</param>
        /// <returns>WKB representation of the geometry</returns>
        public static byte[] GeometryToWkb(Geometry g)
        {
            return GeometryToWkb(g, WkbByteOrder.Ndr);
        }

        /// <summary>
        ///     Writes a geometry to a byte array using the specified encoding.
        /// </summary>
        /// <param name="g">The geometry to write</param>
        /// <param name="wkbByteOrder">Byte order</param>
        /// <returns>WKB representation of the geometry</returns>
        public static byte[] GeometryToWkb(Geometry g, WkbByteOrder wkbByteOrder)
        {
            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);

            //Write the byteorder format.
            bw.Write((byte) wkbByteOrder);

            //Write the type of this geometry
            ArcGISRuntimeWKT.GeometryToWkb.WriteType(g, bw, wkbByteOrder);

            //Write the geometry
            ArcGISRuntimeWKT.GeometryToWkb.WriteGeometry(g, bw, wkbByteOrder);

            return ms.ToArray();
        }

        /// <summary>
        ///     Creates a <see cref="Geometry" /> from the supplied byte[] containing the Well-known
        ///     Binary representation.
        /// </summary>
        /// <param name="bytes">byte[] containing the Well-known Binary representation.</param>
        /// <returns>A <see cref="Geometry" /> bases on the supplied Well-known Binary representation.</returns>
        public static Geometry GeometryFromWkb(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                using (var reader = new BinaryReader(ms))
                {
                    return ArcGISRuntimeWKT.GeometryFromWkb.Parse(reader);
                }
            }
        }

        /// <summary>
        ///     Creates a <see cref="Geometry" /> based on the Well-known binary representation.
        /// </summary>
        /// <param name="reader">
        ///     A <see cref="System.IO.BinaryReader">BinaryReader</see> used to read the Well-known binary
        ///     representation.
        /// </param>
        /// <returns>A <see cref="Geometry" /> based on the Well-known binary representation.</returns>
        public static Geometry GeometryFromWkb(BinaryReader reader)
        {
            return ArcGISRuntimeWKT.GeometryFromWkb.Parse(reader);
        }
    }
}