using System.Text.Json.Serialization;

namespace MvtParser.Models;

public record SmsMessage(
    [property: JsonPropertyName("address")]
    string Address,
    [property: JsonPropertyName("body")]
    string Body,
    [property: JsonPropertyName("date")]
    string Date,
    [property: JsonPropertyName("date_sent")]
    string DateSent,
    [property: JsonPropertyName("status")]
    string Status,
    [property: JsonPropertyName("type")]
    string Type,
    [property: JsonPropertyName("recipients")]
    List<string>? Recipients,
    [property: JsonPropertyName("read")]
    string Read,
    [property: JsonPropertyName("isodate")]
    string IsoDate,
    [property: JsonPropertyName("direction")]
    string Direction
);