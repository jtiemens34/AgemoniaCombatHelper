namespace AgemoniaCombatHelper.Models.Initiative;
public class Action()
{
    public ActionColor ActionColor { get; set; }
    public Modifier Modifier { get; set; } = Modifier.None;
    public EntityType EntityType { get; set; }
    public AttackSymbol AttackSymbol { get; set; } = AttackSymbol.None;
}
