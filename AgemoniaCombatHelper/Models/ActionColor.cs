using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AgemoniaCombatHelper.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActionColor
{
    [EnumMember(Value = "Red")]
    Red,
    [EnumMember(Value = "Blue")]
    Blue,
    [EnumMember(Value = "Green")]
    Green
}
