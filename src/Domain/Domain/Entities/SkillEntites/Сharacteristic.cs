namespace Domain.Entities.SkillEntites;

public class Сharacteristic : Skill
{
    public ICollection<Skill> Skills { get; private set; }

    public Сharacteristic(string name, byte value, ICollection<Skill> skills) : base(name, 10, value)
    {
        Skills = skills;
    }

    public Сharacteristic(string name, ICollection<Skill> skills) : base(name, 10)
    {
        Skills = skills;
    }
}