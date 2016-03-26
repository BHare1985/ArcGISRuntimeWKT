// Copyright 2005, 2006 - Morten Nielsen (www.iter.dk)
//
// This file is part of SharpMap.
// SharpMap is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// SharpMap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

// SOURCECODE IS MODIFIED FROM ANOTHER WORK AND IS ORIGINALLY BASED ON GeoTools.NET:
/*
 *  Copyright (C) 2002 Urban Science Applications, Inc. 
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ArcGISRuntimeWKT.Utilities;
using Esri.ArcGISRuntime.Geometry;

namespace ArcGISRuntimeWKT.Converters.WellKnownText
{
    /// <summary>
    ///     Outputs the textual representation of a <see cref="Geometry" /> instance.
    /// </summary>
    /// <remarks>
    ///     <para>The Well-Known Text (WKT) representation of Geometry is designed to exchange geometry data in ASCII form.</para>
    ///     Examples of WKT representations of geometry objects are:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Geometry </term><description>WKT Representation</description>
    ///         </listheader>
    ///         <item>
    ///             <term>A Point</term>
    ///             <description>POINT(15 20)<br /> Note that point coordinates are specified with no separating comma.</description>
    ///         </item>
    ///         <item>
    ///             <term>A LineString with four points:</term>
    ///             <description>LINESTRING(0 0, 10 10, 20 25, 50 60)</description>
    ///         </item>
    ///         <item>
    ///             <term>A Polygon with one exterior ring and one interior ring:</term>
    ///             <description>POLYGON((0 0,10 0,10 10,0 10,0 0),(5 5,7 5,7 7,5 7, 5 5))</description>
    ///         </item>
    ///         <item>
    ///             <term>A MultiPoint with three Point values:</term>
    ///             <description>MULTIPOINT(0 0, 20 20, 60 60)</description>
    ///         </item>
    ///         <item>
    ///             <term>A MultiLineString with two LineString values:</term>
    ///             <description>MULTILINESTRING((10 10, 20 20), (15 15, 30 15))</description>
    ///         </item>
    ///         <item>
    ///             <term>A MultiPolygon with two Polygon values:</term>
    ///             <description>MULTIPOLYGON(((0 0,10 0,10 10,0 10,0 0)),((5 5,7 5,7 7,5 7, 5 5)))</description>
    ///         </item>
    ///         <item>
    ///             <term>A GeometryCollection consisting of two Point values and one LineString:</term>
    ///             <description>GEOMETRYCOLLECTION(POINT(10 10), POINT(30 30), LINESTRING(15 15, 20 20))</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public class GeometryToWkt
    {
        #region Methods

        /// <summary>
        ///     Converts a Geometry to its Well-known Text representation.
        /// </summary>
        /// <param name="geometry">A Geometry to write.</param>
        /// <returns>
        ///     A &lt;Geometry Tagged Text&gt; string (see the OpenGIS Simple
        ///     Features Specification)
        /// </returns>
        public static string Write(Geometry geometry)
        {
            var sw = new StringWriter();
            Write(geometry, sw);
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
        public static void Write(Geometry geometry, StringWriter writer)
        {
            AppendGeometryTaggedText(geometry, writer);
        }

        /// <summary>
        ///     Converts a Geometry to &lt;Geometry Tagged Text &gt; format, then Appends it to the writer.
        /// </summary>
        /// <param name="geometry">The Geometry to process.</param>
        /// <param name="writer">The output stream to Append to.</param>
        private static void AppendGeometryTaggedText(Geometry geometry, StringWriter writer)
        {
            if (geometry == null)
            {
                throw new NullReferenceException("Cannot write Well-Known Text: geometry was null");
            }

            if (geometry is MapPoint)
            {
                var point = (MapPoint) geometry;
                AppendPointTaggedText(point, writer);
            }
            else if (geometry is Polyline && ((Polyline) geometry).Parts.GetPartsAsPoints().Count(Algorithms.IsCcw) == 1)
            {
                AppendLineStringTaggedText((Polyline) geometry, writer);
            }
            else if (geometry is Envelope)
            {
                AppendEnvelope((Envelope) geometry, writer);
            }
            else if (geometry is Polygon && OnlyOneExteriorRing((Polygon) geometry))
            {
                AppendPolygonTaggedText((Polygon) geometry, writer);
            }
            else if (geometry is Polyline)
            {
                AppendMultiLineStringTaggedText((Polyline) geometry, writer);
            }
            else if (geometry is Polygon)
            {
                AppendMultiPolygonTaggedText((Polygon) geometry, writer);
            }
            //else if (geometry is GeometryCollection)
            //	AppendGeometryCollectionTaggedText(geometry as List<Geometry>, writer);
            else
            {
                throw new NotSupportedException("Unsupported Geometry implementation:" + geometry.GetType().Name);
            }
        }

        /// <summary>
        ///     Checks whether the first ring is CW or CCW, and returns true if there is only one ring in this direction.
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        private static bool OnlyOneExteriorRing(Polygon polygon)
        {
            var exteriorCcw = false;
            if (polygon.Parts.Count > 0)
            {
                exteriorCcw = Algorithms.IsCcw(polygon.Parts[0]);
            }
            var count = 0;
            foreach (var ring in polygon.Parts)
            {
                if (Algorithms.IsCcw(ring) == exteriorCcw)
                {
                    count++;
                }
            }

            return count == 1;
        }

        private static void AppendEnvelope(Envelope envelope, StringWriter writer)
        {
            writer.Write(string.Format(CultureInfo.InvariantCulture,
                "POLYGON(({0} {1}, {2} {1}, {2} {3}, {0} {3}, {0} {1}))", envelope.XMin, envelope.YMin, envelope.XMax,
                envelope.YMax));
        }

        /// <summary>
        ///     Converts a Coordinate to &lt;Point Tagged Text&gt; format,
        ///     then Appends it to the writer.
        /// </summary>
        /// <param name="coordinate">the <code>Coordinate</code> to process</param>
        /// <param name="writer">the output writer to Append to</param>
        private static void AppendPointTaggedText(MapPoint coordinate, StringWriter writer)
        {
            writer.Write("POINT ");
            AppendPointText(coordinate, writer);
        }

        /// <summary>
        ///     Converts a LineString to LineString tagged text format,
        /// </summary>
        /// <param name="lineString">The LineString to process.</param>
        /// <param name="writer">The output stream writer to Append to.</param>
        private static void AppendLineStringTaggedText(Polyline lineString, StringWriter writer)
        {
            writer.Write("LINESTRING ");
            AppendLineStringText(lineString.Parts[0].GetPoints().ToList(), writer);
        }

        /// <summary>
        ///     Converts a Polygon to &lt;Polygon Tagged Text&gt; format,
        ///     then Appends it to the writer.
        /// </summary>
        /// <param name="polygon">Th Polygon to process.</param>
        /// <param name="writer">The stream writer to Append to.</param>
        private static void AppendPolygonTaggedText(Polygon polygon, StringWriter writer)
        {
            writer.Write("POLYGON ");
            AppendPolygonText(polygon, writer);
        }

        /// <summary>
        ///     Converts a MultiLineString to &lt;MultiLineString Tagged
        ///     Text&gt; format, then Appends it to the writer.
        /// </summary>
        /// <param name="multiLineString">The MultiLineString to process</param>
        /// <param name="writer">The output stream writer to Append to.</param>
        private static void AppendMultiLineStringTaggedText(Polyline multiLineString, StringWriter writer)
        {
            writer.Write("MULTILINESTRING ");
            AppendMultiLineStringText(multiLineString, writer);
        }

        /// <summary>
        ///     Converts a MultiPolygon to &lt;MultiPolygon Tagged
        ///     Text&gt; format, then Appends it to the writer.
        /// </summary>
        /// <param name="multiPolygon">The MultiPolygon to process</param>
        /// <param name="writer">The output stream writer to Append to.</param>
        private static void AppendMultiPolygonTaggedText(Polygon multiPolygon, StringWriter writer)
        {
            writer.Write("MULTIPOLYGON ");
            AppendMultiPolygonText(multiPolygon, writer);
        }


        /// <summary>
        ///     Converts a Coordinate to Point Text format then Appends it to the writer.
        /// </summary>
        /// <param name="coordinate">The Coordinate to process.</param>
        /// <param name="writer">The output stream writer to Append to.</param>
        private static void AppendPointText(MapPoint coordinate, StringWriter writer)
        {
            if (coordinate == null)
            {
                writer.Write("EMPTY");
            }
            else
            {
                writer.Write("(");
                AppendCoordinate(coordinate, writer);
                writer.Write(")");
            }
        }

        /// <summary>
        ///     Converts a Coordinate to &lt;Point&gt; format, then Appends
        ///     it to the writer.
        /// </summary>
        /// <param name="coordinate">The Coordinate to process.</param>
        /// <param name="writer">The output writer to Append to.</param>
        private static void AppendCoordinate(MapPoint coordinate, StringWriter writer)
        {
            writer.Write(WriteNumber(coordinate.X) + " " + WriteNumber(coordinate.Y));
            //for (uint i = 0; i < 2; i++) writer.Write(WriteNumber(coordinate[i]) + (i < 2 - 1 ? " " : ""));
        }

        /// <summary>
        ///     Converts a double to a string, not in scientific notation.
        /// </summary>
        /// <param name="d">The double to convert.</param>
        /// <returns>The double as a string, not in scientific notation.</returns>
        private static string WriteNumber(double d)
        {
            return d.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Converts a LineString to &lt;LineString Text&gt; format, then
        ///     Appends it to the writer.
        /// </summary>
        /// <param name="lineString">The LineString to process.</param>
        /// <param name="writer">The output stream to Append to.</param>
        private static void AppendLineStringText(IReadOnlyList<MapPoint> lineString, StringWriter writer)
        {
            if (lineString == null || lineString.Count == 0)
            {
                writer.Write("EMPTY");
            }
            else
            {
                writer.Write("(");
                for (var i = 0; i < lineString.Count; i++)
                {
                    if (i > 0)
                    {
                        writer.Write(", ");
                    }
                    AppendCoordinate(lineString[i], writer);
                }
                writer.Write(")");
            }
        }

        /// <summary>
        ///     Converts a Polygon to &lt;Polygon Text&gt; format, then
        ///     Appends it to the writer.
        /// </summary>
        /// <param name="polygon">The Polygon to process.</param>
        /// <param name="writer"></param>
        private static void AppendPolygonText(Polygon polygon, StringWriter writer)
        {
            if (polygon == null || polygon.Parts.Count == 0)
            {
                writer.Write("EMPTY");
            }
            else
            {
                writer.Write("(");
                AppendLineStringText(polygon.Parts[0].GetPoints().ToList(), writer); //ExteriorRing
                for (var i = 1; i < polygon.Parts.Count; i++)
                {
                    writer.Write(", ");
                    AppendLineStringText(polygon.Parts[i].GetPoints().ToList(), writer); //InteriorRings
                }
                writer.Write(")");
            }
        }

        /// <summary>
        ///     Converts a MultiLineString to &lt;MultiLineString Text&gt;
        ///     format, then Appends it to the writer.
        /// </summary>
        /// <param name="multiLineString">The MultiLineString to process.</param>
        /// <param name="writer">The output stream writer to Append to.</param>
        private static void AppendMultiLineStringText(Polyline multiLineString, StringWriter writer)
        {
            if (multiLineString == null || multiLineString.Parts.Count == 0)
            {
                writer.Write("EMPTY");
            }
            else
            {
                writer.Write("(");
                for (var i = 0; i < multiLineString.Parts.Count; i++)
                {
                    if (i > 0)
                    {
                        writer.Write(", ");
                    }
                    AppendLineStringText(multiLineString.Parts[i].GetPoints().ToList(), writer);
                }
                writer.Write(")");
            }
        }

        /// <summary>
        ///     Converts a MultiPolygon to &lt;MultiPolygon Text&gt; format, then Appends to it to the writer.
        /// </summary>
        /// <param name="multiPolygon">The MultiPolygon to process.</param>
        /// <param name="writer">The output stream to Append to.</param>
        private static void AppendMultiPolygonText(Polygon multiPolygon, StringWriter writer)
        {
            if (multiPolygon == null || multiPolygon.Parts.Count == 0)
            {
                writer.Write("EMPTY");
            }
            else
            {
                writer.Write("(");

                var outerRing = true;
                if (multiPolygon.Parts.Count > 0)
                {
                    outerRing = Algorithms.IsCcw(multiPolygon.Parts[0]);
                }
                for (var i = 0; i < multiPolygon.Parts.Count; i++)
                {
                    if (i > 0)
                    {
                        writer.Write(", ");
                    }

                    var singlePolygon = new PolygonBuilder(multiPolygon.Parts[i]);

                    //Add any interior rings
                    for (var j = i + 1; j < multiPolygon.Parts.Count; j++)
                    {
                        // It is an interior ring if the clockwise direction is opposite of the first ring
                        if (Algorithms.IsCcw(multiPolygon.Parts[j]) == outerRing)
                        {
                            break;
                        }

                        singlePolygon.AddPart(multiPolygon.Parts[j]);
                        i++;
                    }

                    AppendPolygonText(singlePolygon.ToGeometry(), writer);
                }
                writer.Write(")");
            }
        }

        #endregion
    }
}