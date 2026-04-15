using System.Text.Json.Serialization;

namespace MvtParser.Models;

public record SelinuxStatus(
    [property: JsonPropertyName("status")]
    string Status
);