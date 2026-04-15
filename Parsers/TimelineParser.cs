using System.Text;
using System.Globalization;

namespace mvt_parser.Parsers;

public enum Plugins
{
    Files,
    Packages,
    SMS
}

public enum Events
{
    file_modified,
    package_first_install,
    package_install,
    package_last_update,
    sms_sent,
    sms_received
}

public record TimelineRecord(
    DateTime Timestamp,
    Plugins Plugin,
    Events Event,
    string Description
);

public static class TimelineParser
{
    private static readonly string[] DateFormats =
    [
        "yyyy-MM-dd HH:mm:ss.ffffff",
        "yyyy-MM-dd HH:mm:ss"
    ];

    private static readonly Encoding Encoding = Encoding.UTF8;

    public static async Task<List<TimelineRecord>> ParseAsync(string filePath)
    {
        List<TimelineRecord> records = [];

        // First line is the header, so we skip it
        await foreach (string line in File.ReadLinesAsync(filePath, Encoding).Skip(1))
        {
            TimelineRecord? parsed = ParseLine(line);
            if (parsed != null)
                records.Add(parsed);
        }

        return records;
    }

    // single line
    public static TimelineRecord? ParseLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        string[] columns = SplitCsvLine(line);
        if (columns.Length < 4)
            return null;

        DateTime timestamp = DateTime.ParseExact(
            columns[0],
            DateFormats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None
        );

        Plugins plugin = Enum.Parse<Plugins>(columns[1]);
        Events evt = Enum.Parse<Events>(columns[2]);
        string description = columns[3];

        return new TimelineRecord(timestamp, plugin, evt, description);
    }

    private static string[] SplitCsvLine(string line)
    {
        List<string> result = [];
        StringBuilder current = new();
        bool inQuotes = false;

        foreach (char c in line)
        {
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(c);
            }
        }
        result.Add(current.ToString());

        return [.. result];
    }
}
