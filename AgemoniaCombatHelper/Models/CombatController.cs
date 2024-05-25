using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace AgemoniaCombatHelper.Models;
public class CombatController : ICombatService
{
    private List<Hero> Heroes;
    private List<Enemy> Enemies;
    private List<Entity> TurnOrder;

    public InitiativeCard? ActiveCard { get; private set; }
    private InitiativeDeck? InitiativeCards;
    private InitiativeDeck? Discard;


    public CombatController()
    {
        Heroes = [];
        Enemies = [];
        TurnOrder = [];
    }
    public void DrawNewCard()
    {
        ActiveCard = InitiativeCards?.Data?[0];
        if (ActiveCard is null) return;
        if (ActiveCard.Actions is null) return;
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

    public void AddHero(Hero hero)
    {
        Heroes.Add(hero);
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }

    public List<Entity> GetEntities()
    {
        return TurnOrder;
    }

    public void SetCardsFromJson(InitiativeDeck deck)
    {
        InitiativeCards = deck;
    }
}
