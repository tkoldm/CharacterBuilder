namespace Domain.Entities.InventoryEntities;

/// <summary>
/// Снаряжение
/// </summary>
public class Equipment : Component
{
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

    public Equipment(string name, float weight, int cost, string description) : base(name, weight, cost)
    {
        Description = description;
    }
}