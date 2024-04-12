
namespace AgemoniaCombatHelper.Models;

public class Enemy(int health, int provokeDamage, int provokeRange = 0) : Entity
{
    public int Health { get; set; } = health;
    public int ProvokeDamage { get; set; } = provokeDamage;
    public int ProvokeRange { get; set; } = provokeRange;
    public EnemyAttack? EnemyAttack { get; set; }
}
