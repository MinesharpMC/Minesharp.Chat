using Newtonsoft.Json;

namespace Minesharp.Chat.Event;

public sealed class ClickEvent
{
    [JsonProperty("action")]
    public ClickEventAction ActionType { get; init; }
    
    [JsonProperty("value")]
    public string Value { get; init; }
}

public sealed class ClickEventAction
{
    public static readonly ClickEventAction OpenUrl = new("open_url");
    public static readonly ClickEventAction OpenFile = new("open_file");
    public static readonly ClickEventAction RunCommand = new("run_command");
    public static readonly ClickEventAction SuggestCommand = new("suggest_command");
    public static readonly ClickEventAction ChangePage = new("change_page");
    public static readonly ClickEventAction CopyToClipboard = new("copy_to_clipboard");

    private readonly string name;

    private static readonly Dictionary<string, ClickEventAction> Values = new();

    private ClickEventAction(string name)
    {
        this.name = name;
        Values[name] = this;
    }

    public static ClickEventAction FromName(string name)
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