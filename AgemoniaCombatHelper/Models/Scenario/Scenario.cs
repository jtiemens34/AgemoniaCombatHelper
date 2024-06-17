using AgemoniaCombatHelper.Models.Entities.Enemy;

namespace AgemoniaCombatHelper.Models.Scenario;
public class Scenario
{
    public int ScenarioNumber { get; set; }
    public List<Enemy>? Enemies { get; set; }
}
