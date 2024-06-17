using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AgemoniaCombatHelper.Models.Initiative;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AttackSymbol
{
    [EnumMember(Value = "FullyOpen")]
    FullyOpen,
    [EnumMember(Value = "HalfOpen")]
    HalfOpen,
    [EnumMember(Value = "Squint")]
    Squint,
    [EnumMember(Value = "None")]
    None
}
