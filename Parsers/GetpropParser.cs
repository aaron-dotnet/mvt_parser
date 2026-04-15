using System.Text.Json;
using mvt_parser.Models;

namespace mvt_parser.Parsers;

public static class GetpropParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<List<AndroidProperty>> ParseAsync(string filePath)
    {
        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<AndroidProperty>>(json, JsonOptions) ?? [];
    }
}
