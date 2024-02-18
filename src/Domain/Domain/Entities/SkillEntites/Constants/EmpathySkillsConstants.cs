namespace Domain.Entities.SkillEntites.Constants;

public class EmpathySkillsConstants : ISkillConstant
{
    public const string Gambling = "Азартные игры";
    public const string Appearance = "Внешний вид";
    public const string Performance = "Выступление";
    public const string Art = "Искусство";
    public const string Leadership = "Лидерство";
    public const string Deception = "Обман";
    public const string UnderstandingPeople = "Понимание людей";
    public const string Seduction = "Соблазнение";
    public const string Belief = "Убеждение";
    public const string Charisma = "Харизма";

    public ICollection<Skill> GetSkills() => new[]
    {
        new Skill(Gambling),
        new Skill(Appearance),
        new Skill(Performance),
        new Skill(Art),
        new Skill(Leadership),
        new Skill(Deception),
        new Skill(UnderstandingPeople),
        new Skill(Seduction),
        new Skill(Belief),
        new Skill(Charisma),
    };
}