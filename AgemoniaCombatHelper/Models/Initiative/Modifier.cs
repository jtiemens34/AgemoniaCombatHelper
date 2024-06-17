using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AgemoniaCombatHelper.Models.Initiative;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Modifier
{
    [EnumMember(Value = "None")]
    None,
    [EnumMember(Value = "Snake")]
    Snake,
    [EnumMember(Value = "Horns")]
    Horns,
    [EnumMember(Value = "SnakeAndHorns")]
    SnakeAndHorns,
    [EnumMember(Value = "ExtraManeuver")]
    ExtraManeuver
}