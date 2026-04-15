using System.Text.Json.Serialization;

namespace mvt_parser.Models;

public record Process(
    [property: JsonPropertyName("user")]
    string User,
    [property: JsonPropertyName("pid")]
    int Pid,
    [property: JsonPropertyName("ppid")]
    int Ppid,
    [property: JsonPropertyName("virtual_memory_size")]
    long VirtualMemorySize,
    [property: JsonPropertyName("resident_set_size")]
    int ResidentSetSize,
    [property: JsonPropertyName("wchan")]
    string Wchan,
    [property: JsonPropertyName("aprocress")]
    string Aprocress,
    [property: JsonPropertyName("stat")]
    string Stat,
    [property: JsonPropertyName("proc_name")]
    string ProcName,
    [property: JsonPropertyName("label")]
    string Label
);
