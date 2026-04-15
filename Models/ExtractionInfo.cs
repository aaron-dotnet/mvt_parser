using System.Text.Json.Serialization;

namespace mvt_parser.Models;

public record ExtractionInfo(
    [property: JsonPropertyName("target_path")]
    string? TargetPath,
    [property: JsonPropertyName("mvt_version")]
    string? MvtVersion,
    [property: JsonPropertyName("date")]
    string? Date,
    [property: JsonPropertyName("ioc_files")]
    List<string>? IocFiles,
    [property: JsonPropertyName("hashes")]
    List<string>? Hashes
);
