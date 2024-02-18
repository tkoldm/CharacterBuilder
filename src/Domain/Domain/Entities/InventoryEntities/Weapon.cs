using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities.InventoryEntities;

public class Weapon : Component
{
    /// <summary>
    /// Точность
    /// </summary>
    public byte Accuracy { get; private set; }

    /// <summary>
    /// Урон
    /// </summary>
    public string Damage { get; private set; }

    /// <summary>
    /// Надёжность
    /// </summary>
    public byte Reliaility { get; private set; }

    /// <summary>
    /// Хват
    /// </summary>
    public byte Grip { get; private set; }

    /// <summary>
    /// Эффекты
    /// </summary>
    public WeaponEffect[] Effects { get; private set; }

    /// <summary>
    /// Скрытность
    /// </summary>
    public WeaponSize Size { get; private set; }

    /// <summary>
    /// Количество улучшений
    /// </summary>
    public byte Improvement { get; private set; }

    public Weapon(string name, float weight, int cost, byte accuracy, string damage, byte reliaility, byte grip,
        WeaponEffect[] effects, WeaponSize size, byte improvement) : base(name,
        weight, cost)
    {
        Accuracy = accuracy;
        Damage = damage;
        Reliaility = reliaility;
        Grip = grip;
        Effects = effects;
        Size = size;
        Improvement = improvement;
    }
}