using AgemoniaCombatHelper.Models;

namespace AgemoniaCombatHelperTests;
public class HeroStaminaTests
{
    private readonly Hero _hero = new(HeroClass.Torrax, 1);
    [Fact]
    public void ShouldSpend()
    {
        bool success = _hero.SpendStamina(3);

        Assert.True(success);
        Assert.Equal(7, _hero.Stamina);
        Assert.Equal(3, _hero.SpentStamina);
    }
    [Fact]
    public void ShouldFail()
    {
        bool success = _hero.SpendStamina(11);

        Assert.False(success);
        Assert.Equal(10, _hero.Stamina);
    }
    [Fact]
    public void ShouldRecover()
    {
        _hero.Stamina = 2;
        _hero.SpentStamina = 3;

        _hero.RecoverStamina(3);

        Assert.Equal(0, _hero.SpentStamina);
        Assert.Equal(5, _hero.Stamina);
    }
    [Fact]
    public void RecoverOverlow()
    {
        _hero.Stamina = 2;
        _hero.SpentStamina = 3;

        _hero.RecoverStamina(4);

        Assert.Equal(0, _hero.SpentStamina);
        Assert.Equal(5, _hero.Stamina);
    }
    [Fact]
    public void RecoverUnderflow()
    {
        _hero.RecoverStamina(1);

        Assert.Equal(10, _hero.Stamina);
        Assert.Equal(0, _hero.SpentStamina);
    }
}
