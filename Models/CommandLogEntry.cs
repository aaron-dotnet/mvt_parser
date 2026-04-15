namespace mvt_parser.Models;

public record CommandLogEntry(
    string Timestamp,
    string Module,
    string Level,
    string Message
);
