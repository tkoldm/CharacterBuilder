using Domain.Exceptions;

namespace Domain.Entities.InventoryEntities;

/// <summary>
/// Компонент/ингридиент
/// </summary>
public class Component
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Вес
    /// </summary>
    public float Weight { get; private set; }

    /// <summary>
    /// Цена
    /// </summary>
    public int Cost { get; private set; }

    public Component(string name, float weight, int cost)
    {
        Name = name;
        Weight = weight;
        Cost = cost;
    }
}