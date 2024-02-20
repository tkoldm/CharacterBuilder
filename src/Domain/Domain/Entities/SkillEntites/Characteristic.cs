namespace Domain.Entities.SkillEntites;

public class Characteristic : Skill
{
    public ICollection<Skill> Skills { get; private set; }

    public Characteristic(string name, byte value, ICollection<Skill> skills) : base(name, 10, value)
    {
        Skills = skills;
    }

    public Characteristic(string name, byte value) : base(name, 10, value)
    {
        Skills = new List<Skill>();
    }

    public Characteristic(string name) : base(name, 10)
    {
        Skills = new List<Skill>();
    }

    public Characteristic(string name, ICollection<Skill> skills) : base(name, 10)
    {
        Skills = skills;
    }
}