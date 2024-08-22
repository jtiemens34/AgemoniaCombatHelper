using AgemoniaCombatHelper.Models.Initiative;

namespace AgemoniaCombatHelper.Models.Entities.Enemy;

public class Enemy : Entity
{
    public string? Name { get; set; }
    public int Armor { get; set; }
    public List<Attack>? Attacks { get; set; }
    public int HPBase { get; set; }
    public int HPMultiplier { get; set; }
    public string? Drops { get; set; }
    public int RetaliateAmount { get; set; }
    public int RetaliateRange { get; set; }
    public List<string>? Tags { get; set; }
    public Modifier Modifier { get; set; } = Modifier.None;
    public SnakeModifier? SnakeModifier { get; set; }
    public AttackSymbol SelectedAttackSymbol { get; set; } = AttackSymbol.None;
}
