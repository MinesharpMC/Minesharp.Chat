using System.Reflection;
using Minesharp.Chat.Component;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Minesharp.Chat.Json;

public class ShouldSerializeContractResolver : DefaultContractResolver
{
    public static readonly ShouldSerializeContractResolver Instance = new();

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        
        if (typeof(ChatComponent).IsAssignableFrom(property.DeclaringType) && property.PropertyName == "extra" || property.PropertyName == "with")
        {
            property.ShouldSerialize = x =>
            {
                var component = (ChatComponent)x;
                return component.Extra.Count > 0;
            };
        }

        return property;
    }
}