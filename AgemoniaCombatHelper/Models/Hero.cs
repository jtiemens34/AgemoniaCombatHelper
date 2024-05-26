using System.ComponentModel.DataAnnotations;

namespace AgemoniaCombatHelper.Models;

public class Hero : Entity
{
    [Required]
    public HeroClass HeroClass { get; set; }
    [Required, Range(minimum:1, maximum:5)]
    public int Level { get; set; }
    public int Stamina { get; set; }
    private readonly int WoundedStamina;
    public int SpentStamina { get; set; } = 0;
    public int Damage { get; set; } = 0;
    public bool Wounded { get; set; } = false;
    public bool Exhausted { get; set; } = false;
    public Hero(HeroClass heroClass, int level)
    {
        HeroClass = heroClass;
        Level = level;
        switch (heroClass)
        {
            case HeroClass.Torrax: Stamina = 10; break;
            case HeroClass.Venia: Stamina = 7; break;
            case HeroClass.Jonai: Stamina = 8; break;
            case HeroClass.Lunara: Stamina = 9; break;
            case HeroClass.Matajam: Stamina = 8; break;
            case HeroClass.Drenosh: Stamina = 9; break;
            case HeroClass.ZuvaSai: Stamina = 8; break;
        }
        Stamina += level - 1;
        WoundedStamina = (int)Math.Ceiling((double)Stamina / 2.0f);
    }

    public bool SpendStamina(int staminaToSpend)
    {
        if (staminaToSpend > Stamina) return false;
        Stamina -= staminaToSpend;
        SpentStamina += staminaToSpend;
        return true;
    }
    public void RecoverStamina(int staminaToRecover)
    {
        Stamina += staminaToRecover > SpentStamina ? SpentStamina : staminaToRecover;
        SpentStamina -= staminaToRecover > SpentStamina ? SpentStamina : staminaToRecover;
    }
    public void TakeDamage(int damageToTake)
    {
        // Damage can be dealt to unspent stamina
        if (damageToTake <= Stamina)
        {
            Stamina -= damageToTake;
            Damage += damageToTake;
        }
        // Damage dealt to spent stamina
        else if (damageToTake > Stamina && damageToTake <= Stamina + SpentStamina)
        {
            int damageResolved = 0;
            if (Stamina > 0)
            {
                damageResolved += Stamina;
                Damage += Stamina;
                Stamina = 0;
            }
            Damage += damageToTake - damageResolved;
            SpentStamina -= damageToTake - damageResolved;
        }
        // If there is still damage to be dealt, the hero is wounded.
        else Wound();
    }
    public void HealDamage(int damageToHeal)
    {
        Stamina += damageToHeal > Damage ? Damage : damageToHeal;
        Damage -= damageToHeal > Damage ? Damage : damageToHeal;
    }
    private void Wound()
    {
        if (Wounded) Exhausted = true;
        Stamina = WoundedStamina;
        Damage = 0;
        SpentStamina = 0;
        Wounded = true;
    }
}
