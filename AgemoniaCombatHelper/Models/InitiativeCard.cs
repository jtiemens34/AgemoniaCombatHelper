namespace AgemoniaCombatHelper.Models;
public class InitiativeCard()
{
    public bool Shuffle { get; set; }
    public IList<Action>? Actions { get; set; }
}