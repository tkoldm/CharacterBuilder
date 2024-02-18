namespace Domain.Entities.SkillEntites.Constants;

public class PhysiqueSkillsConstants : ISkillConstant
{
    public const string Strength = "Сила";
    public const string Durability = "Стойкость";

    public ICollection<Skill> GetSkills() => new[]
    {
        new Skill(Strength),
        new Skill(Durability)
    };
}