namespace Domain.Entities.SkillEntites.Constants;

public class SkillsConstants
{

    public const string Agility = "Ловкость";
    public const string Craft = "Ремесло";
    public const string Empathy = "Эмпатия";
    public const string Intellect = "Интеллект";
    public const string Physique = "Телосложение";
    public const string Will = "Воля";
    public const string Reaction = "Реакция";

    public static ICollection<Сharacteristic> GetSkills() => new[]
    {
        new Сharacteristic(Agility, new AgilitySkillsConstants().GetSkills()),
        new Сharacteristic(Craft, new CraftSkillsConstants().GetSkills()),
        new Сharacteristic(Empathy, new EmpathySkillsConstants().GetSkills()),
        new Сharacteristic(Intellect, new IntellectSkillsConstants().GetSkills()),
        new Сharacteristic(Physique, new PhysiqueSkillsConstants().GetSkills()),
        new Сharacteristic(Will, new WillSkillsConstants().GetSkills()),
        new Сharacteristic(Reaction, new ReactionSkillsConstants().GetSkills()),
    };
}