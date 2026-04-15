namespace mvt_parser.Models;

public record DumpsysService(
    string Name,
    List<string>? Aliases
);
