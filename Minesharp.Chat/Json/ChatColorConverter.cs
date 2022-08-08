using Newtonsoft.Json;

namespace Minesharp.Chat.Json;

public class ChatColorConverter : JsonConverter<ChatColor>
{
    public override void WriteJson(JsonWriter writer, ChatColor value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }

    public override ChatColor ReadJson(JsonReader reader, Type objectType, ChatColor existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var name = reader.Value as string;
        if (name is null)
        {
            throw new InvalidOperationException();
        }

        return name[0] == '#' ? ChatColor.FromHexadecimal(name) : ChatColor.FromName(name);
    }
}