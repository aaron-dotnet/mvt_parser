using System.Text.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class SmsParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<List<SmsMessage>> ParseAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<SmsMessage>>(json, JsonOptions) ?? [];
    }
}