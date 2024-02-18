namespace Domain.Entities.SkillEntites.Constants;

public class IntellectSkillsConstants : ISkillConstant
{
    public const string Attention = "Внимание";
    public const string Survival = "Выживание в дикой природе";
    public const string Deduction = "Дедукция";
    public const string Monstrology = "Монстрология";
    public const string Education = "Образование";
    public const string CityOrientation = "Ориентирование в городе";
    public const string KnowledgeTransfer = "Передача знаний";
    public const string Tactics = "Тактика";
    public const string Trade = "Торговля";
    public const string Etiquette = "Этикет";
    public const string Language = "Язык";

    public ICollection<Skill> GetSkills() => new[]
    {
        new Skill(Attention),
        new Skill(Survival),
        new Skill(Deduction),
        new Skill(Monstrology, modifier: 2),
        new Skill(Education),
        new Skill(CityOrientation),
        new Skill(KnowledgeTransfer),
        new Skill(Tactics, modifier: 2),
        new Skill(Trade),
        new Skill(Etiquette),
        new Skill(Language, modifier: 2)
    };
}