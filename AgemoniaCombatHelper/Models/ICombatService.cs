namespace AgemoniaCombatHelper.Models
{
    public interface ICombatService
    {
        public void AddHero(Hero hero);
        public void AddEnemy(Enemy enemy);
        public void DrawNewCard();
        public void SetCardsFromJson(InitiativeDeck deck);
        public List<Entity> GetEntities();
    }
}
