namespace AgemoniaCombatHelper.Models.Entities.Enemy;

public class EnemyInstance(int playerCount, Enemy EnemyType)
{
    public int Health { get; set; } = EnemyType.HPMultiplier > 0 ? playerCount * EnemyType.HPMultiplier + EnemyType.HPBase : EnemyType.HPBase;
}
