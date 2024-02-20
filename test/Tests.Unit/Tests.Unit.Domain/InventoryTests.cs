using Domain.Entities;
using Domain.Entities.InventoryEntities;
using Domain.Enums;

namespace Tests.Unit.Domain;

public class InventoryTests
{
    [Theory]
    [InlineData(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров", null)]
    [InlineData(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров", 15)]
    public void Ctor_ValidData_CreatesNewWeaponEffectInstance(Effect effect, string description, int? percentage)
    {
        var weaponEffect = new WeaponEffect(effect, description, percentage);
        Assert.Equal(effect, weaponEffect.Effect);
        Assert.Equal(description, weaponEffect.Description);
        Assert.Equal(percentage, weaponEffect.Percentage);
    }

    [Theory]
    [MemberData(nameof(GetWeaponData))]
    public void Ctor_ValidData_CreatesNewWeaponInstance(string name, float weight, int cost, byte accuracy,
        string damage,
        byte reliaility, byte grip, WeaponEffect[] effects, WeaponSize size, byte improvement)
    {
        var weapon = new Weapon(name, weight, cost, accuracy, damage, reliaility, grip, effects, size, improvement);
        Assert.Equal(name, weapon.Name);
        Assert.Equal(weight, weapon.Weight);
        Assert.Equal(accuracy, weapon.Accuracy);
        Assert.Equal(damage, weapon.Damage);
        Assert.Equal(reliaility, weapon.Reliaility);
        Assert.Equal(grip, weapon.Grip);
        Assert.Equal(effects, weapon.Effects);
        Assert.Equal(size, weapon.Size);
        Assert.Equal(improvement, weapon.Improvement);
    }

    [Theory]
    [InlineData("Аэдирнский Гамбезон", 1.5, 689, BodyPart.Body, 5)]
    public void Ctor_ValidData_CreatesNewArmorInstance(string name, float weight, int cost, BodyPart bodyPart,
        byte strength)
    {
        var armor = new Armor(name, weight, cost, bodyPart, strength);
        Assert.Equal(name, armor.Name);
        Assert.Equal(weight, armor.Weight);
        Assert.Equal(bodyPart, armor.BodyPart);
        Assert.Equal(strength, armor.Strength);
    }

    [Theory]
    [InlineData("Письменные принадлежности", 1, 50, "Позволяют писать записки, письма и т.д.")]
    public void Ctor_ValidData_CreatesNewEquipmentInstance(string name, float weight, int cost, string description)
    {
        var armor = new Equipment(name, weight, cost, description);
        Assert.Equal(name, armor.Name);
        Assert.Equal(weight, armor.Weight);
        Assert.Equal(description, armor.Description);
    }

    [Theory]
    [MemberData(nameof(GetInventoryData))]
    public void Ctor_ValidData_CreatesNewInventoryInstance(Armor[] armors, Weapon[] weapons, Equipment[] equipments,
        Component[] components)
    {
        var inventory = new Inventory(armors, weapons, equipments, components);
        Assert.Equal(armors.Length, inventory.Armors.Count);
        Assert.Equal(weapons.Length, inventory.Weapons.Count);
        Assert.Equal(equipments.Length, inventory.Equipments.Count);
        Assert.NotNull(inventory.Components);
    }

    [Fact]
    public void Ctor_WithoutData_CreatesNewInventoryInstance()
    {
        var inventory = new Inventory();
        Assert.NotNull(inventory.Armors);
        Assert.NotNull(inventory.Weapons);
        Assert.NotNull(inventory.Equipments);
        Assert.NotNull(inventory.Components);
    }
    
    [Theory]
    [MemberData(nameof(GetInventoryDataWithWeight))]
    public void CheckWeightCalculation(Armor[] armors, Weapon[] weapons, Equipment[] equipments,
        Component[] components, float expectedResult)
    {
        var inventory = new Inventory(armors, weapons, equipments, components);
        var resultWeight = inventory.GetWeight();
        Assert.Equal(expectedResult, resultWeight);
    }
    
    public static IEnumerable<object[]> GetWeaponData()
    {
        yield return
        [
            "Гледдиф", 
            3, 
            100,
            0, 
            "3d6+2",
            5,
            2,
            new[] { new WeaponEffect(Effect.Long, "Описание") },
            WeaponSize.Large,
            0
        ];
    }

    public static IEnumerable<object[]> GetInventoryData()
    {
        yield return
        [
            new List<Armor>
            {
                new("Аэдирнский Гамбезон", 1.5f, 75, BodyPart.Body, 5)
            },

            new List<Weapon>
            {
                new("Гледдиф", 3, 689, 0, "3d6+2", 5, 2,
                    [new WeaponEffect(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров")],
                    WeaponSize.Large, 0)
            },
            new List<Equipment>
            {
                new("Письменные принадлежности", 1, 50, "Позволяют писать записки, письма и т.д.")
            },
            new List<Component>
            {
                new("Свечи *5", 0.5f, 10)
            }
        ];
    }

    public static IEnumerable<object[]> GetInventoryDataWithWeight()
    {
        yield return
        [
            new List<Armor>
            {
                new("Аэдирнский Гамбезон", 1.5f, 75, BodyPart.Body, 5)
            },

            new List<Weapon>
            {
                new("Гледдиф", 3, 689, 0, "3d6+2", 5, 2,
                    [new WeaponEffect(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров")],
                    WeaponSize.Large, 0)
            },
            new List<Equipment>
            {
                new("Письменные принадлежности", 1, 50, "Позволяют писать записки, письма и т.д.")
            },
            new List<Component>
            {
                new("Свечи *5", 0.5f, 10)
            },
            6
        ];
    }
}