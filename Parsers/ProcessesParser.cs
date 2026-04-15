using System.Text.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class ProcessesParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<List<Process>> ParseAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<Process>>(json, JsonOptions) ?? [];
    }
}