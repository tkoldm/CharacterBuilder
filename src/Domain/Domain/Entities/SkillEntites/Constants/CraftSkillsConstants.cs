namespace Domain.Entities.SkillEntites.Constants;

public class CraftSkillsConstants : ISkillConstant
{
    public const string Alchemy = "Алхимия";
    public const string PickingLocks = "Взлом замков";
    public const string TrapKnowledge = "Знание ловушек";
    public const string Manufacturing = "Изготовление";
    public const string Disguise = "Маскировка";
    public const string FirstAid = "Первая помощь";
    public const string Counterfeiting = "Подделывание";

    public ICollection<Skill> GetSkills() => new[]
    {
        new Skill(Alchemy, modifier: 2),
        new Skill(PickingLocks),
        new Skill(TrapKnowledge, modifier: 2),
        new Skill(Manufacturing, modifier: 2),
        new Skill(Disguise),
        new Skill(FirstAid),
        new Skill(Counterfeiting)
    };
}