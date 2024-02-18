using Domain.Entities.MagicEntities;

namespace Domain.Entities;

public class Magic
{
    public ICollection<Curse> Curses { get; private set; }
    public ICollection<Spell> Spells { get; private set; }
    public ICollection<Ritual> Rituals { get; private set; }

    public Magic()
    {
        Curses = new List<Curse>();
        Spells = new List<Spell>();
        Rituals = new List<Ritual>();
    }

    public Magic(ICollection<Curse>? curses, ICollection<Spell>? spells, ICollection<Ritual>? rituals)
    {
        Curses = curses ?? new List<Curse>();
        Spells = spells ?? new List<Spell>();
        Rituals = rituals ?? new List<Ritual>();
    }
}