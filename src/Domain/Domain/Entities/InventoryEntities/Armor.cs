using Domain.Enums;

namespace Domain.Entities.InventoryEntities;

/// <summary>
/// Броня
/// </summary>
public class Armor : Component
{
    /// <summary>
    /// Часть тела
    /// </summary>
    public BodyPart BodyPart { get; }

    /// <summary>
    /// Прочность
    /// </summary>
    public byte Strength { get; }

    public Armor(string name, float weight, int cost, BodyPart bodyPart, byte strength) : base(name, weight, cost)
    {
        BodyPart = bodyPart;
        Strength = strength;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Weight.GetHashCode() + BodyPart.GetHashCode() + Strength.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        // If the passed object is not Customer Type, return False
        if (obj is not Armor)
        {
            return false;
        }
        return Name == ((Armor)obj).Name
               && Weight == ((Armor)obj).Weight
               && BodyPart == ((Armor)obj).BodyPart
               && Strength == ((Armor)obj).Strength;
    }
}