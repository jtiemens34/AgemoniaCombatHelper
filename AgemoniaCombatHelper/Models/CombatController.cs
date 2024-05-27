using AgemoniaCombatHelper.Pages;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace AgemoniaCombatHelper.Models;
public class CombatController
{
    private List<Hero> Heroes;
    private List<Enemy> Enemies;
    public List<Entity> TurnOrder;

    private CombatTracker CombatTracker;

    public delegate void TurnOrderUpdated();

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
        ArrangeEntities();
    }

    private void ArrangeEntities()
    {
        // TODO: Change logic to handle multiple entities from the same action color.
        if (ActiveCard is null) return;
        if (ActiveCard.Actions is null) return;
        TurnOrder.Clear();
        // Set enemies attack symbol
        foreach (var enemy in Enemies)
        {
            enemy.AttackSymbol = ActiveCard.Actions.Where(a => a.ActionColor == enemy.ActionColor && a.EntityType == EntityType.Enemy).FirstOrDefault().AttackSymbol;
        }
        // Arrange in correct turn order
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
        foreach (Hero unusedHero in Heroes)
        {
            if (!TurnOrder.Contains(unusedHero)) TurnOrder.Add(unusedHero);
        }
    }

    public void AddHero(Hero hero)
    {
        Heroes.Add(hero);
        ArrangeEntities();
        CombatTracker?.Refresh();
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
        ArrangeEntities();
        CombatTracker?.Refresh();
    }

    public List<Entity> GetEntities()
    {
        return TurnOrder;
    }

    public void SetCardsFromJson(InitiativeDeck deck)
    {
        InitiativeCards = deck;
    }

    public void SetCombatTracker(CombatTracker tracker)
    {
        CombatTracker = tracker;
    }
    public void RefreshDisplay()
    {
        CombatTracker.Refresh();
    }
}
