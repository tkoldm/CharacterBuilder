using Domain.Entities;
using Domain.Entities.MagicEntities;
using Domain.Enums;
using Domain.Exceptions;

namespace Tests.Unit.Domain;

public class CharactersDetailsTests
{
    [Theory]
    [MemberData(nameof(GetDataWithoutMagic))]
    public void Ctor_DataWithoutMagic_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race,
        Skills skills)
    {
        var charactersDetails = new CharactersDetails(profession, race, skills);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.NotNull(charactersDetails.Skills);
        Assert.Equal(skills, charactersDetails.Skills);
        Assert.Empty(charactersDetails.Magic.Curses);
        Assert.Empty(charactersDetails.Magic.Spells);
        Assert.Empty(charactersDetails.Magic.Rituals);
        Assert.Equal(0, charactersDetails.Energy);
    }

    [Theory]
    [MemberData(nameof(GetDataWithSkillPoints))]
    public void Ctor_DataWithSkillPoints_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race,
        Skills skills, byte skillPoints)
    {
        var charactersDetails = new CharactersDetails(profession, race, skills, skillPoints);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.Equal(0, charactersDetails.Energy);
        Assert.NotNull(charactersDetails.Skills);
        Assert.Equal(skillPoints, charactersDetails.SkillPoints);
        Assert.Equal(skills, charactersDetails.Skills);
        Assert.Empty(charactersDetails.Magic.Rituals);
        Assert.Empty(charactersDetails.Magic.Curses);
        Assert.Empty(charactersDetails.Magic.Spells);
    }

    [Theory]
    [MemberData(nameof(GetDataWithMagic))]
    public void Ctor_DataWithMagic_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race, Magic magic,
        Skills skills, byte energy)
    {
        var charactersDetails = new CharactersDetails(profession, race, magic, skills, energy);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.Equal(energy, charactersDetails.Energy);
        Assert.NotNull(charactersDetails.Skills);
        Assert.Equal(skills, charactersDetails.Skills);
        Assert.Equal(magic, charactersDetails.Magic);
    }

    [Theory]
    [MemberData(nameof(GetDataWithMagicAndSkillPoints))]
    public void Ctor_DataWithMagicAndSkillPoints_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race,
        Magic magic, Skills skills, byte skillPoints, byte energy)
    {
        var charactersDetails = new CharactersDetails(profession, race, magic, skills, skillPoints, energy);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.Equal(energy, charactersDetails.Energy);
        Assert.Equal(skillPoints, skillPoints);
        Assert.NotNull(charactersDetails.Skills);
        Assert.Equal(skills, charactersDetails.Skills);
        Assert.Equal(magic, charactersDetails.Magic);
    }

    [Theory]
    [MemberData(nameof(GetIncorrectDataWithMagic))]
    public void Ctor_DataWithMagic_ThrowsUnsupportedMatchException(Profession profession, Race race, Magic magic,
        Skills skills, byte energy)
    {
        var charactersDetailsAction = () => new CharactersDetails(profession, race, magic, skills, energy);
        Assert.Throws<UnsupportedMatchException>(charactersDetailsAction);
    }

    public static IEnumerable<object[]> GetDataWithoutMagic()
    {
        yield return
        [
            Profession.Medic,
            Race.Elf,
            new Skills()
        ];
    }

    public static IEnumerable<object[]> GetDataWithSkillPoints()
    {
        yield return
        [
            Profession.Medic,
            Race.Elf,
            new Skills(),
            (byte)10
        ];
    }

    public static IEnumerable<object[]> GetDataWithMagic()
    {
        yield return
        [
            Profession.Priest,
            Race.Elf,
            new Magic(new List<Curse>
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
                }),
            new Skills(),
            (byte)5
        ];
        yield return
        [
            Profession.Medic,
            Race.Elf,
            new Magic(),
            new Skills(),
            (byte)0
        ];
    }

    public static IEnumerable<object[]> GetDataWithMagicAndSkillPoints()
    {
        yield return
        [
            Profession.Priest,
            Race.Elf,
            new Magic(new List<Curse>
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
                }),
            new Skills(),
            (byte)5,
            (byte)15
        ];
        yield return
        [
            Profession.Medic,
            Race.Elf,
            new Magic(),
            new Skills(),
            (byte)0,
            (byte)10
        ];
    }

    public static IEnumerable<object[]> GetIncorrectDataWithMagic()
    {
        yield return
        [
            Profession.Priest,
            Race.Dwarf,
            new Magic(new List<Curse>
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
                }),
            new Skills(),
            (byte)5
        ];
        yield return
        [
            Profession.Witcher,
            Race.Dwarf,
            new Magic(new List<Curse>
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
                }),
            new Skills(),
            (byte)5
        ];
        yield return
        [
            Profession.Medic,
            Race.Witcher,
            new Magic(new List<Curse>
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
                }),
            new Skills(),
            (byte)5
        ];
    }
}