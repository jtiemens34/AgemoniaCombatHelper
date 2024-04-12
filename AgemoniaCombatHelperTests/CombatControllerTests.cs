using AgemoniaCombatHelper.Models;

namespace AgemoniaCombatHelperTests;
public class CombatControllerTests
{
    private readonly CombatController _controller = new();

    private readonly Hero _redPlayer = new(HeroClass.Torrax, 1);
    private readonly Hero _greenPlayer = new(HeroClass.Torrax, 1);
    private readonly Hero _bluePlayer = new(HeroClass.Torrax, 1);

    private readonly Enemy _redEnemy = new(5, 0);
    private readonly Enemy _greenEnemy = new(5, 0);
    private readonly Enemy _blueEnemy = new(5, 0);
    public CombatControllerTests()
    {
        _redPlayer.ActionColor = ActionColor.Red;
        _greenPlayer.ActionColor = ActionColor.Green;
        _bluePlayer.ActionColor = ActionColor.Blue;

        _redEnemy.ActionColor = ActionColor.Red;
        _greenEnemy.ActionColor = ActionColor.Green;
        _blueEnemy.ActionColor = ActionColor.Blue;

        _controller.Heroes.Add(_redPlayer);
        _controller.Heroes.Add(_greenPlayer);
        _controller.Heroes.Add(_bluePlayer);

        _controller.Enemies.Add(_redEnemy);
        _controller.Enemies.Add(_greenEnemy);
        _controller.Enemies.Add(_blueEnemy);
    }
    [Fact]
    public void CorrectOrder()
    {
        _controller.DrawNewCard();

        Assert.True(_controller.TurnOrder[0].Equals(_blueEnemy));
        Assert.True(_controller.TurnOrder[1].Equals(_redPlayer));
        Assert.True(_controller.TurnOrder[2].Equals(_redEnemy));
        Assert.True(_controller.TurnOrder[3].Equals(_bluePlayer));
        Assert.True(_controller.TurnOrder[4].Equals(_greenPlayer));
        Assert.True(_controller.TurnOrder[5].Equals(_greenEnemy));
    }
}
