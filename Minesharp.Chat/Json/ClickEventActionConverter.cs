using Minesharp.Chat.Event;
using Newtonsoft.Json;

namespace Minesharp.Chat.Json;

public class ClickEventActionConverter : JsonConverter<ClickEventAction>
{
    public override void WriteJson(JsonWriter writer, ClickEventAction value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }

    public override ClickEventAction ReadJson(JsonReader reader, Type objectType, ClickEventAction existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var name = reader.Value as string;
        if (name is null)
        {
            throw new InvalidOperationException();
        }
        
        return ClickEventAction.FromName(name);
    }
}