using System.Text.Json;
using mvt_parser.Models;

namespace mvt_parser.Parsers;

public static class PackagesParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true
    };

    public static async Task<List<Package>> ParseAsync(string filePath)
    {
        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<Package>>(json, JsonOptions) ?? [];
    }
}
