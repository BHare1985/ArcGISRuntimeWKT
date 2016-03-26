<a name='contents'></a>
# Contents [#](#contents 'Go To Here')

- [Algorithms](#T-ArcGISRuntimeWKT-Utilities-Algorithms 'ArcGISRuntimeWKT.Utilities.Algorithms')
  - [IsCcw(ring)](#M-ArcGISRuntimeWKT-Utilities-Algorithms-IsCcw-System-Collections-Generic-List{Esri-ArcGISRuntime-Geometry-MapPoint}- 'ArcGISRuntimeWKT.Utilities.Algorithms.IsCcw(System.Collections.Generic.List{Esri.ArcGISRuntime.Geometry.MapPoint})')
- [GeometryFromWkbUtils](#T-ArcGISRuntimeWKT-GeometryFromWkbUtils 'ArcGISRuntimeWKT.GeometryFromWkbUtils')
  - [Parse(reader)](#M-ArcGISRuntimeWKT-GeometryFromWkbUtils-Parse-System-IO-BinaryReader- 'ArcGISRuntimeWKT.GeometryFromWkbUtils.Parse(System.IO.BinaryReader)')
- [GeometryFromWktUtils](#T-ArcGISRuntimeWKT-GeometryFromWktUtils 'ArcGISRuntimeWKT.GeometryFromWktUtils')
  - [GetCoordinates(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetCoordinates-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.GetCoordinates(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [GetNextCloser(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextCloser-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.GetNextCloser(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [GetNextCloserOrComma(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextCloserOrComma-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.GetNextCloserOrComma(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [GetNextEmptyOrOpener(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextEmptyOrOpener-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.GetNextEmptyOrOpener(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [GetNextNumber(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextNumber-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.GetNextNumber(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [GetNextWord(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextWord-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.GetNextWord(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [ReadGeometryTaggedText(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadGeometryTaggedText-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.ReadGeometryTaggedText(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [ReadLineStringText(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadLineStringText-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.ReadLineStringText(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [ReadMultiLineStringText(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadMultiLineStringText-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.ReadMultiLineStringText(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [ReadMultiPolygonText(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadMultiPolygonText-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.ReadMultiPolygonText(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [ReadPointText(tokenizer)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadPointText-ArcGISRuntimeWKT-WktStreamTokenizer- 'ArcGISRuntimeWKT.GeometryFromWktUtils.ReadPointText(ArcGISRuntimeWKT.WktStreamTokenizer)')
  - [ReadPolygonText(tokenizer,exteriorRingCcw,exteriorRingCcwSpecified)](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadPolygonText-ArcGISRuntimeWKT-WktStreamTokenizer,System-Boolean,System-Boolean- 'ArcGISRuntimeWKT.GeometryFromWktUtils.ReadPolygonText(ArcGISRuntimeWKT.WktStreamTokenizer,System.Boolean,System.Boolean)')
- [GeometryToWkbUtils](#T-ArcGISRuntimeWKT-GeometryToWkbUtils 'ArcGISRuntimeWKT.GeometryToWkbUtils')
  - [WriteDouble(value,writer,byteOrder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteDouble-System-Double,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WriteDouble(System.Double,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WriteGeometry(geometry,bWriter,byteorder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteGeometry-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WriteGeometry(Esri.ArcGISRuntime.Geometry.Geometry,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WriteLineString(ls,bWriter,byteorder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteLineString-System-Collections-Generic-IEnumerable{Esri-ArcGISRuntime-Geometry-MapPoint},System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WriteLineString(System.Collections.Generic.IEnumerable{Esri.ArcGISRuntime.Geometry.MapPoint},System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WriteMultiLineString(mls,bWriter,byteorder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteMultiLineString-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WriteMultiLineString(Esri.ArcGISRuntime.Geometry.Polyline,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WriteMultiPolygon(mp,bWriter,byteorder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteMultiPolygon-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WriteMultiPolygon(Esri.ArcGISRuntime.Geometry.Polygon,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WritePoint(point,bWriter,byteorder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WritePoint-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WritePoint(Esri.ArcGISRuntime.Geometry.MapPoint,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WritePolygon(poly,bWriter,byteorder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WritePolygon-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WritePolygon(Esri.ArcGISRuntime.Geometry.Polygon,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WriteType(geometry,bWriter,byteorder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteType-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WriteType(Esri.ArcGISRuntime.Geometry.Geometry,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
  - [WriteUInt32(value,writer,byteOrder)](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteUInt32-System-UInt32,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.GeometryToWkbUtils.WriteUInt32(System.UInt32,System.IO.BinaryWriter,ArcGISRuntimeWKT.WkbByteOrder)')
- [GeometryToWktUtils](#T-ArcGISRuntimeWKT-GeometryToWktUtils 'ArcGISRuntimeWKT.GeometryToWktUtils')
  - [AppendCoordinate(coordinate,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendCoordinate-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendCoordinate(Esri.ArcGISRuntime.Geometry.MapPoint,System.IO.StringWriter)')
  - [AppendGeometryTaggedText(geometry,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendGeometryTaggedText-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendGeometryTaggedText(Esri.ArcGISRuntime.Geometry.Geometry,System.IO.StringWriter)')
  - [AppendLineStringTaggedText(lineString,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendLineStringTaggedText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendLineStringTaggedText(Esri.ArcGISRuntime.Geometry.Polyline,System.IO.StringWriter)')
  - [AppendLineStringText(lineString,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendLineStringText-System-Collections-Generic-IReadOnlyList{Esri-ArcGISRuntime-Geometry-MapPoint},System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendLineStringText(System.Collections.Generic.IReadOnlyList{Esri.ArcGISRuntime.Geometry.MapPoint},System.IO.StringWriter)')
  - [AppendMultiLineStringTaggedText(multiLineString,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiLineStringTaggedText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendMultiLineStringTaggedText(Esri.ArcGISRuntime.Geometry.Polyline,System.IO.StringWriter)')
  - [AppendMultiLineStringText(multiLineString,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiLineStringText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendMultiLineStringText(Esri.ArcGISRuntime.Geometry.Polyline,System.IO.StringWriter)')
  - [AppendMultiPolygonTaggedText(multiPolygon,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiPolygonTaggedText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendMultiPolygonTaggedText(Esri.ArcGISRuntime.Geometry.Polygon,System.IO.StringWriter)')
  - [AppendMultiPolygonText(multiPolygon,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiPolygonText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendMultiPolygonText(Esri.ArcGISRuntime.Geometry.Polygon,System.IO.StringWriter)')
  - [AppendPointTaggedText(coordinate,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPointTaggedText-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendPointTaggedText(Esri.ArcGISRuntime.Geometry.MapPoint,System.IO.StringWriter)')
  - [AppendPointText(coordinate,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPointText-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendPointText(Esri.ArcGISRuntime.Geometry.MapPoint,System.IO.StringWriter)')
  - [AppendPolygonTaggedText(polygon,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPolygonTaggedText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendPolygonTaggedText(Esri.ArcGISRuntime.Geometry.Polygon,System.IO.StringWriter)')
  - [AppendPolygonText(polygon,writer)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPolygonText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'ArcGISRuntimeWKT.GeometryToWktUtils.AppendPolygonText(Esri.ArcGISRuntime.Geometry.Polygon,System.IO.StringWriter)')
  - [OnlyOneExteriorRing(polygon)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-OnlyOneExteriorRing-Esri-ArcGISRuntime-Geometry-Polygon- 'ArcGISRuntimeWKT.GeometryToWktUtils.OnlyOneExteriorRing(Esri.ArcGISRuntime.Geometry.Polygon)')
  - [WriteNumber(d)](#M-ArcGISRuntimeWKT-GeometryToWktUtils-WriteNumber-System-Double- 'ArcGISRuntimeWKT.GeometryToWktUtils.WriteNumber(System.Double)')
- [Parser](#T-ArcGISRuntimeWKT-Parser 'ArcGISRuntimeWKT.Parser')
  - [GeometryFromWkb(bytes)](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]- 'ArcGISRuntimeWKT.Parser.GeometryFromWkb(System.Byte[])')
  - [GeometryFromWkb(reader)](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader- 'ArcGISRuntimeWKT.Parser.GeometryFromWkb(System.IO.BinaryReader)')
  - [GeometryFromWkt(wellKnownText)](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String- 'ArcGISRuntimeWKT.Parser.GeometryFromWkt(System.String)')
  - [GeometryFromWkt(reader)](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader- 'ArcGISRuntimeWKT.Parser.GeometryFromWkt(System.IO.TextReader)')
  - [GeometryToWkb(g)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri-ArcGISRuntime-Geometry-Geometry- 'ArcGISRuntimeWKT.Parser.GeometryToWkb(Esri.ArcGISRuntime.Geometry.Geometry)')
  - [GeometryToWkb(g,wkbByteOrder)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri-ArcGISRuntime-Geometry-Geometry,ArcGISRuntimeWKT-WkbByteOrder- 'ArcGISRuntimeWKT.Parser.GeometryToWkb(Esri.ArcGISRuntime.Geometry.Geometry,ArcGISRuntimeWKT.WkbByteOrder)')
  - [GeometryToWkt(geometry)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri-ArcGISRuntime-Geometry-Geometry- 'ArcGISRuntimeWKT.Parser.GeometryToWkt(Esri.ArcGISRuntime.Geometry.Geometry)')
  - [GeometryToWkt(geometry,writer)](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-StringWriter- 'ArcGISRuntimeWKT.Parser.GeometryToWkt(Esri.ArcGISRuntime.Geometry.Geometry,System.IO.StringWriter)')
- [StreamTokenizer](#T-ArcGISRuntimeWKT-StreamTokenizer 'ArcGISRuntimeWKT.StreamTokenizer')
  - [#ctor(reader,ignoreWhitespace)](#M-ArcGISRuntimeWKT-StreamTokenizer-#ctor-System-IO-TextReader,System-Boolean- 'ArcGISRuntimeWKT.StreamTokenizer.#ctor(System.IO.TextReader,System.Boolean)')
  - [Column](#P-ArcGISRuntimeWKT-StreamTokenizer-Column 'ArcGISRuntimeWKT.StreamTokenizer.Column')
  - [LineNumber](#P-ArcGISRuntimeWKT-StreamTokenizer-LineNumber 'ArcGISRuntimeWKT.StreamTokenizer.LineNumber')
  - [GetNumericValue()](#M-ArcGISRuntimeWKT-StreamTokenizer-GetNumericValue 'ArcGISRuntimeWKT.StreamTokenizer.GetNumericValue')
  - [GetStringValue()](#M-ArcGISRuntimeWKT-StreamTokenizer-GetStringValue 'ArcGISRuntimeWKT.StreamTokenizer.GetStringValue')
  - [GetTokenType()](#M-ArcGISRuntimeWKT-StreamTokenizer-GetTokenType 'ArcGISRuntimeWKT.StreamTokenizer.GetTokenType')
  - [GetType(character)](#M-ArcGISRuntimeWKT-StreamTokenizer-GetType-System-Char- 'ArcGISRuntimeWKT.StreamTokenizer.GetType(System.Char)')
  - [NextNonWhitespaceToken()](#M-ArcGISRuntimeWKT-StreamTokenizer-NextNonWhitespaceToken 'ArcGISRuntimeWKT.StreamTokenizer.NextNonWhitespaceToken')
  - [NextToken(ignoreWhitespace)](#M-ArcGISRuntimeWKT-StreamTokenizer-NextToken-System-Boolean- 'ArcGISRuntimeWKT.StreamTokenizer.NextToken(System.Boolean)')
  - [NextToken()](#M-ArcGISRuntimeWKT-StreamTokenizer-NextToken 'ArcGISRuntimeWKT.StreamTokenizer.NextToken')
- [TokenType](#T-ArcGISRuntimeWKT-TokenType 'ArcGISRuntimeWKT.TokenType')
  - [Eof](#F-ArcGISRuntimeWKT-TokenType-Eof 'ArcGISRuntimeWKT.TokenType.Eof')
  - [Eol](#F-ArcGISRuntimeWKT-TokenType-Eol 'ArcGISRuntimeWKT.TokenType.Eol')
  - [Number](#F-ArcGISRuntimeWKT-TokenType-Number 'ArcGISRuntimeWKT.TokenType.Number')
  - [Symbol](#F-ArcGISRuntimeWKT-TokenType-Symbol 'ArcGISRuntimeWKT.TokenType.Symbol')
  - [Whitespace](#F-ArcGISRuntimeWKT-TokenType-Whitespace 'ArcGISRuntimeWKT.TokenType.Whitespace')
  - [Word](#F-ArcGISRuntimeWKT-TokenType-Word 'ArcGISRuntimeWKT.TokenType.Word')
- [WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder')
  - [Ndr](#F-ArcGISRuntimeWKT-WkbByteOrder-Ndr 'ArcGISRuntimeWKT.WkbByteOrder.Ndr')
  - [Xdr](#F-ArcGISRuntimeWKT-WkbByteOrder-Xdr 'ArcGISRuntimeWKT.WkbByteOrder.Xdr')
- [WkbGeometryType](#T-ArcGISRuntimeWKT-WkbGeometryType 'ArcGISRuntimeWKT.WkbGeometryType')
- [WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer')
  - [#ctor(reader)](#M-ArcGISRuntimeWKT-WktStreamTokenizer-#ctor-System-IO-TextReader- 'ArcGISRuntimeWKT.WktStreamTokenizer.#ctor(System.IO.TextReader)')
  - [ReadAuthority(authority,authorityCode)](#M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadAuthority-System-String@,System-Int64@- 'ArcGISRuntimeWKT.WktStreamTokenizer.ReadAuthority(System.String@,System.Int64@)')
  - [ReadDoubleQuotedWord()](#M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadDoubleQuotedWord 'ArcGISRuntimeWKT.WktStreamTokenizer.ReadDoubleQuotedWord')
  - [ReadToken(expectedToken)](#M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadToken-System-String- 'ArcGISRuntimeWKT.WktStreamTokenizer.ReadToken(System.String)')

<a name='assembly'></a>
# ArcGISRuntimeWKT [#](#assembly 'Go To Here') [=](#contents 'Back To Contents')

<a name='T-ArcGISRuntimeWKT-Utilities-Algorithms'></a>
## Algorithms [#](#T-ArcGISRuntimeWKT-Utilities-Algorithms 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT.Utilities

<a name='M-ArcGISRuntimeWKT-Utilities-Algorithms-IsCcw-System-Collections-Generic-List{Esri-ArcGISRuntime-Geometry-MapPoint}-'></a>
### IsCcw(ring) `method` [#](#M-ArcGISRuntimeWKT-Utilities-Algorithms-IsCcw-System-Collections-Generic-List{Esri-ArcGISRuntime-Geometry-MapPoint}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Tests whether a ring is oriented counter-clockwise.

##### Returns

Returns true if ring is oriented counter-clockwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ring | [System.Collections.Generic.List{Esri.ArcGISRuntime.Geometry.MapPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{Esri.ArcGISRuntime.Geometry.MapPoint}') | Ring to test. |

<a name='T-ArcGISRuntimeWKT-GeometryFromWkbUtils'></a>
## GeometryFromWkbUtils [#](#T-ArcGISRuntimeWKT-GeometryFromWkbUtils 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Converts Well-known Binary representations to a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') instance.

##### Remarks

The Well-known Binary Representation for [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') (WKBGeometry) provides a portable representation of a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') value as a contiguous stream of bytes. It permits [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') values to be exchanged between an ODBC client and an SQL database in binary form.

The Well-known Binary Representation for [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') is obtained by serializing a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') instance as a sequence of numeric types drawn from the set {Unsigned Integer, Double} and then serializing each numeric type as a sequence of bytes using one of two well defined, standard, binary representations for numeric types (NDR, XDR). The specific binary encoding (NDR or XDR) used for a geometry byte stream is described by a one byte tag that precedes the serialized bytes. The only difference between the two encodings of geometry is one of byte order, the XDR encoding is Big Endian, the NDR encoding is Little Endian.

<a name='M-ArcGISRuntimeWKT-GeometryFromWkbUtils-Parse-System-IO-BinaryReader-'></a>
### Parse(reader) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWkbUtils-Parse-System-IO-BinaryReader- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') based on the Well-known binary representation.

##### Returns

A [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') based on the Well-known binary representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') | A [BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') used to read the Well-known binary representation. |

<a name='T-ArcGISRuntimeWKT-GeometryFromWktUtils'></a>
## GeometryFromWktUtils [#](#T-ArcGISRuntimeWKT-GeometryFromWktUtils 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Converts a Well-known Text representation to a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') instance.

##### Remarks

The Well-Known Text (WKT) representation of Geometry is designed to exchange geometry data in ASCII form.

Examples of WKT representations of geometry objects are:

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetCoordinates-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### GetCoordinates(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetCoordinates-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next array of Coordinates in the stream.

##### Returns

The next array of Coordinates in the stream, or an empty array of "EMPTY" is the next element returned by the stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next element returned by the stream should be "(" (the beginning of "(x1 y1, x2 y2, ..., xn yn)" or "EMPTY". |

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextCloser-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### GetNextCloser(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextCloser-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next ")" in the stream.

##### Returns

Returns the next ")" in the stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next token must be ")". |

##### Remarks

ParseException is thrown if the next token is not ")".

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextCloserOrComma-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### GetNextCloserOrComma(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextCloserOrComma-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next ")" or "," in the stream.

##### Returns

Returns the next ")" or "," in the stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | tokenizer over a stream of text in Well-known Text format. The next token must be ")" or ",". |

##### Remarks

ParseException is thrown if the next token is not ")" or ",".

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextEmptyOrOpener-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### GetNextEmptyOrOpener(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextEmptyOrOpener-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next "EMPTY" or "(" in the stream as uppercase text.

##### Returns

the next "EMPTY" or "(" in the stream as uppercase text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next token must be "EMPTY" or "(". |

##### Remarks

ParseException is thrown if the next token is not "EMPTY" or "(".

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextNumber-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### GetNextNumber(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextNumber-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next number in the stream.

##### Returns

Returns the next number in the stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known text format. The next token must be a number. |

##### Remarks

ParseException is thrown if the next token is not a number.

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextWord-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### GetNextWord(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-GetNextWord-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next word in the stream as uppercase text.

##### Returns

Returns the next word in the stream as uppercase text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next token must be a word. |

##### Remarks

Exception is thrown if the next token is not a word.

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadGeometryTaggedText-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### ReadGeometryTaggedText(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadGeometryTaggedText-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a Geometry using the next token in the stream.

##### Returns

Returns a Geometry specified by the next token in the stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next tokens must form a <Geometry Tagged Text>. |

##### Remarks

Exception is thrown if the coordinates used to create a Polygon shell and holes do not form closed linestrings, or if an unexpected token is encountered.

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadLineStringText-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### ReadLineStringText(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadLineStringText-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a LineString using the next token in the stream.

##### Returns

Returns a LineString specified by the next token in the stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next tokens must form a LineString Text. |

##### Remarks

ParseException is thrown if an unexpected token is encountered.

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadMultiLineStringText-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### ReadMultiLineStringText(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadMultiLineStringText-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a [Polyline](#T-Esri-ArcGISRuntime-Geometry-Polyline 'Esri.ArcGISRuntime.Geometry.Polyline') using the next token in the stream.

##### Returns

a [Polyline](#T-Esri-ArcGISRuntime-Geometry-Polyline 'Esri.ArcGISRuntime.Geometry.Polyline') specified by the next token in the stream

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | tokenizer over a stream of text in Well-known Text format. The next tokens must form a MultiLineString Text |

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadMultiPolygonText-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### ReadMultiPolygonText(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadMultiPolygonText-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a [Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') using the next token in the stream.

##### Returns

a

```
MultiPolygon
```

specified by the next token in the stream, or if if the coordinates used to create the [Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') shells and holes do not form closed linestrings.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | tokenizer over a stream of text in Well-known Text format. The next tokens must form a MultiPolygon. |

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadPointText-ArcGISRuntimeWKT-WktStreamTokenizer-'></a>
### ReadPointText(tokenizer) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadPointText-ArcGISRuntimeWKT-WktStreamTokenizer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a Point using the next token in the stream.

##### Returns

Returns a Point specified by the next token in the stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next tokens must form a <Point Text>. |

##### Remarks

ParseException is thrown if an unexpected token is encountered.

<a name='M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadPolygonText-ArcGISRuntimeWKT-WktStreamTokenizer,System-Boolean,System-Boolean-'></a>
### ReadPolygonText(tokenizer,exteriorRingCcw,exteriorRingCcwSpecified) `method` [#](#M-ArcGISRuntimeWKT-GeometryFromWktUtils-ReadPolygonText-ArcGISRuntimeWKT-WktStreamTokenizer,System-Boolean,System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a Polygon using the next token in the stream.

##### Returns

Returns a Polygon specified by the next token in the stream

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tokenizer | [ArcGISRuntimeWKT.WktStreamTokenizer](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'ArcGISRuntimeWKT.WktStreamTokenizer') | Tokenizer over a stream of text in Well-known Text format. The next tokens must form a <Polygon Text>. |
| exteriorRingCcw | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |
| exteriorRingCcwSpecified | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

##### Remarks

ParseException is thown if the coordinates used to create the Polygon shell and holes do not form closed linestrings, or if an unexpected token is encountered.

<a name='T-ArcGISRuntimeWKT-GeometryToWkbUtils'></a>
## GeometryToWkbUtils [#](#T-ArcGISRuntimeWKT-GeometryToWkbUtils 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Converts a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') instance to a Well-known Binary string representation.

##### Remarks

The Well-known Binary Representation for [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') (WKBGeometry) provides a portable representation of a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') value as a contiguous stream of bytes. It permits [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') values to be exchanged between an ODBC client and an SQL database in binary form.

The Well-known Binary Representation for [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') is obtained by serializing a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') instance as a sequence of numeric types drawn from the set {Unsigned Integer, Double} and then serializing each numeric type as a sequence of bytes using one of two well defined, standard, binary representations for numeric types (NDR, XDR). The specific binary encoding (NDR or XDR) used for a geometry byte stream is described by a one byte tag that precedes the serialized bytes. The only difference between the two encodings of geometry is one of byte order, the XDR encoding is Big Endian, the NDR encoding is Little Endian.

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteDouble-System-Double,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WriteDouble(value,writer,byteOrder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteDouble-System-Double,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a double to the binarywriter using the specified encoding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Value to write |
| writer | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Binary Writer |
| byteOrder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | byteorder |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteGeometry-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WriteGeometry(geometry,bWriter,byteorder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteGeometry-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes the geometry to the binary writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry.Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') | The geometry to be written. |
| bWriter | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') |  |
| byteorder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteLineString-System-Collections-Generic-IEnumerable{Esri-ArcGISRuntime-Geometry-MapPoint},System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WriteLineString(ls,bWriter,byteorder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteLineString-System-Collections-Generic-IEnumerable{Esri-ArcGISRuntime-Geometry-MapPoint},System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a linestring.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ls | [System.Collections.Generic.IEnumerable{Esri.ArcGISRuntime.Geometry.MapPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{Esri.ArcGISRuntime.Geometry.MapPoint}') | The linestring to be written. |
| bWriter | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Stream to write to. |
| byteorder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteMultiLineString-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WriteMultiLineString(mls,bWriter,byteorder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteMultiLineString-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a multilinestring.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mls | [Esri.ArcGISRuntime.Geometry.Polyline](#T-Esri-ArcGISRuntime-Geometry-Polyline 'Esri.ArcGISRuntime.Geometry.Polyline') | The multilinestring to be written. |
| bWriter | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Stream to write to. |
| byteorder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteMultiPolygon-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WriteMultiPolygon(mp,bWriter,byteorder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteMultiPolygon-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a multipolygon.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mp | [Esri.ArcGISRuntime.Geometry.Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') | The mulitpolygon to be written. |
| bWriter | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Stream to write to. |
| byteorder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WritePoint-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WritePoint(point,bWriter,byteorder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WritePoint-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a point.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| point | [Esri.ArcGISRuntime.Geometry.MapPoint](#T-Esri-ArcGISRuntime-Geometry-MapPoint 'Esri.ArcGISRuntime.Geometry.MapPoint') | The point to be written. |
| bWriter | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Stream to write to. |
| byteorder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WritePolygon-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WritePolygon(poly,bWriter,byteorder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WritePolygon-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a polygon.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| poly | [Esri.ArcGISRuntime.Geometry.Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') | The polygon to be written. |
| bWriter | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Stream to write to. |
| byteorder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteType-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WriteType(geometry,bWriter,byteorder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteType-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes the type number for this geometry.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry.Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') | The geometry to determine the type of. |
| bWriter | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Binary Writer |
| byteorder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteUInt32-System-UInt32,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### WriteUInt32(value,writer,byteOrder) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWkbUtils-WriteUInt32-System-UInt32,System-IO-BinaryWriter,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes an unsigned integer to the binarywriter using the specified encoding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | Value to write |
| writer | [System.IO.BinaryWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryWriter 'System.IO.BinaryWriter') | Binary Writer |
| byteOrder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | byteorder |

<a name='T-ArcGISRuntimeWKT-GeometryToWktUtils'></a>
## GeometryToWktUtils [#](#T-ArcGISRuntimeWKT-GeometryToWktUtils 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Outputs the textual representation of a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') instance.

##### Remarks

The Well-Known Text (WKT) representation of Geometry is designed to exchange geometry data in ASCII form.

Examples of WKT representations of geometry objects are:

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendCoordinate-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter-'></a>
### AppendCoordinate(coordinate,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendCoordinate-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Coordinate to <Point> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coordinate | [Esri.ArcGISRuntime.Geometry.MapPoint](#T-Esri-ArcGISRuntime-Geometry-MapPoint 'Esri.ArcGISRuntime.Geometry.MapPoint') | The Coordinate to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output writer to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendGeometryTaggedText-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-StringWriter-'></a>
### AppendGeometryTaggedText(geometry,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendGeometryTaggedText-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Geometry to <Geometry Tagged Text > format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry.Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') | The Geometry to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendLineStringTaggedText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter-'></a>
### AppendLineStringTaggedText(lineString,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendLineStringTaggedText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a LineString to LineString tagged text format,

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lineString | [Esri.ArcGISRuntime.Geometry.Polyline](#T-Esri-ArcGISRuntime-Geometry-Polyline 'Esri.ArcGISRuntime.Geometry.Polyline') | The LineString to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream writer to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendLineStringText-System-Collections-Generic-IReadOnlyList{Esri-ArcGISRuntime-Geometry-MapPoint},System-IO-StringWriter-'></a>
### AppendLineStringText(lineString,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendLineStringText-System-Collections-Generic-IReadOnlyList{Esri-ArcGISRuntime-Geometry-MapPoint},System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a LineString to <LineString Text> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lineString | [System.Collections.Generic.IReadOnlyList{Esri.ArcGISRuntime.Geometry.MapPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyList 'System.Collections.Generic.IReadOnlyList{Esri.ArcGISRuntime.Geometry.MapPoint}') | The LineString to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiLineStringTaggedText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter-'></a>
### AppendMultiLineStringTaggedText(multiLineString,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiLineStringTaggedText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a MultiLineString to <MultiLineString Tagged Text> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| multiLineString | [Esri.ArcGISRuntime.Geometry.Polyline](#T-Esri-ArcGISRuntime-Geometry-Polyline 'Esri.ArcGISRuntime.Geometry.Polyline') | The MultiLineString to process |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream writer to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiLineStringText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter-'></a>
### AppendMultiLineStringText(multiLineString,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiLineStringText-Esri-ArcGISRuntime-Geometry-Polyline,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a MultiLineString to <MultiLineString Text> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| multiLineString | [Esri.ArcGISRuntime.Geometry.Polyline](#T-Esri-ArcGISRuntime-Geometry-Polyline 'Esri.ArcGISRuntime.Geometry.Polyline') | The MultiLineString to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream writer to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiPolygonTaggedText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter-'></a>
### AppendMultiPolygonTaggedText(multiPolygon,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiPolygonTaggedText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a MultiPolygon to <MultiPolygon Tagged Text> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| multiPolygon | [Esri.ArcGISRuntime.Geometry.Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') | The MultiPolygon to process |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream writer to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiPolygonText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter-'></a>
### AppendMultiPolygonText(multiPolygon,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendMultiPolygonText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a MultiPolygon to <MultiPolygon Text> format, then Appends to it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| multiPolygon | [Esri.ArcGISRuntime.Geometry.Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') | The MultiPolygon to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPointTaggedText-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter-'></a>
### AppendPointTaggedText(coordinate,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPointTaggedText-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Coordinate to <Point Tagged Text> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coordinate | [Esri.ArcGISRuntime.Geometry.MapPoint](#T-Esri-ArcGISRuntime-Geometry-MapPoint 'Esri.ArcGISRuntime.Geometry.MapPoint') | the

```
Coordinate
```

to process |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | the output writer to Append to |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPointText-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter-'></a>
### AppendPointText(coordinate,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPointText-Esri-ArcGISRuntime-Geometry-MapPoint,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Coordinate to Point Text format then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coordinate | [Esri.ArcGISRuntime.Geometry.MapPoint](#T-Esri-ArcGISRuntime-Geometry-MapPoint 'Esri.ArcGISRuntime.Geometry.MapPoint') | The Coordinate to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The output stream writer to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPolygonTaggedText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter-'></a>
### AppendPolygonTaggedText(polygon,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPolygonTaggedText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Polygon to <Polygon Tagged Text> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polygon | [Esri.ArcGISRuntime.Geometry.Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') | Th Polygon to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | The stream writer to Append to. |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPolygonText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter-'></a>
### AppendPolygonText(polygon,writer) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-AppendPolygonText-Esri-ArcGISRuntime-Geometry-Polygon,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Polygon to <Polygon Text> format, then Appends it to the writer.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polygon | [Esri.ArcGISRuntime.Geometry.Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') | The Polygon to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') |  |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-OnlyOneExteriorRing-Esri-ArcGISRuntime-Geometry-Polygon-'></a>
### OnlyOneExteriorRing(polygon) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-OnlyOneExteriorRing-Esri-ArcGISRuntime-Geometry-Polygon- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Checks whether the first ring is CW or CCW, and returns true if there is only one ring in this direction.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polygon | [Esri.ArcGISRuntime.Geometry.Polygon](#T-Esri-ArcGISRuntime-Geometry-Polygon 'Esri.ArcGISRuntime.Geometry.Polygon') |  |

<a name='M-ArcGISRuntimeWKT-GeometryToWktUtils-WriteNumber-System-Double-'></a>
### WriteNumber(d) `method` [#](#M-ArcGISRuntimeWKT-GeometryToWktUtils-WriteNumber-System-Double- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a double to a string, not in scientific notation.

##### Returns

The double as a string, not in scientific notation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| d | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The double to convert. |

<a name='T-ArcGISRuntimeWKT-Parser'></a>
## Parser [#](#T-ArcGISRuntimeWKT-Parser 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

convert Well Known Text (WKT) / Well Known Binary (WKB) to and from [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry')

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]-'></a>
### GeometryFromWkb(bytes) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-Byte[]- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') from the supplied byte[] containing the Well-known Binary representation.

##### Returns

A [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') bases on the supplied Well-known Binary representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | byte[] containing the Well-known Binary representation. |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader-'></a>
### GeometryFromWkb(reader) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkb-System-IO-BinaryReader- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') based on the Well-known binary representation.

##### Returns

A [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') based on the Well-known binary representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') | A [BinaryReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.BinaryReader 'System.IO.BinaryReader') used to read the Well-known binary representation. |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String-'></a>
### GeometryFromWkt(wellKnownText) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Well-known text representation to a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry').

##### Returns

Returns a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') specified by wellKnownText. Throws an exception if there is a parsing problem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wellKnownText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') tagged text string ( see the OpenGIS Simple Features Specification. ) |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader-'></a>
### GeometryFromWkt(reader) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryFromWkt-System-IO-TextReader- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Well-known Text representation to a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry').

##### Returns

Returns a [Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') read from StreamReader. An exception will be thrown if there is a parsing problem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') | A Reader which will return a Geometry Tagged Text string (see the OpenGIS Simple Features Specification) |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri-ArcGISRuntime-Geometry-Geometry-'></a>
### GeometryToWkb(g) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri-ArcGISRuntime-Geometry-Geometry- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a geometry to a byte array using little endian byte encoding

##### Returns

WKB representation of the geometry

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| g | [Esri.ArcGISRuntime.Geometry.Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') | The geometry to write |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri-ArcGISRuntime-Geometry-Geometry,ArcGISRuntimeWKT-WkbByteOrder-'></a>
### GeometryToWkb(g,wkbByteOrder) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkb-Esri-ArcGISRuntime-Geometry-Geometry,ArcGISRuntimeWKT-WkbByteOrder- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Writes a geometry to a byte array using the specified encoding.

##### Returns

WKB representation of the geometry

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| g | [Esri.ArcGISRuntime.Geometry.Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') | The geometry to write |
| wkbByteOrder | [ArcGISRuntimeWKT.WkbByteOrder](#T-ArcGISRuntimeWKT-WkbByteOrder 'ArcGISRuntimeWKT.WkbByteOrder') | Byte order |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri-ArcGISRuntime-Geometry-Geometry-'></a>
### GeometryToWkt(geometry) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri-ArcGISRuntime-Geometry-Geometry- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Geometry to its Well-known Text representation.

##### Returns

A <Geometry Tagged Text> string (see the OpenGIS Simple Features Specification)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry.Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') | A Geometry to write. |

<a name='M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-StringWriter-'></a>
### GeometryToWkt(geometry,writer) `method` [#](#M-ArcGISRuntimeWKT-Parser-GeometryToWkt-Esri-ArcGISRuntime-Geometry-Geometry,System-IO-StringWriter- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts a Geometry to its Well-known Text representation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geometry | [Esri.ArcGISRuntime.Geometry.Geometry](#T-Esri-ArcGISRuntime-Geometry-Geometry 'Esri.ArcGISRuntime.Geometry.Geometry') | A geometry to process. |
| writer | [System.IO.StringWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.StringWriter 'System.IO.StringWriter') | Stream to write out the geometry's text representation. |

##### Remarks

Geometry is written to the output stream as <Gemoetry Tagged Text> string (see the OpenGIS Simple Features Specification).

<a name='T-ArcGISRuntimeWKT-StreamTokenizer'></a>
## StreamTokenizer [#](#T-ArcGISRuntimeWKT-StreamTokenizer 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

The StreamTokenizer class takes an input stream and parses it into "tokens", allowing the tokens to be read one at a time. The parsing process is controlled by a table and a number of flags that can be set to various states. The stream tokenizer can recognize identifiers, numbers, quoted strings, and various comment style

##### Remarks

This is a crude c# implementation of Java's  class.

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-#ctor-System-IO-TextReader,System-Boolean-'></a>
### #ctor(reader,ignoreWhitespace) `constructor` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-#ctor-System-IO-TextReader,System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Initializes a new instance of the StreamTokenizer class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') | A TextReader with some text to read. |
| ignoreWhitespace | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Flag indicating whether whitespace should be ignored. |

<a name='P-ArcGISRuntimeWKT-StreamTokenizer-Column'></a>
### Column `property` [#](#P-ArcGISRuntimeWKT-StreamTokenizer-Column 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The current column number of the stream being read.

<a name='P-ArcGISRuntimeWKT-StreamTokenizer-LineNumber'></a>
### LineNumber `property` [#](#P-ArcGISRuntimeWKT-StreamTokenizer-LineNumber 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The current line number of the stream being read.

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-GetNumericValue'></a>
### GetNumericValue() `method` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-GetNumericValue 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

If the current token is a number, this field contains the value of that number.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | Current token is not a number in a valid format. |

##### Remarks

If the current token is a number, this field contains the value of that number. The current token is a number when the value of the ttype field is TT_NUMBER.

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-GetStringValue'></a>
### GetStringValue() `method` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-GetStringValue 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

If the current token is a word token, this field contains a string giving the characters of the word token.

##### Parameters

This method has no parameters.

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-GetTokenType'></a>
### GetTokenType() `method` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-GetTokenType 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Gets the token type of the current token.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-GetType-System-Char-'></a>
### GetType(character) `method` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-GetType-System-Char- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Determines a characters type (e.g. number, symbols, character).

##### Returns

The TokenType the character is.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| character | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') | The character to determine. |

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-NextNonWhitespaceToken'></a>
### NextNonWhitespaceToken() `method` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-NextNonWhitespaceToken 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns next token that is not whitespace.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-NextToken-System-Boolean-'></a>
### NextToken(ignoreWhitespace) `method` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-NextToken-System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next token.

##### Returns

The TokenType of the next token.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ignoreWhitespace | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Determines is whitespace is ignored. True if whitespace is to be ignored. |

<a name='M-ArcGISRuntimeWKT-StreamTokenizer-NextToken'></a>
### NextToken() `method` [#](#M-ArcGISRuntimeWKT-StreamTokenizer-NextToken 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the next token.

##### Returns

The TokenType of the next token.

##### Parameters

This method has no parameters.

<a name='T-ArcGISRuntimeWKT-TokenType'></a>
## TokenType [#](#T-ArcGISRuntimeWKT-TokenType 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Represents the type of token created by the StreamTokenizer class.

<a name='F-ArcGISRuntimeWKT-TokenType-Eof'></a>
### Eof `constants` [#](#F-ArcGISRuntimeWKT-TokenType-Eof 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Indicates that the end of the input stream has been reached.

<a name='F-ArcGISRuntimeWKT-TokenType-Eol'></a>
### Eol `constants` [#](#F-ArcGISRuntimeWKT-TokenType-Eol 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Indicates that the end of line has been read. The field can only have this value if the eolIsSignificant method has been called with the argument true.

<a name='F-ArcGISRuntimeWKT-TokenType-Number'></a>
### Number `constants` [#](#F-ArcGISRuntimeWKT-TokenType-Number 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Indicates that the token is a number.

<a name='F-ArcGISRuntimeWKT-TokenType-Symbol'></a>
### Symbol `constants` [#](#F-ArcGISRuntimeWKT-TokenType-Symbol 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Characters that are not whitespace, numbers, etc...

<a name='F-ArcGISRuntimeWKT-TokenType-Whitespace'></a>
### Whitespace `constants` [#](#F-ArcGISRuntimeWKT-TokenType-Whitespace 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Indictaes that the token is white space (space, tab, newline).

<a name='F-ArcGISRuntimeWKT-TokenType-Word'></a>
### Word `constants` [#](#F-ArcGISRuntimeWKT-TokenType-Word 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Indicates that the token is a word.

<a name='T-ArcGISRuntimeWKT-WkbByteOrder'></a>
## WkbByteOrder [#](#T-ArcGISRuntimeWKT-WkbByteOrder 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Specifies the specific binary encoding (NDR or XDR) used for a geometry byte stream

<a name='F-ArcGISRuntimeWKT-WkbByteOrder-Ndr'></a>
### Ndr `constants` [#](#F-ArcGISRuntimeWKT-WkbByteOrder-Ndr 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

NDR (Little Endian) Encoding of Numeric Types

##### Remarks

The NDR representation of an Unsigned Integer is Little Endian (least significant byte first).

The NDR representation of a Double is Little Endian (sign bit is last byte).

<a name='F-ArcGISRuntimeWKT-WkbByteOrder-Xdr'></a>
### Xdr `constants` [#](#F-ArcGISRuntimeWKT-WkbByteOrder-Xdr 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

XDR (Big Endian) Encoding of Numeric Types

##### Remarks

The XDR representation of an Unsigned Integer is Big Endian (most significant byte first).

The XDR representation of a Double is Big Endian (sign bit is first byte).

<a name='T-ArcGISRuntimeWKT-WkbGeometryType'></a>
## WkbGeometryType [#](#T-ArcGISRuntimeWKT-WkbGeometryType 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Enumeration to determine geometrytype in Well-known Binary

<a name='T-ArcGISRuntimeWKT-WktStreamTokenizer'></a>
## WktStreamTokenizer [#](#T-ArcGISRuntimeWKT-WktStreamTokenizer 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

ArcGISRuntimeWKT

##### Summary

Reads a stream of Well Known Text (wkt) string and returns a stream of tokens.

<a name='M-ArcGISRuntimeWKT-WktStreamTokenizer-#ctor-System-IO-TextReader-'></a>
### #ctor(reader) `constructor` [#](#M-ArcGISRuntimeWKT-WktStreamTokenizer-#ctor-System-IO-TextReader- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Initializes a new instance of the WktStreamTokenizer class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') | A TextReader that contains |

##### Remarks

The WktStreamTokenizer class ais in reading WKT streams.

<a name='M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadAuthority-System-String@,System-Int64@-'></a>
### ReadAuthority(authority,authorityCode) `method` [#](#M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadAuthority-System-String@,System-Int64@- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Reads the authority and authority code.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| authority | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | String to place the authority in. |
| authorityCode | [System.Int64@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64@ 'System.Int64@') | String to place the authority code in. |

<a name='M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadDoubleQuotedWord'></a>
### ReadDoubleQuotedWord() `method` [#](#M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadDoubleQuotedWord 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Reads a string inside double quotes.

##### Returns

The string inside the double quotes.

##### Parameters

This method has no parameters.

##### Remarks

White space inside quotes is preserved.

<a name='M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadToken-System-String-'></a>
### ReadToken(expectedToken) `method` [#](#M-ArcGISRuntimeWKT-WktStreamTokenizer-ReadToken-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Reads a token and checks it is what is expected.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expectedToken | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The expected token. |
