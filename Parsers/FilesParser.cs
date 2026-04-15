using System.Text.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class FilesParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<List<FileEntry>> ParseAsync(string filePath)
    {
        var files = new List<FileEntry>();
        var json = await File.ReadAllTextAsync(filePath);
        files = JsonSerializer.Deserialize<List<FileEntry>>(json, JsonOptions) ?? [];
        return files;
    }
}