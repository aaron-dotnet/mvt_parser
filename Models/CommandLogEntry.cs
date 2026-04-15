namespace MvtParser.Models;

public record CommandLogEntry(
    string Timestamp,
    string Module,
    string Level,
    string Message
);