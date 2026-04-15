using System.Text.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class InfoParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<ExtractionInfo> ParseAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<ExtractionInfo>(json, JsonOptions) ?? new ExtractionInfo(null, null, null, null, null);
    }
}