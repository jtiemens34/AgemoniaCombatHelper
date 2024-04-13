
namespace AgemoniaCombatHelper.Models;

public class Enemy(string name, int health, int provokeDamage, int provokeRange = 0) : Entity
{
    public string Name { get; set; } = name;
    public int Health { get; set; } = health;
    public int ProvokeDamage { get; set; } = provokeDamage;
    public int ProvokeRange { get; set; } = provokeRange;
    public EnemyAttack? EnemyAttack { get; set; }
}
