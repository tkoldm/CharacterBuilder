namespace Domain.Entities.MagicEntities;

public class Ritual : Curse
{
    /// <summary>
    /// Время подготовки
    /// </summary>
    public byte PrepareTime { get; private set; }

    /// <summary>
    /// Сложность проверки
    /// </summary>
    public byte Complexity { get; private set; }

    /// <summary>
    /// Длительность
    /// </summary>
    public string Duration { get; private set; }

    /// <summary>
    /// Ингридиенты
    /// </summary>
    public ICollection<string> Ingredients { get; private set; }

    public Ritual(string name, byte cost, string effect, byte prepareTime, byte complexity, string duration,
        ICollection<string> ingredients) : base(name, cost, effect)
    {
        PrepareTime = prepareTime;
        Complexity = complexity;
        SetDuration(duration);
        Ingredients = ingredients;
    }

    private void SetDuration(string duration)
    {
        ThrowIsNull(duration, nameof(Duration));
        Duration = duration;
    }
}