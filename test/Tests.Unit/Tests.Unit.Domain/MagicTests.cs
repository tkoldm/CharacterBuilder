using Domain.Entities;
using Domain.Entities.MagicEntities;
using Domain.Exceptions;

namespace Tests.Unit.Domain;

public class MagicTests
{
    [Theory]
    [InlineData("Теневая порча", 4, "Очень длинный эффект порчи")]
    public void Ctor_ValidData_CreatesNewCurseInstance(string name, byte cost, string effect)
    {
        var curse = new Curse(name, cost, effect);
        Assert.Equal(name, curse.Name);
        Assert.Equal(cost, curse.Cost);
        Assert.Equal(effect, curse.Effect);
    }

    [Theory]
    [InlineData("Зефир", 5, "Эффект заклинания", 2, "1d6 раундов")]
    public void Ctor_ValidData_CreatesNewSpellInstance(string name, byte cost, string effect, ushort distance,
        string duration)
    {
        var spell = new Spell(name, cost, effect, distance, duration);
        Assert.Equal(name, spell.Name);
        Assert.Equal(cost, spell.Cost);
        Assert.Equal(effect, spell.Effect);
        Assert.Equal(distance, spell.Distance);
        Assert.Equal(duration, spell.Duration);
    }

    [Theory]
    [InlineData("Гидромантия", 5, "Эффект ритуала", 2, 15, "4 раунда", new[] { "Чаша с водой" })]
    public void Ctor_ValidData_CreatesNewRitualInstance(string name, byte cost, string effect, byte prepareTime,
        byte complexity, string duration,
        ICollection<string> ingredients)
    {
        var ritual = new Ritual(name, cost, effect, prepareTime, complexity, duration, ingredients);
        Assert.Equal(name, ritual.Name);
        Assert.Equal(cost, ritual.Cost);
        Assert.Equal(effect, ritual.Effect);
        Assert.Equal(prepareTime, ritual.PrepareTime);
        Assert.Equal(complexity, ritual.Complexity);
        Assert.Equal(duration, ritual.Duration);
        Assert.Equal(ingredients.Count, ritual.Ingredients.Count);
    }

    [Fact]
    public void Ctor_ValidData_CreatesNewMagicInstance()
    {
        var magic = new Magic();
        Assert.Empty(magic.Curses);
        Assert.Empty(magic.Spells);
        Assert.Empty(magic.Rituals);
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void AddCollectionOfMagicData(Curse[] curses, Spell[] spells, Ritual[] rituals)
    {
        var magic = new Magic();
        magic.AddRituals(rituals);
        Assert.Equal(rituals.Length, magic.Rituals.Count);
        magic.AddSpells(spells);
        Assert.Equal(spells.Length, magic.Spells.Count);
        magic.AddCurses(curses);
        Assert.Equal(curses.Length, magic.Curses.Count);
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void AddSingleMagicData(Curse[] curses, Spell[] spells, Ritual[] rituals)
    {
        var magic = new Magic();
        magic.AddRitual(rituals.First());
        Assert.Single(magic.Rituals);
        magic.AddSpell(spells.First());
        Assert.Single(magic.Spells);
        magic.AddCurse(curses.First());
        Assert.Single(magic.Curses);
    }

    [Fact]
    public void Ctor_WithoutData_CreatesNewInventoryInstance()
    {
        var magic = new Magic();
        Assert.NotNull(magic.Curses);
        Assert.NotNull(magic.Spells);
        Assert.NotNull(magic.Rituals);
    }

    [Fact]
    public void CtorCurse_NullName_ThrowsIncorrectValueException()
    {
        var createAction = () => new Curse(null, 2, "Какой-то эффект");
        Assert.Throws<IncorrectValueException>(createAction);
    }

    [Fact]
    public void CtorCurse_NullDescription_ThrowsIncorrectValueException()
    {
        var createAction = () => new Curse("Теневая порча", 2, null);
        Assert.Throws<IncorrectValueException>(createAction);
    }

    public static IEnumerable<object[]> GetData()
    {
        yield return
        [
            new List<Curse>
            {
                new("Теневая порча", 4, "Очень длинный эффект порчи")
            },

            new List<Spell>
            {
                new("Зефир", 5, "Эффект заклинания", 2, "1d6 раундов")
            },
            new List<Ritual>
            {
                new("Гидромантия", 5, "Эффект ритуала", 2, 15, "4 раунда", new[] { "Чаша с водой" })
            }
        ];
    }
}