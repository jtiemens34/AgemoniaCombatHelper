namespace AgemoniaCombatHelper.Models;

public class Enemy : Entity
{
    public string? Name { get; set; }
    public string? ImagePath { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Health { get; set; }
    public int HPBase { get; set; }
    public int HPMultiplier { get; set; }
    public AttackSymbol AttackSymbol { get; set; } = AttackSymbol.None;
    public Modifier Modifier { get; set; } = Modifier.None;
    public void SetInitialHP(int playerCount)
    {
        Health = HPMultiplier > 0 ? playerCount * HPMultiplier + HPBase : HPBase;
    }
}
