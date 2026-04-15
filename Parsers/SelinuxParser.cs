using System.Text.Json;
using mvt_parser.Models;

namespace mvt_parser.Parsers;

public static class SelinuxParser
{
    public static async Task<SelinuxStatus> ParseAsync(string filePath)
    {
        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<SelinuxStatus>(json) ?? new SelinuxStatus("unknown");
    }
}
