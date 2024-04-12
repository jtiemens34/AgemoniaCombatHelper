using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AgemoniaCombatHelper.Models;
public class Action()
{
    public ActionColor ActionColor { get; set; }
    public Modifier Modifier { get; set; } = Modifier.None;
    public EntityType EntityType { get; set; }
    public AttackSymbol AttackSymbol { get; set; } = AttackSymbol.None;
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EntityType
{
    [EnumMember(Value = "Hero")]
    Hero,
    [EnumMember(Value = "Enemy")]
    Enemy
}
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