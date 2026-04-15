using System.Text.Json.Serialization;

namespace mvt_parser.Models;

public record SelinuxStatus(
    [property: JsonPropertyName("status")]
    string Status
);
