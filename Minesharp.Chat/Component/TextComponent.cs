using Newtonsoft.Json;

namespace Minesharp.Chat.Component;

public class TextComponent : ChatComponent
{
    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public string Text { get; init; }
}