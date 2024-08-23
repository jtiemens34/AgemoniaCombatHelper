using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AgemoniaCombatHelper.Models.Entities.Enemy;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AttackType
{
    [EnumMember(Value = "Melee")]
    Melee,
    [EnumMember(Value = "Ranged")]
    Ranged,
    [EnumMember(Value = "Magic")]
    Magic,
    [EnumMember(Value = "None")]
    None
}
