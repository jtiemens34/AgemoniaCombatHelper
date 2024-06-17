namespace AgemoniaCombatHelper.Models;

public class Attack
{
    public AttackSymbol AttackSymbol { get; set; } = AttackSymbol.None;
    public HornModifier? HornModifier { get; set; }
    public int Movement { get; set; }
    public string? Name { get; set; }
    public string? Text { get; set; }
    public AttackType AttackType { get; set; }
}
