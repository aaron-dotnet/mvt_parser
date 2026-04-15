using System.Text.Json;
using mvt_parser.Models;

namespace mvt_parser.Parsers;

public static class SettingsParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<SystemSettings> ParseAsync(string filePath)
    {
        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<SystemSettings>(json, JsonOptions) ?? new SystemSettings(null, null, null);
    }
}
