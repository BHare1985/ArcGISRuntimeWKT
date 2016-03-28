# ArcGISRuntimeWKT

This is a unit-tested [NuGet](https://www.nuget.org/packages/ArcGISRuntimeWKT/) C# library that can convert [Well Known Text (WKT)](https://en.wikipedia.org/wiki/Well-known_text) / [Well Known Binary (WKB)](https://en.wikipedia.org/wiki/Well-known_text#Well-known_binary) to and from [ESRI's ArcGIS Runtime Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm).

The motivation for this library is a no-dependency and small footprint WKT/WKB parser for Runtime Geometry. It has some [limited-functionality](#NotSupported) but serves as a viable alternative to (albeit more robust but bloated) libraries such as [SharpMap](https://sharpmap.codeplex.com/)

This library is to be used in conjection with NuGet package [Esri.ArcGISRuntime](https://www.nuget.org/packages/Esri.ArcGISRuntime/) for .NET

## Install
Install NuGet package https://www.nuget.org/packages/ArcGISRuntimeWKT/ (note: it is pre-release)
 
or via Package Manager Console: `Install-Package ArcGISRuntimeWKT -Pre`


## Usage
#### Example
```csharp
using Esri.ArcGISRuntime.Geometry;
using ArcGISRuntimeWKT;

Geometry geometry = Parser.GeometryFromWkt("LINESTRING(9.3 26.93,21 34,27 30)");
Console.Write(geometry.GetType()); //Esri.ArcGISRuntime.Geometry.Polyline

var point = new MapPoint(30, 20);
string wkt = Parser.GeometryToWkt(point);
Console.Write(wkt); //POINT(30 20)
```
#### Creating a geometry
- [GeometryFromWkb(Byte[])](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]- 'Go To Here')
- [GeometryFromWkb(BinaryReader)](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader- 'Go To Here')
    
- [GeometryFromWkt(String)](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String- 'Go To Here')
- [GeometryFromWkt(TextReader)](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader- 'Go To Here')

#### Converting geometry 
- [GeometryToWkb(Geometry)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry- 'Go To Here')
- [GeometryToWkb(Geometry, WkbByteOrder)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here')


- [GeometryToWkt(Geometry)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry- 'Go To Here')
- [GeometryToWkt(Geometry, StringWriter)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry,System-IO-StringWriter- 'Go To Here')

<a name='NotSupported'></a>
## Not Supported
The following WKT and WKB are not supported at this time:
MultiPoint, GeometryCollection, CircularString, CompoundCurve, CurvePolygon, MultiCurve, MultiSurface, Curve, Surface, PolyhedralSurface, TIN, Triangle, 

## Test Enviorment
Created on  Windows 10, Visual Studio 2015, with ArcGISRuntime version 10.2.7.1234 and .NET framework 4.5.2.
Additionally tested on Windows 7 and  ArcGISRuntime version 10.2.4+ and .NET framework 4.5

---

### Well-Known Binary
The Well-known Binary (WKB) representation for Geometry provides a portable representation of a Geometry value as a contiguous stream of bytes. It permits Geometry values to be exchanged between an ODBC client and an SQL database in binary form.

The Well-known Binary Representation for Geometry is obtained by serializing a Geometry instance as a sequence of numeric types drawn from the set {Unsigned Integer, Double} and then serializing each numeric type as a sequence of bytes using one of two well defined, standard, binary representations for numeric types (NDR, XDR). The specific binary encoding (NDR or XDR) used for a geometry byte stream is described by a one byte tag that precedes the serialized bytes. The only difference between the two encodings of geometry is one of byte order, the XDR encoding is Big Endian, the NDR encoding is Little Endian.

### Well-Known Text
The Well-Known Text (WKT) representation of Geometry is designed to exchange geometry data in ASCII form.
Examples of WKT representations of the most geometry objects are:

| Representation  | WKT | Supported|
| ---- | ---- | ----------- |
|Point|POINT(15 20)|True|
|LineString with four points|LINESTRING(0 0, 10 10, 20 25, 50 60)|True|
|Polygon with one exterior ring and one interior ring|POLYGON((0 0,10 0,10 10,0 10,0 0),(5 5,7 5,7 7,5 7, 5 5))|True|
|MultiPoint with three Point values|MULTIPOINT(0 0, 20 20, 60 60)|False|
|MultiLineString with two LineString values|MULTILINESTRING((10 10, 20 20), (15 15, 30 15))|True|
|MultiPolygon with two Polygon values|MULTIPOLYGON(((0 0,10 0,10 10,0 10,0 0)),((5 5,7 5,7 7,5 7, 5 5)))|True|
|GeometryCollection consisting of two Point values and one LineString|GEOMETRYCOLLECTION(POINT(10 10),POINT(30 30),LINESTRING(15 15, 20 20))|False|

---

# Methods

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]-'></a>
## GeometryFromWkb(bytes) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]- 'Go To Here') 

##### Summary

Creates a [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') from the supplied byte[] containing the Well-known Binary representation.

##### Returns

A [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') bases on the supplied Well-known Binary representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | byte[] containing the Well-known Binary representation. |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader-'></a>
## GeometryFromWkb(reader) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader- 'Go To Here') 

##### Summary

Creates a [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') based on the Well-known binary representation.

##### Returns

A [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') based on the Well-known binary representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') | A [BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') used to read the Well-known binary representation. |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String-'></a>
## GeometryFromWkt(wellKnownText) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String- 'Go To Here') 

##### Summary

Converts a Well-known text representation to a [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry').

##### Returns

Returns a [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') specified by wellKnownText. Throws an exception if there is a parsing problem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wellKnownText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') tagged text string ( see the OpenGIS Simple Features Specification. ) |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader-'></a>
## GeometryFromWkt(reader) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader- 'Go To Here') 

##### Summary

Converts a Well-known Text representation to a [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry').

##### Returns

Returns a [Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') read from StreamReader. An exception will be thrown if there is a parsing problem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') | A Reader which will return a Geometry Tagged Text string (see the OpenGIS Simple Features Specification) |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry-'></a>
## GeometryToWkb(g) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry- 'Go To Here') 

##### Summary

Writes a geometry to a byte array using little endian byte encoding

##### Returns

WKB representation of the geometry

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| g | [Esri.ArcGISRuntime.Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') | The geometry to write |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry,ArcGISRuntimeWKT-WkbByteOrder-'></a>
## GeometryToWkb(g,wkbByteOrder) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') 

##### Summary

Writes a geometry to a byte array using the specified encoding.

##### Returns

WKB representation of the geometry

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| g | [Esri.ArcGISRuntime.Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') | The geometry to write |
| wkbByteOrder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry-'></a>
## GeometryToWkt(geometry) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry- 'Go To Here') 

##### Summary

Converts a Geometry to its Well-known Text representation.

##### Returns

A <Geometry Tagged Text> string (see the OpenGIS Simple Features Specification)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') | A Geometry to write. |


<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry,System-IO-StringWriter-'></a>
## GeometryToWkt(geometry,writer) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry,System-IO-StringWriter- 'Go To Here') 

##### Summary

Converts a Geometry to its Well-known Text representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm 'Esri.ArcGISRuntime.Geometry') | A geometry to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | Stream to write out the geometry's text representation. |

##### Remarks

Geometry is written to the output stream as <Gemoetry Tagged Text> string (see the OpenGIS Simple Features Specification).

# Types
<a name='T-ArcGISRuntimeWKT-WkbByteOrder'></a>
## WkbByteOrder [#](#T-ArcGISRuntimeWKT-WkbByteOrder 'Go To Here') 

##### Namespace

ArcGISRuntimeWKT

##### Summary

Specifies the specific binary encoding (NDR or XDR) used for a geometry byte stream

<a name='F-ArcGISRuntimeWKT-WkbByteOrder-Ndr'></a>
### Ndr `constants` [#](#F-ArcGISRuntimeWKT-WkbByteOrder-Ndr 'Go To Here') 

##### Summary

NDR (Little Endian) Encoding of Numeric Types

##### Remarks

The NDR representation of an Unsigned Integer is Little Endian (least significant byte first).

The NDR representation of a Double is Little Endian (sign bit is last byte).

<a name='F-ArcGISRuntimeWKT-WkbByteOrder-Xdr'></a>
### Xdr `constants` [#](#F-ArcGISRuntimeWKT-WkbByteOrder-Xdr 'Go To Here') 

##### Summary

XDR (Big Endian) Encoding of Numeric Types

##### Remarks

The XDR representation of an Unsigned Integer is Big Endian (most significant byte first).

The XDR representation of a Double is Big Endian (sign bit is first byte).

