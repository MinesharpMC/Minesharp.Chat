using Minesharp.Chat.Event;
using Minesharp.Chat.Json;
using Newtonsoft.Json;

namespace Minesharp.Chat.Component;

public class ChatComponent
{
    private bool? bold;
    private bool? italic;
    private bool? strikethrough;
    private bool? obfuscated;
    private ChatColor color;
    private string font;
    private string insertion;
    private ClickEvent clickEvent;
    private HoverEvent hoverEvent;

    [JsonProperty("bold", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsBold
    {
        get => bold ?? Parent?.bold;
        set => bold = value;
    } 

    [JsonProperty("italic", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsItalic
    {
        get => italic ?? Parent?.italic;
        set => italic = value;
    }

    [JsonProperty("strikethrough", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsStrikeThrough
    {
        get => strikethrough ?? Parent?.strikethrough;
        set => strikethrough = value;
    }

    [JsonProperty("obfuscated", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsObfuscated
    {
        get => obfuscated ?? Parent?.obfuscated;
        set => obfuscated = value;
    }

    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public ChatColor Color
    {
        get => color ?? Parent?.color;
        set => color = value;
    }

    [JsonProperty("font", NullValueHandling = NullValueHandling.Ignore)]
    public string Font
    {
        get => font ?? Parent?.font;
        set => font = value;
    }

    [JsonProperty("insertion", NullValueHandling = NullValueHandling.Ignore)]
    public string Insertion
    {
        get => insertion ?? Parent?.insertion;
        set => insertion = value;
    }
    
    [JsonProperty("clickEvent", NullValueHandling = NullValueHandling.Ignore)]
    public ClickEvent ClickEvent
    {
        get => clickEvent ?? Parent?.clickEvent;
        set => clickEvent = value;
    }
    
    [JsonProperty("hoverEvent", NullValueHandling = NullValueHandling.Ignore)]
    public HoverEvent HoverEvent
    {
        get => hoverEvent ?? Parent?.hoverEvent;
        set => hoverEvent = value;
    }
    
    [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
    public ComponentCollection<ChatComponent> Extra { get; }

    [JsonIgnore]
    public ChatComponent Parent { get; internal set; }

    public ChatComponent()
    {
        Extra = new ComponentCollection<ChatComponent>(this);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new ChatColorConverter(),
                new HoverEventActionConverter(),
                new ClickEventActionConverter()
            },
            ContractResolver = ShouldSerializeContractResolver.Instance
        });
    }
}