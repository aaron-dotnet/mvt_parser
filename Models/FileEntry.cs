using System.Text.Json.Serialization;

namespace MvtParser.Models;

public record FileEntry(
    [property: JsonPropertyName("path")]
    string Path,
    [property: JsonPropertyName("modified_time")]
    string ModifiedTime,
    [property: JsonPropertyName("mode")]
    string Mode,
    [property: JsonPropertyName("is_suid")]
    bool IsSuid,
    [property: JsonPropertyName("is_sgid")]
    bool IsSgid,
    [property: JsonPropertyName("size")]
    string Size,
    [property: JsonPropertyName("owner")]
    string Owner,
    [property: JsonPropertyName("group")]
    string Group
);