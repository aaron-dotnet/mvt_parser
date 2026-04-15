using Newtonsoft.Json;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class SelinuxParser
{
    public static async Task<SelinuxStatus> ParseAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonConvert.DeserializeObject<SelinuxStatus>(json) ?? new SelinuxStatus("unknown");
    }
}