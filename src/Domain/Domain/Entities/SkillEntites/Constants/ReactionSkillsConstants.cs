namespace Domain.Entities.SkillEntites.Constants;

public class ReactionSkillsConstants : ISkillConstant
{
    public const string CloseCombat = "Ближний бой";
    public const string Wrestling = "Борьба";
    public const string HorsebackRiding = "Верховая езда";
    public const string PolearmWeapon = "Древковое оружие";
    public const string LightBlades = "Владение лёгкими клинками";
    public const string Sword = "Владение мечом";
    public const string Sailing = "Мореходство";
    public const string Evasion = "Уклонение/Изворотливость";

    public ICollection<Skill> GetSkills() => new[]
    {
        new Skill(CloseCombat),
        new Skill(Wrestling),
        new Skill(HorsebackRiding),
        new Skill(PolearmWeapon),
        new Skill(LightBlades),
        new Skill(Sword),
        new Skill(Sailing),
        new Skill(Evasion)
    };
}