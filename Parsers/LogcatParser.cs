using System.Text.RegularExpressions;
using MvtParser.Models;

namespace MvtParser.Parsers;

public static class LogcatParser
{
    private static readonly Regex LogLineRegex = new(
        @"^(\d{2}-\d{2}\s+\d{2}:\d{2}:\d{2}\.\d{3})\s+(\d+)\s+(\d+)\s+([VDIWEFA])\s+(\w+):\s*(.*)$",
        RegexOptions.Compiled);

    private static readonly Regex CrashHeaderRegex = new(
        @"^-+ beginning of (crash|system|tombstone)$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static async Task<List<LogEntry>> ParseAsync(string filePath)
    {
        var entries = new List<LogEntry>();
        await foreach (var line in File.ReadLinesAsync(filePath))
        {
            var entry = ParseLine(line);
            if (entry != null)
                entries.Add(entry);
        }
        return entries;
    }

    public static LogEntry? ParseLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        var match = LogLineRegex.Match(line);
        if (!match.Success)
            return null;

        return new LogEntry(
            match.Groups[1].Value,
            match.Groups[2].Value,
            match.Groups[3].Value,
            match.Groups[4].Value,
            match.Groups[5].Value,
            match.Groups[6].Value);
    }

    public static bool IsCrashHeader(string line)
    {
        return CrashHeaderRegex.IsMatch(line);
    }
}