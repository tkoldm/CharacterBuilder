namespace Domain.Entities.SkillEntites.Constants;

public class CharacteristicsConstants
{
    public const string Intellect = "Интеллект";
    public const string Reaction = "Реакция";
    public const string Agility = "Ловкость";
    public const string Physique = "Телосложение";
    public const string Speed = "Скорость";
    public const string Empathy = "Эмпатия";
    public const string Craft = "Ремесло";
    public const string Will = "Воля";
    public const string Luck = "Удача";

    public static ICollection<Characteristic> GetCharacteristics() => new[]
    {
        new Characteristic(Intellect, new IntellectSkillsConstants().GetSkills()),
        new Characteristic(Reaction, new ReactionSkillsConstants().GetSkills()),
        new Characteristic(Agility, new AgilitySkillsConstants().GetSkills()),
        new Characteristic(Physique, new PhysiqueSkillsConstants().GetSkills()),
        new Characteristic(Speed),
        new Characteristic(Empathy, new EmpathySkillsConstants().GetSkills()),
        new Characteristic(Craft, new CraftSkillsConstants().GetSkills()),
        new Characteristic(Will, new WillSkillsConstants().GetSkills()),
        new Characteristic(Luck),
    };
}