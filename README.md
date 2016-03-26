# ArcGISRuntimeWKT

This is a unit-tested C# library that can convert [Well Known Text (WKT)](https://en.wikipedia.org/wiki/Well-known_text) / [Well Known Binary (WKB)](https://en.wikipedia.org/wiki/Well-known_text#Well-known_binary) to and from [ESRI's ArcGIS Runtime Geometry](https://developers.arcgis.com/net/store/api-reference/html/N_Esri_ArcGISRuntime_Geometry.htm)


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



# Methods

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]-'></a>
## GeometryFromWkb(bytes) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]- 'Go To Here') 

##### Summary

Creates a [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') from the supplied byte[] containing the Well-known Binary representation.

##### Returns

A [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') bases on the supplied Well-known Binary representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | byte[] containing the Well-known Binary representation. |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader-'></a>
## GeometryFromWkb(reader) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader- 'Go To Here') 

##### Summary

Creates a [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') based on the Well-known binary representation.

##### Returns

A [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') based on the Well-known binary representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') | A [BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') used to read the Well-known binary representation. |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String-'></a>
## GeometryFromWkt(wellKnownText) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String- 'Go To Here') 

##### Summary

Converts a Well-known text representation to a [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry').

##### Returns

Returns a [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') specified by wellKnownText. Throws an exception if there is a parsing problem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wellKnownText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') tagged text string ( see the OpenGIS Simple Features Specification. ) |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader-'></a>
## GeometryFromWkt(reader) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader- 'Go To Here') 

##### Summary

Converts a Well-known Text representation to a [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry').

##### Returns

Returns a [Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') read from StreamReader. An exception will be thrown if there is a parsing problem.

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
| g | [Esri.ArcGISRuntime.Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') | The geometry to write |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry,ArcGISRuntimeWKT-WkbByteOrder-'></a>
## GeometryToWkb(g,wkbByteOrder) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri.ArcGISRuntime.Geometry,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') 

##### Summary

Writes a geometry to a byte array using the specified encoding.

##### Returns

WKB representation of the geometry

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| g | [Esri.ArcGISRuntime.Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') | The geometry to write |
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
| geometry | [Esri.ArcGISRuntime.Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') | A Geometry to write. |


<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry,System-IO-StringWriter-'></a>
## GeometryToWkt(geometry,writer) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri.ArcGISRuntime.Geometry,System-IO-StringWriter- 'Go To Here') 

##### Summary

Converts a Geometry to its Well-known Text representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry](#T-Esri.ArcGISRuntime.Geometry 'Esri.ArcGISRuntime.Geometry') | A geometry to process. |
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

