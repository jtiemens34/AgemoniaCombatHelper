using AgemoniaCombatHelper.Models;

namespace AgemoniaCombatHelperTests;
public class HeroDamageTests
{
    private readonly Hero _hero = new(HeroClass.Torrax, 1);
    [Fact]
    public void AllUnspentStaminaDamage()
    {
        _hero.TakeDamage(3);
        Assert.Equal(7, _hero.Stamina);
        Assert.Equal(3, _hero.Damage);
    }
    [Fact]
    public void AllSpentStaminaDamage()
    {
        _hero.Stamina = 0;
        _hero.SpentStamina = 5;

        _hero.TakeDamage(3);

        Assert.Equal(2, _hero.SpentStamina);
        Assert.Equal(3, _hero.Damage);
    }
    [Fact]
    public void MixedDamage()
    {
        _hero.Stamina = 2;
        _hero.SpentStamina = 3;

        _hero.TakeDamage(3);

        Assert.Equal(0, _hero.Stamina);
        Assert.Equal(2, _hero.SpentStamina);
        Assert.Equal(3, _hero.Damage);
    }
    [Fact]
    public void Wound()
    {
        _hero.Stamina = 0;
        _hero.SpentStamina = 0;
        _hero.Damage = 10;

        _hero.TakeDamage(1);

        Assert.True(_hero.Wounded);
        Assert.Equal(5, _hero.Stamina);
        Assert.Equal(0, _hero.SpentStamina);
        Assert.Equal(0, _hero.Damage);
    }
    [Fact]
    public void Exhaust()
    {
        _hero.Stamina = 0;
        _hero.SpentStamina = 0;
        _hero.Damage = 5;
        _hero.Wounded = true;

        _hero.TakeDamage(1);

        Assert.True(_hero.Exhausted);
    }
    [Fact]
    public void HealDamage()
    {
        _hero.Stamina = 3;
        _hero.Damage = 2;

        _hero.HealDamage(2);

        Assert.Equal(5, _hero.Stamina);
        Assert.Equal(0, _hero.Damage);
    }
    [Fact]
    public void HealDamageOverflow()
    {
        _hero.Stamina = 3;
        _hero.Damage = 2;

        _hero.HealDamage(3);

        Assert.Equal(5, _hero.Stamina);
        Assert.Equal(0, _hero.Damage);
    }
    [Fact]
    public void HealDamageUnderflow()
    {
        _hero.HealDamage(1);

        Assert.Equal(10, _hero.Stamina);
        Assert.Equal(0, _hero.Damage);
    }
}