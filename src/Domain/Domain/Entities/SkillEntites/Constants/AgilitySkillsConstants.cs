namespace Domain.Entities.SkillEntites.Constants;

public class AgilitySkillsConstants : ISkillConstant
{
    public const string SleightOfHands = "Ловкость рук";
    public const string Athletics = "Атлетика";
    public const string Stealth = "Скрытность";
    public const string CrossbowShooting = "Стрельба из арбалета";
    public const string Archery = "Стрельба из лука";

    public ICollection<Skill> GetSkills() => new[]
    {
        new Skill(SleightOfHands),
        new Skill(Athletics),
        new Skill(Stealth),
        new Skill(CrossbowShooting),
        new Skill(Archery)
    };
}