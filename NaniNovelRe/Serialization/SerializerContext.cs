using System.Text.Json.Serialization;

using NaniNovelRe.Models;

namespace NaniNovelRe.Serialization;

[JsonSerializable(typeof(ScriptAssetRoot))]
[JsonSourceGenerationOptions(Converters = [typeof(BoolAsIntConverter)], WriteIndented = true)]
internal partial class UAssetJsonContext : JsonSerializerContext
{
}