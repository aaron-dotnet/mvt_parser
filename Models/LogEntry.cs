namespace MvtParser.Models;

public record LogEntry(
    string Timestamp,
    string Pid,
    string Tid,
    string Level,
    string Tag,
    string Message
);