using Domain.Entities.InventoryEntities;

namespace Domain.Entities;

public class Inventory
{
    public ICollection<Armor> Armors { get; private set; }
    public ICollection<Weapon> Weapons { get; private set; }
    public ICollection<Equipment> Equipments { get; private set; }
    public ICollection<Component> Components { get; private set; }

    public Inventory()
    {
        Armors = new List<Armor>();
        Weapons = new List<Weapon>();
        Equipments = new List<Equipment>();
        Components = new List<Component>();
    }

    public Inventory(ICollection<Armor>? armors = null, ICollection<Weapon>? weapons = null, ICollection<Equipment>? equipments = null,
        ICollection<Component>? components = null)
    {
        Armors = armors ?? new  List<Armor>();
        Weapons = weapons ?? new  List<Weapon>();
        Equipments = equipments ?? new  List<Equipment>();
        Components = components ?? new  List<Component>();
    }

    public float GetWight()
    {
        return Armors.Select(a => a.Weight).Sum() + Weapons.Select(w => w.Weight).Sum() +
               Equipments.Select(e => e.Weight).Sum() + Components.Select(c => c.Weight).Sum();
    }
}