using System.Text.RegularExpressions;
using mvt_parser.Models;

namespace mvt_parser.Parsers;

public static class CommandLogParser
{
    // [date] - [process] - [mode] - [message]
    private static readonly Regex LogLineRegex = new(
        @"^(\d{4}-\d{2}-\d{2}\s+\d{2}:\d{2}:\d{2},\d{3})\s+-\s+(\S+)\s+-\s+(\w+)\s+-\s+(.*)$",
        RegexOptions.Compiled);

    public static async Task<List<CommandLogEntry>> ParseAsync(string filePath)
    {
        List<CommandLogEntry> entries = [];
        await foreach (string line in File.ReadLinesAsync(filePath))
        {
            CommandLogEntry? entry = ParseLine(line);
            if (entry != null)
                entries.Add(entry);
        }
        return entries;
    }

    public static CommandLogEntry? ParseLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        Match match = LogLineRegex.Match(line);
        if (!match.Success)
            return null;

        return new CommandLogEntry(
            match.Groups[1].Value,
            match.Groups[2].Value,
            match.Groups[3].Value,
            match.Groups[4].Value);
    }
}
