using Domain.Exceptions;

namespace Domain.Entities.MagicEntities;

/// <summary>
/// Порча
/// </summary>
public class Curse
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Затраты выносливости
    /// </summary>
    public byte Cost { get; private set; }

    /// <summary>
    /// Эффект
    /// </summary>
    public string Effect { get; private set; }

    public Curse(string name, byte cost, string effect)
    {
        SetName(name);
        Cost = cost;
        SetEffect(effect);
    }

    private void SetName(string name)
    {
        ThrowIsNull(name, nameof(Name));
        Name = name;
    }

    private void SetEffect(string effect)
    {
        ThrowIsNull(effect, nameof(Effect));
        Effect = effect;
    }

    private protected static void ThrowIsNull(string input, string name)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new IncorrectValueException($"{name} can't be null or empty");
        }
    }
}