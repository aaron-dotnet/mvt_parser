using System.Text.Json.Serialization;

namespace MvtParser.Models;

public record ApkFile(
    [property: JsonPropertyName("path")]
    string Path,
    [property: JsonPropertyName("md5")]
    string? Md5,
    [property: JsonPropertyName("sha1")]
    string? Sha1,
    [property: JsonPropertyName("sha256")]
    string? Sha256,
    [property: JsonPropertyName("sha512")]
    string? Sha512
);

public record PackagePermission(
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("granted")]
    bool Granted,
    [property: JsonPropertyName("type")]
    string Type
);

public record Package(
    [property: JsonPropertyName("package_name")]
    string PackageName,
    [property: JsonPropertyName("file_name")]
    string FileName,
    [property: JsonPropertyName("installer")]
    string? Installer,
    [property: JsonPropertyName("disabled")]
    bool Disabled,
    [property: JsonPropertyName("system")]
    bool System,
    [property: JsonPropertyName("third_party")]
    bool ThirdParty,
    [property: JsonPropertyName("files")]
    List<ApkFile>? Files,
    [property: JsonPropertyName("uid")]
    string? Uid,
    [property: JsonPropertyName("version_name")]
    string? VersionName,
    [property: JsonPropertyName("version_code")]
    string? VersionCode,
    [property: JsonPropertyName("timestamp")]
    string? Timestamp,
    [property: JsonPropertyName("first_install_time")]
    string? FirstInstallTime,
    [property: JsonPropertyName("last_update_time")]
    string? LastUpdateTime,
    [property: JsonPropertyName("permissions")]
    List<PackagePermission>? Permissions
);