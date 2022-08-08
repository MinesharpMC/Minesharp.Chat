using Minesharp.Chat.Event;
using Newtonsoft.Json;

namespace Minesharp.Chat.Json;

public class HoverEventActionConverter : JsonConverter<HoverEventAction>
{
    public override void WriteJson(JsonWriter writer, HoverEventAction value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }

    public override HoverEventAction ReadJson(JsonReader reader, Type objectType, HoverEventAction existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var name = reader.Value as string;
        if (name is null)
        {
            throw new InvalidOperationException();
        }
        
        return HoverEventAction.FromName(name);
    }
}