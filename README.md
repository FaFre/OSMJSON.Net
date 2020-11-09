# OSMJSON.Net

[![Nuget](https://img.shields.io/nuget/v/OSMJSON.Net)](https://www.nuget.org/packages/OSMJSON.Net/)

.Net types for the OSM API JSON format

## Desciption

OSMJSON.Net is a small .Net Standard library containing, the necessary types for deserializing OSM JSON. It is build upon **Newtonsoft.Json** and not campatible with **System.Text.Json**.

Currently deserialization of both [OpenStreetMap OSM JSON](https://wiki.openstreetmap.org/wiki/OSM_JSON) and [Overpass-Api OSM JSON](http://overpass-api.de/output_formats.html#json) is supported. Serialization of OSM JSON uses the OpenStreetMap OSM JSON notation for writing the version number.

## Example

### Deserialization

```csharp
JsonConvert.DeserializeObject<ElementCollection>(json);
```

### Serialization

```csharp
JsonConvert.SerializeObject(elementCollection);
```
