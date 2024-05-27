namespace AgemoniaCombatHelper.Models;

public class Enemy : Entity
{
    public string Name { get; set; }
    public int Health { get; set; }
    public string ImagePath { get; set; }
    public AttackSymbol AttackSymbol { get; set; }
    public Enemy(string name, ActionColor actionColor, int health, string imagePath)
    {
        Name = name;
        ActionColor = actionColor;
        Health = health;
        ImagePath = imagePath;
        AttackSymbol = AttackSymbol.None;
    }
}
