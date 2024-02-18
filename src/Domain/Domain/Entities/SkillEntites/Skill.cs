namespace Domain.Entities.SkillEntites;

public class Skill
{
    /// <summary>
    /// Название навыка
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Значение навыка
    /// </summary>
    public byte Value { get; private set; }

    /// <summary>
    /// Модификатор улучшения
    /// </summary>
    public byte Modifier { get; private set; }

    public Skill(string name, byte modifier, byte value)
    {
        Name = name;
        Value = value;
        Modifier = modifier;
    }

    public Skill(string name, byte modifier = 1) : this(name, modifier, 1)
    {
    }

    public void Increment() => Value += 1;

    public void SetValue(byte value) => Value = value;
}