# Minesharp.Chat
```csharp
public static void Main(string[] args)
{
    var component = new TextComponent
    {
        Text = "Minesharp",
        Color = ChatColor.FromColor(Color.Red),
        ClickEvent = new ClickEvent
        {
            ActionType = ClickEventAction.OpenUrl,
            Value = "https://github.com/orgs/MinesharpMC"
        }
    };

    var json = component.ToJson();
}
```
