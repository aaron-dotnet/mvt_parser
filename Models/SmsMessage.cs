using System.Text.Json.Serialization;

namespace mvt_parser.Models;

public record MmsAddress(
    [property: JsonPropertyName("type")]
    int Type,
    [property: JsonPropertyName("address")]
    string Address,
    [property: JsonPropertyName("charset")]
    int Charset
);

public record SmsMessage(
    [property: JsonPropertyName("address")]
    string? Address,
    [property: JsonPropertyName("body")]
    string? Body,
    [property: JsonPropertyName("date")]
    string? Date,
    [property: JsonPropertyName("date_sent")]
    string? DateSent,
    [property: JsonPropertyName("status")]
    string? Status,
    [property: JsonPropertyName("type")]
    string? Type,
    [property: JsonPropertyName("recipients")]
    List<string>? Recipients,
    [property: JsonPropertyName("read")]
    string? Read,
    [property: JsonPropertyName("isodate")]
    string? IsoDate,
    [property: JsonPropertyName("direction")]
    string? Direction,
    [property: JsonPropertyName("sub")]
    string? Sub,
    [property: JsonPropertyName("m_type")]
    string? MType,
    [property: JsonPropertyName("msg_box")]
    string? MsgBox,
    [property: JsonPropertyName("tr_id")]
    string? TrId,
    [property: JsonPropertyName("mms_addresses")]
    List<MmsAddress>? MmsAddresses,
    [property: JsonPropertyName("mms_charset")]
    int? MmsCharset,
    [property: JsonPropertyName("sub_cs")]
    string? SubCs
);
