using System.Text.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class GetpropParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<List<AndroidProperty>> ParseAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<AndroidProperty>>(json, JsonOptions) ?? [];
    }
}