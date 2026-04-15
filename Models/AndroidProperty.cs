using System.Text.Json.Serialization;

namespace MvtParser.Models;

public record AndroidProperty(
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("value")]
    string Value
);