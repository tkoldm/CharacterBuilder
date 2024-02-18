namespace Domain.Entities.MagicEntities;

/// <summary>
/// Заклинание/Знак/Инвокация
/// </summary>
public class Spell : Curse
{
    /// <summary>
    /// Дистанция
    /// </summary>
    public ushort Distance { get; private set; }

    /// <summary>
    /// Длительность
    /// </summary>
    public string Duration { get; private set; }

    public Spell(string name, byte cost, string effect, ushort distance, string duration) : base(name, cost, effect)
    {
        Distance = distance;
        SetDuration(duration);
    }

    private void SetDuration(string duration)
    {
        ThrowIsNull(duration, nameof(Duration));
        Duration = duration;
    }
}