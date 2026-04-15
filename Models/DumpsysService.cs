namespace MvtParser.Models;

public record DumpsysService(
    string Name,
    List<string>? Aliases
);