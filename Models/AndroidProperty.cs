using System.Text.Json.Serialization;

namespace mvt_parser.Models;

public record AndroidProperty(
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("value")]
    string Value
);
