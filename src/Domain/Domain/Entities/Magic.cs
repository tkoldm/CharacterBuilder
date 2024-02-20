using Domain.Entities.MagicEntities;

namespace Domain.Entities;

public class Magic
{
    public IReadOnlyCollection<Curse> Curses => _curses.AsReadOnly();
    public IReadOnlyCollection<Spell> Spells => _spells.AsReadOnly();
    public IReadOnlyCollection<Ritual> Rituals => _rituals.AsReadOnly();

    private readonly List<Ritual> _rituals = [];
    private readonly List<Spell> _spells = [];
    private readonly List<Curse> _curses = [];

    public void AddSpell(Spell spell) => _spells.Add(spell);
    public void AddSpells(IEnumerable<Spell> spells) => _spells.AddRange(spells);

    public void AddCurse(Curse curse) => _curses.Add(curse);
    public void AddCurses(IEnumerable<Curse> curses) => _curses.AddRange(curses);

    public void AddRitual(Ritual ritual) => _rituals.Add(ritual);
    public void AddRituals(IEnumerable<Ritual> rituals) => _rituals.AddRange(rituals);
}