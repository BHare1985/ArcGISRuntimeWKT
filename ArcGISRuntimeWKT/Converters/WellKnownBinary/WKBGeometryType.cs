namespace ArcGISRuntimeWKT.Converters.WellKnownBinary
{
    /// <summary>
    ///     Enumeration to determine geometrytype in Well-known Binary
    /// </summary>
    internal enum WkbGeometryType : uint
    {
        WkbPoint = 1,
        WkbLineString = 2,
        WkbPolygon = 3,
        WkbMultiPoint = 4,
        WkbMultiLineString = 5,
        WkbMultiPolygon = 6,
        WkbGeometryCollection = 7
    }
}