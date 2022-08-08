using Newtonsoft.Json;

namespace Minesharp.Chat.Component;

public class TranslationComponent : ChatComponent
{
    [JsonProperty("translate", NullValueHandling = NullValueHandling.Ignore)]
    public string Translate { get; init; }   
    
    [JsonProperty("with")]
    public ComponentCollection<TextComponent> With { get; }

    public TranslationComponent()
    {
        With = new ComponentCollection<TextComponent>(this);
    }
}