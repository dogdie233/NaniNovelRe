using System.Text.Json;
using System.Text.Json.Serialization;

namespace NaniNovelRe.Serialization;

internal class BoolAsIntConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out int intValue))
        {
            return intValue != 0;
        }
        throw new JsonException("Expected integer value for boolean conversion.");
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value ? 1 : 0);
    }
}