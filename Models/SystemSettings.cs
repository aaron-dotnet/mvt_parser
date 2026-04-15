using System.Text.Json.Serialization;

namespace MvtParser.Models;

public record SystemSettings(
    [property: JsonPropertyName("system")]
    Dictionary<string, string>? System,
    [property: JsonPropertyName("secure")]
    Dictionary<string, string>? Secure,
    [property: JsonPropertyName("global")]
    Dictionary<string, string>? Global
);