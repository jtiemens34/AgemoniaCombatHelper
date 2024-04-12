using System.Text.Json;

namespace AgemoniaCombatHelper.Models;
public class InitiativeDeck
{
    public List<InitiativeCard>? Data { get; set; }
}
public class CombatController
{
    public List<Hero> Heroes { get; set; }
    public List<Enemy> Enemies { get; set; }

    public List<Entity> TurnOrder { get; private set; }

    public InitiativeCard? ActiveCard { get; private set; }
    private InitiativeDeck? InitiativeCards;
    private InitiativeDeck? Discard;

    public CombatController()
    {
        Heroes = [];
        Enemies = [];
        TurnOrder = [];
        string jsonFile = File.ReadAllText("Data/InitiativeCards.json");
        InitiativeCards = JsonSerializer.Deserialize<InitiativeDeck>(jsonFile);
    }
    public void DrawNewCard()
    {
        ActiveCard = InitiativeCards.Data[0];
        foreach (Action action in ActiveCard.Actions)
        {
            if (action.EntityType == EntityType.Hero && Heroes.Any(h => h.ActionColor == action.ActionColor))
            {
                TurnOrder.Add(Heroes.Find(h => h.ActionColor == action.ActionColor));
            }
            if (action.EntityType == EntityType.Enemy && Enemies.Any(e => e.ActionColor == action.ActionColor))
            {
                TurnOrder.Add(Enemies.Find(e => e.ActionColor == action.ActionColor));
            }
        }
    }
}
