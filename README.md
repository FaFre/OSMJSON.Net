# OSMJSON.Net

[![Nuget](https://img.shields.io/nuget/v/OSMJSON.Net)](https://www.nuget.org/packages/OSMJSON.Net/)

.Net types for the OSM API JSON format

## Desciption

OSMJSON.Net is a small .Net Standard library containing the necessary types for serializing and de-serializing of OSM JSON. Since version **1.1.0**, **System.Text.Json** is used under the hood.

Currently de-serialization of both [OpenStreetMap OSM JSON](https://wiki.openstreetmap.org/wiki/OSM_JSON) and [Overpass-Api OSM JSON](http://overpass-api.de/output_formats.html#json) is supported. Serialization of OSM JSON uses the OpenStreetMap OSM JSON notation for writing the version number.

## Example

### Deserialization

```csharp
OSMJSON.Deserialize(json);
```

### Serialization

```csharp
OSMJSON.Serialize(elementCollection);
```
