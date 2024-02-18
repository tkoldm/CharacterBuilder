using Domain.Enums;

namespace Domain.Entities.InventoryEntities;

public class WeaponEffect
{
    /// <summary>
    /// Эффект
    /// </summary>
    public Effect Effect { get; private set; }

    /// <summary>
    /// Описание эффекта
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Вероятность примененя эффекта
    /// </summary>
    public int? Percentage { get; private set; }

    public WeaponEffect(Effect effect, string description, int? percentage = null)
    {
        Effect = effect;
        Description = description;
        Percentage = percentage;
    }
}