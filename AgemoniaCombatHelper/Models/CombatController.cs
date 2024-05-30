using AgemoniaCombatHelper.Pages;

namespace AgemoniaCombatHelper.Models;
public class CombatController
{
    private List<Hero> Heroes;
    private List<Enemy> Enemies;
    private Scenarios? Scenarios;
    public List<Entity> TurnOrder;

    private CombatTracker? CombatTracker;

    public delegate void TurnOrderUpdated();

    public InitiativeCard? ActiveCard { get; private set; }
    private InitiativeDeck? InitiativeCards;
    private InitiativeDeck? Discard;
    private Random rng = new Random();

    public CombatController()
    {
        Heroes = [];
        Enemies = [];
        TurnOrder = [];
        Discard = new()
        {
            Data = []
        };
    }
    public void DrawNewCard()
    {
        // Do we need to shuffle?
        if (Discard.Data.Exists(c => c.Shuffle == true))
        {
            InitiativeCards.Data.AddRange(Discard.Data);
            Discard.Data.Clear();
            Shuffle();
        }
        if (ActiveCard is not null) Discard.Data.Add(ActiveCard);
        ActiveCard = InitiativeCards!.Data![0];
        InitiativeCards.Data.RemoveAt(0);
        ArrangeEntities();
    }
    private void Shuffle()
    {
        int n = InitiativeCards.Data.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            InitiativeCard value = InitiativeCards.Data[k];
            InitiativeCards.Data[k] = InitiativeCards.Data[n];
            InitiativeCards.Data[n] = value;
        }
    }

    public void ArrangeEntities()
    {
        TurnOrder.Clear();
        // If no card has been drawn, simply add enemies and heroes
        if (ActiveCard is null)
        {
            foreach (var enemy in Enemies) TurnOrder.Add(enemy);
            foreach (var hero in Heroes) TurnOrder.Add(hero);
            return;
        }
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
                TurnOrder.AddRange(Heroes.FindAll(h => h.ActionColor == action.ActionColor));
            }
            if (action.EntityType == EntityType.Enemy && Enemies.Any(e => e.ActionColor == action.ActionColor))
            {
                TurnOrder.AddRange(Enemies.FindAll(e => e.ActionColor == action.ActionColor));
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
        foreach (var enemy in Enemies) enemy.SetInitialHP(Heroes.Count);
        ArrangeEntities();
        CombatTracker?.Refresh();
    }

    public void AddEnemy(Enemy enemy)
    {
        enemy.SetInitialHP(Heroes.Count);
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
        Shuffle();
    }
    public void SetScenariosFromJson(Scenarios scenarios)
    {
        Scenarios = scenarios;
    }

    public void LoadScenario(int scenarioNumber)
    {
        Enemies.Clear();
        if (scenarioNumber == 1) return;
        List<Enemy> enemiesToLoad = Scenarios.Data.Where(s => s.ScenarioNumber == scenarioNumber).First().Enemies;
        foreach (var enemy in enemiesToLoad) AddEnemy(enemy);
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
