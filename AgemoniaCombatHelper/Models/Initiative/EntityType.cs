using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AgemoniaCombatHelper.Models.Initiative;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EntityType
{
    [EnumMember(Value = "Hero")]
    Hero,
    [EnumMember(Value = "Enemy")]
    Enemy
}
