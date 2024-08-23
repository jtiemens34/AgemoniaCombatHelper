using AgemoniaCombatHelper.Models.Initiative;

namespace AgemoniaCombatHelper.Models.Entities.Enemy;

public class Attack
{
    public AttackSymbol AttackSymbol { get; set; } = AttackSymbol.None;
    public HornModifier? HornModifier { get; set; }
    public int Movement { get; set; }
    public string? Name { get; set; }
    public string? Text { get; set; }
    public AttackType Type { get; set; }
}
