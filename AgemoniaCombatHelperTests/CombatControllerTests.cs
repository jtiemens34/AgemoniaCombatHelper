using AgemoniaCombatHelper.Models;
using System.Text.Json;

namespace AgemoniaCombatHelperTests;
public class CombatControllerTests
{
    private readonly CombatController _controller = new();

    private readonly Hero _redPlayer = new(HeroClass.Torrax, 1);
    private readonly Hero _greenPlayer = new(HeroClass.Torrax, 1);
    private readonly Hero _bluePlayer = new(HeroClass.Torrax, 1);

    private readonly Enemy _redEnemy = new("", 5, 0);
    private readonly Enemy _greenEnemy = new("", 5, 0);
    private readonly Enemy _blueEnemy = new("", 5, 0);
    public CombatControllerTests()
    {
        _redPlayer.ActionColor = ActionColor.Red;
        _greenPlayer.ActionColor = ActionColor.Green;
        _bluePlayer.ActionColor = ActionColor.Blue;

        _redEnemy.ActionColor = ActionColor.Red;
        _greenEnemy.ActionColor = ActionColor.Green;
        _blueEnemy.ActionColor = ActionColor.Blue;

        _controller.AddHero(_redPlayer);
        _controller.AddHero(_greenPlayer);
        _controller.AddHero(_bluePlayer);

        _controller.AddEnemy(_redEnemy);
        _controller.AddEnemy(_greenEnemy);
        _controller.AddEnemy(_blueEnemy);

        string jsonFile = File.ReadAllText("InitiativeCards.json");
        InitiativeDeck deck = JsonSerializer.Deserialize<InitiativeDeck>(jsonFile);
        _controller.SetCardsFromJson(deck);
    }
    [Fact]
    public void CorrectOrder()
    {
        _controller.DrawNewCard();

        List<Entity> TurnOrder = _controller.GetEntities();

        Assert.True(TurnOrder[0].Equals(_blueEnemy));
        Assert.True(TurnOrder[1].Equals(_redPlayer));
        Assert.True(TurnOrder[2].Equals(_redEnemy));
        Assert.True(TurnOrder[3].Equals(_bluePlayer));
        Assert.True(TurnOrder[4].Equals(_greenPlayer));
        Assert.True(TurnOrder[5].Equals(_greenEnemy));
    }
}
