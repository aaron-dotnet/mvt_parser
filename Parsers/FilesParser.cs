using System.Text.Json;
using mvt_parser.Models;

namespace mvt_parser.Parsers;

public static class FilesParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<List<FileEntry>> ParseAsync(string filePath)
    {
        List<FileEntry> files = [];
        string json = await File.ReadAllTextAsync(filePath);
        files = JsonSerializer.Deserialize<List<FileEntry>>(json, JsonOptions) ?? [];
        return files;
    }
}
