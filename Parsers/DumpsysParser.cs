using MvtParser.Models;

namespace MvtParser.Parsers;

public static class DumpsysParser
{
    public static async Task<List<string>> ParseServicesAsync(string filePath)
    {
        var services = new List<string>();
        var lines = await File.ReadAllLinesAsync(filePath);
        
        bool inServicesList = false;
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            
            if (trimmed.Equals("Currently running services:", StringComparison.OrdinalIgnoreCase))
            {
                inServicesList = true;
                continue;
            }
            
            if (inServicesList && trimmed.StartsWith("  "))
            {
                var serviceName = trimmed.Trim();
                if (!string.IsNullOrEmpty(serviceName))
                    services.Add(serviceName);
            }
            else if (inServicesList && !string.IsNullOrEmpty(trimmed))
            {
                break;
            }
        }
        
        return services;
    }
}