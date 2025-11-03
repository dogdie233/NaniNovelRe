using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

using NaniNovelRe.Models;
using NaniNovelRe.Serialization;

Console.WriteLine("owo");

var test = JsonSerializer.Deserialize<ScriptAssetRoot>("""
{
    "m_GameObject": {
        "fileID": 123456
    },
    "m_Enabled": 1,
    "m_Script": {
        "fileID": 654321
    },
    "m_Name": "ExampleScript",
    "path": "Assets/Scripts/ExampleScript.cs"
}
""", UAssetJsonContext.Default.ScriptAssetRoot);


