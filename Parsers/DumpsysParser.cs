using mvt_parser.Models;

namespace mvt_parser.Parsers;

public static class DumpsysParser
{
    public static async Task<List<string>> ParseServicesAsync(string filePath)
    {
        List<string> services = [];
        string[] lines = await File.ReadAllLinesAsync(filePath);

        bool inServicesList = false;
        foreach (string line in lines)
        {
            string trimmed = line.Trim();

            if (trimmed.Equals("Currently running services:", StringComparison.OrdinalIgnoreCase))
            {
                inServicesList = true;
                continue;
            }

            if (inServicesList && !string.IsNullOrEmpty(trimmed) && !trimmed.Contains(':'))
            {
                services.Add(trimmed);
            }
            else if (inServicesList && !string.IsNullOrEmpty(trimmed) && trimmed.Contains(':'))
            {
                break;
            }
        }

        return services;
    }
}
