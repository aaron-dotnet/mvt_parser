using System.Text.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class SettingsParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<SystemSettings> ParseAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<SystemSettings>(json, JsonOptions) ?? new SystemSettings(null, null, null);
    }
}