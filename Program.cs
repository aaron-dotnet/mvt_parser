using System.IO;
using System.Text;
using System.Diagnostics;
using System.Globalization;

internal class Program
{
    enum Plugins
    {
        Files,
        Packages,
        SMS
    }
    enum Events
    {
        file_modified,
        package_first_install,
        package_install,
        package_last_update,
        sms_sent,
        sms_received
    }

    private static readonly string[] DateFormats =
    [
        "yyyy-MM-dd HH:mm:ss.ffffff",
        "yyyy-MM-dd HH:mm:ss"
    ];
    // config
    static readonly CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");
    const string filePath = "./samples/timeline_tiny.csv";
    static readonly Encoding encoding = Encoding.UTF8; // original file exported on utf8

    private static async Task Main()
    {
        Stopwatch sw = Stopwatch.StartNew();

        List<Record> records = await ParseFileAsync(filePath);

        sw.Stop();
        Console.WriteLine($"Parsed {records.Count} lines in {sw.ElapsedMilliseconds}ms");

        foreach (Record record in records.Take(5))
        {
            // if (record.Plugin != Plugins.SMS)
            //     continue;
            Console.WriteLine($"  {record.Timestamp:yyyy-MMMM-dd HH:mm:ss} | {record.Plugin} | {record.Event} | {record.Description}");
        }

        int packagesCount = records.Count(l => l.Plugin == Plugins.Packages);
        int filesCount = records.Count(l => l.Plugin == Plugins.Files);
        int smsCount = records.Count(l => l.Plugin == Plugins.SMS);

        Console.WriteLine($"\nFiles: {filesCount}");
        Console.WriteLine($"Packages: {packagesCount}");
        Console.WriteLine($"SMS: {smsCount}");
    }

    private static async Task<List<Record>> ParseFileAsync(string filePath)
    {
        List<Record> records = [];
        await foreach (string line in File.ReadLinesAsync(filePath, encoding).Skip(1))
        {
            Record? parsed = ParseRecord(line);
            if (parsed != null)
                records.Add(parsed);
        }

        return records;
    }

    private static Record? ParseRecord(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        string[] columns = SplitCsvLine(line);
        if (columns.Length < 4)
            return null;

        DateTime timestamp = DateTime.ParseExact(
            columns[0],
            DateFormats,
            cultureInfo,
            DateTimeStyles.None);

        Plugins plugin = Enum.Parse<Plugins>(columns[1]);
        Events evt = Enum.Parse<Events>(columns[2]);
        string description = columns[3];

        return new Record(timestamp, plugin, evt, description);
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

        return [.. result]; // array
    }

    private record Record(DateTime Timestamp, Plugins Plugin, Events Event, string Description);
}
