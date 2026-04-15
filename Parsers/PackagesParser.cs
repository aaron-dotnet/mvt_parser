using System.Text.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class PackagesParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<List<Package>> ParseAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<Package>>(json, JsonOptions) ?? [];
    }
}