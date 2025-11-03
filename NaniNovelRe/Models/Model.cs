using System.Text.Json;
using System.Text.Json.Serialization;

using NaniNovelRe.Serialization;

namespace NaniNovelRe.Models;

public class ScriptAssetRoot
{
    // Unity asset common properties
    [JsonPropertyName("m_GameObject")] public ExternalRef GameObject { get; set; }
    [JsonPropertyName("m_Enabled")] public bool Enabled { get; set; }
    [JsonPropertyName("m_Script")] public ExternalRef Script { get; set; }
    [JsonPropertyName("m_Name")] public string Name { get; set; }
    
    // NaniNovel script asset properties
    [JsonPropertyName("path")] public string Path { get; set; }
    [JsonPropertyName("textMap")] public TextMap TextMap { get; set; }
    [JsonPropertyName("playlist")] public PlayList PlayList { get; set; }
    [JsonPropertyName("lines")] [JsonConverter(typeof(UnityArrayConverter<InternalRef>))] public List<InternalRef> Lines { get; set; } = [];
    
    // Unity reference map
    [JsonPropertyName("References")] public ReferenceMap References { get; set; } = new();
}

public class ExternalRef
{
    [JsonPropertyName("m_FileID")] public long FileId { get; set; }
    [JsonPropertyName("m_PathID")] public long PathId { get; set; }
}

public class InternalRef
{
    [JsonPropertyName("rid")] public long Rid { get; set; }
}

public class ReferenceMap
{
    [JsonPropertyName("version")] public int Version { get; set; } = 2;
    [JsonPropertyName("RefIds")] public List<ReferenceMapEntry> RefIds { get; set; } = [];
}

public class ReferenceMapEntry
{
    [JsonPropertyName("rid")] public long Rid { get; set; }
    [JsonPropertyName("type")] public RefTypeDesc TypeDesc { get; set; }
    [JsonPropertyName("data")] public JsonDocument Data { get; set; }
}

public class RefTypeDesc
{
    [JsonPropertyName("class")] public string Class { get; set; }
    [JsonPropertyName("ns")] public string Namespace { get; set; }
    [JsonPropertyName("asm")] public string Assembly { get; set; }
}

public class TextMap
{
    [JsonPropertyName("keys")]
    [JsonConverter(typeof(UnityArrayConverter<string>))]
    public List<string> Keys { get; set; } = [];

    [JsonPropertyName("values")]
    [JsonConverter(typeof(UnityArrayConverter<string>))]
    public List<string> Values { get; set; } = [];
}

public class PlayList
{
    [JsonPropertyName("scriptPath")] public string ScriptPath { get; set; }
    [JsonPropertyName("commands")] [JsonConverter(typeof(UnityArrayConverter<InternalRef>))] public List<InternalRef> Commands { get; set; } = [];
}