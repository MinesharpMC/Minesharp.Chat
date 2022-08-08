using Minesharp.Chat.Component;
using Newtonsoft.Json;

namespace Minesharp.Chat.Event;

public sealed class HoverEvent
{
    [JsonProperty("action")]
    public HoverEventAction ActionType { get; init; }
    
    [JsonProperty("value")]
    public TextComponent Value { get; init; }
}

public sealed class HoverEventAction
{
    private static readonly Dictionary<string, HoverEventAction> Values = new();
    
    public static readonly HoverEventAction ShowText = new("show_text");
    public static readonly HoverEventAction ShowItem = new("show_item");
    public static readonly HoverEventAction ShowEntity = new("show_entity");

    private readonly string name;

    private HoverEventAction(string name)
    {
        this.name = name;
        Values[name] = this;
    }

    public static HoverEventAction FromName(string name)
    {
        var action = Values.GetValueOrDefault(name);
        if (action is null)
        {
            throw new InvalidOperationException();
        }

        return action;
    }

    public override string ToString()
    {
        return name;
    }
}