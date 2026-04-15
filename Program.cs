using System.Diagnostics;
using mvt_parser.Parsers;
using mvt_parser.Models;

internal class Program
{
    private const string SamplesPath = "./samples/";

    private static async Task Main()
    {
        Console.WriteLine("=== MVT Parser - Demo ===\n");

        await ParseTimelineAsync();
        await ParseFilesAsync();
        await ParsePackagesAsync();
        await ParseSmsAsync();
        await ParseSettingsAsync();
        await ParseGetpropAsync();
        await ParseProcessesAsync();
        await ParseInfoAsync();
        await ParseSelinuxAsync();
        await ParseLogcatAsync();
        await ParseCommandLogAsync();
        await ParseDumpsysAsync();
    }

    private static async Task ParseTimelineAsync()
    {
        Console.WriteLine("--- Timeline CSV ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<TimelineRecord> records = await TimelineParser.ParseAsync(SamplesPath + "timeline.csv");
        sw.Stop();
        Console.WriteLine($"Parsed {records.Count} records in {sw.ElapsedMilliseconds}ms");

        int packages = records.Count(r => r.Plugin == Plugins.Packages);
        int files = records.Count(r => r.Plugin == Plugins.Files);
        int sms = records.Count(r => r.Plugin == Plugins.SMS);

        Console.WriteLine($"  Files: {files}, Packages: {packages}, SMS: {sms}\n");
    }

    private static async Task ParseFilesAsync()
    {
        Console.WriteLine("--- Files JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<FileEntry> files = await FilesParser.ParseAsync(SamplesPath + "files.json");
        sw.Stop();
        Console.WriteLine($"Parsed {files.Count} files in {sw.ElapsedMilliseconds}ms");

        foreach (FileEntry f in files.Take(3))
            Console.WriteLine($"  {f.Path}");
        Console.WriteLine();
    }

    private static async Task ParsePackagesAsync()
    {
        Console.WriteLine("--- Packages JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<Package> packages = await PackagesParser.ParseAsync(SamplesPath + "packages.json");
        sw.Stop();
        Console.WriteLine($"Parsed {packages.Count} packages in {sw.ElapsedMilliseconds}ms");

        foreach (Package p in packages.Take(3))
            Console.WriteLine($"  {p.PackageName} (v{p.VersionName})");
        Console.WriteLine();
    }

    private static async Task ParseSmsAsync()
    {
        Console.WriteLine("--- SMS JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<SmsMessage> messages = await SmsParser.ParseAsync(SamplesPath + "sms.json");
        sw.Stop();
        Console.WriteLine($"Parsed {messages.Count} messages in {sw.ElapsedMilliseconds}ms");

        foreach (SmsMessage m in messages.Take(3))
        {
            string preview = m.Body?.Length > 50 ? m.Body[..50] + "..." : m.Body ?? "(empty)";
            Console.WriteLine($"  {m.Address}: {preview}");
        }
        Console.WriteLine();
    }

    private static async Task ParseSettingsAsync()
    {
        Console.WriteLine("--- Settings JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        SystemSettings settings = await SettingsParser.ParseAsync(SamplesPath + "settings.json");
        sw.Stop();
        Console.WriteLine($"Parsed settings in {sw.ElapsedMilliseconds}ms");

        int systemCount = settings.System?.Count ?? 0;
        int secureCount = settings.Secure?.Count ?? 0;
        int globalCount = settings.Global?.Count ?? 0;
        Console.WriteLine($"  System: {systemCount}, Secure: {secureCount}, Global: {globalCount}\n");
    }

    private static async Task ParseGetpropAsync()
    {
        Console.WriteLine("--- Getprop JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<AndroidProperty> props = await GetpropParser.ParseAsync(SamplesPath + "getprop.json");
        sw.Stop();
        Console.WriteLine($"Parsed {props.Count} properties in {sw.ElapsedMilliseconds}ms");

        foreach (AndroidProperty p in props.Take(5))
            Console.WriteLine($"  {p.Name} = {p.Value}");
        Console.WriteLine();
    }

    private static async Task ParseProcessesAsync()
    {
        Console.WriteLine("--- Processes JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<mvt_parser.Models.Process> processes = await ProcessesParser.ParseAsync(SamplesPath + "processes.json");
        sw.Stop();
        Console.WriteLine($"Parsed {processes.Count} processes in {sw.ElapsedMilliseconds}ms");

        foreach (mvt_parser.Models.Process p in processes.Take(5))
            Console.WriteLine($"  [{p.Pid}] {p.ProcName} ({p.User})");
        Console.WriteLine();
    }

    private static async Task ParseInfoAsync()
    {
        Console.WriteLine("--- Info JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        ExtractionInfo info = await InfoParser.ParseAsync(SamplesPath + "info.json");
        sw.Stop();
        Console.WriteLine($"Parsed info in {sw.ElapsedMilliseconds}ms");

        Console.WriteLine($"  MVT Version: {info.MvtVersion}");
        Console.WriteLine($"  Date: {info.Date}");
        Console.WriteLine($"  IOC Files: {info.IocFiles?.Count ?? 0}\n");
    }

    private static async Task ParseSelinuxAsync()
    {
        Console.WriteLine("--- SELinux Status JSON ---");
        Stopwatch sw = Stopwatch.StartNew();
        SelinuxStatus status = await SelinuxParser.ParseAsync(SamplesPath + "selinux_status.json");
        sw.Stop();
        Console.WriteLine($"Parsed in {sw.ElapsedMilliseconds}ms");

        Console.WriteLine($"  Status: {status.Status}\n");
    }

    private static async Task ParseLogcatAsync()
    {
        Console.WriteLine("--- Logcat TXT ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<LogEntry> entries = await LogcatParser.ParseAsync(SamplesPath + "logcat.txt");
        sw.Stop();
        Console.WriteLine($"Parsed {entries.Count} log entries in {sw.ElapsedMilliseconds}ms");

        foreach (LogEntry e in entries.Take(5))
            Console.WriteLine($"  [{e.Level}] {e.Tag}: {e.Message}");
        Console.WriteLine();
    }

    private static async Task ParseCommandLogAsync()
    {
        Console.WriteLine("--- Command Log ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<CommandLogEntry> entries = await CommandLogParser.ParseAsync(SamplesPath + "command.log");
        sw.Stop();
        Console.WriteLine($"Parsed {entries.Count} log entries in {sw.ElapsedMilliseconds}ms");

        foreach (CommandLogEntry e in entries.Take(5))
            Console.WriteLine($"  [{e.Level}] {e.Message}");
        Console.WriteLine();
    }

    private static async Task ParseDumpsysAsync()
    {
        // this functions is not completely, the original file has a lot of lines
        // and different properties, sections and styles
        Console.WriteLine("--- Dumpsys TXT ---");
        Stopwatch sw = Stopwatch.StartNew();
        List<string> services = await DumpsysParser.ParseServicesAsync(SamplesPath + "dumpsys.txt");
        sw.Stop();
        Console.WriteLine($"Parsed {services.Count} services in {sw.ElapsedMilliseconds}ms");

        foreach (string s in services.Take(10))
            Console.WriteLine($"  {s}");
        Console.WriteLine();
    }
}
