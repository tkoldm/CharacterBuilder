namespace Domain.Entities.SkillEntites.Constants;

public class WillSkillsConstants : ISkillConstant
{
    public const string Intimidation = "Запугивание";
    public const string Spoiling = "Наведение порчи";
    public const string ConductingRituals = "Проведение ритуалов";
    public const string MagicResistance = "Сопротивление магии";
    public const string PersuasionResistance = "Сопротивление убеждению";
    public const string CastingSpells = "Сотворение заклинаний";
    public const string Bravery = "Храбрость";

    public ICollection<Skill> GetSkills() => new[]
    {
        new Skill(Intimidation),
        new Skill(Spoiling, modifier: 2),
        new Skill(ConductingRituals, modifier: 2),
        new Skill(MagicResistance, modifier: 2),
        new Skill(PersuasionResistance),
        new Skill(CastingSpells, modifier: 2),
        new Skill(Bravery)
    };
}