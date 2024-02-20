using Domain.Entities;
using Domain.Entities.SkillEntites;
using Domain.Entities.SkillEntites.Constants;
using Domain.Enums;
using Domain.Exceptions;

namespace Tests.Unit.Domain;

public class CharactersDetailsTests
{
    [Theory]
    [MemberData(nameof(GetDataWithoutMagic))]
    public void Ctor_DataWithoutMagic_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race,
        ICollection<Characteristic> characteristics)
    {
        var charactersDetails = new CharactersDetails(profession, race, characteristics);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.NotNull(charactersDetails.Characteristics);
        Assert.Equal(characteristics, charactersDetails.Characteristics);
        Assert.Empty(charactersDetails.Magic.Curses);
        Assert.Empty(charactersDetails.Magic.Spells);
        Assert.Empty(charactersDetails.Magic.Rituals);
        Assert.Equal(0, charactersDetails.Energy);
    }

    [Theory]
    [MemberData(nameof(GetDataWithSkillPoints))]
    public void Ctor_DataWithSkillPoints_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race,
        ICollection<Characteristic> characteristics, byte skillPoints)
    {
        var charactersDetails = new CharactersDetails(profession, race, characteristics, skillPoints);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.Equal(0, charactersDetails.Energy);
        Assert.NotNull(charactersDetails.Characteristics);
        Assert.Equal(skillPoints, charactersDetails.SkillPoints);
        Assert.Equal(characteristics, charactersDetails.Characteristics);
        Assert.Empty(charactersDetails.Magic.Rituals);
        Assert.Empty(charactersDetails.Magic.Curses);
        Assert.Empty(charactersDetails.Magic.Spells);
    }

    [Theory]
    [MemberData(nameof(GetDataWithMagic))]
    public void Ctor_DataWithMagic_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race, Magic magic,
        ICollection<Characteristic> characteristics, byte energy)
    {
        var charactersDetails = new CharactersDetails(profession, race, magic, characteristics, energy);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.Equal(energy, charactersDetails.Energy);
        Assert.NotNull(charactersDetails.Characteristics);
        Assert.Equal(characteristics, charactersDetails.Characteristics);
        Assert.Equal(magic, charactersDetails.Magic);
    }

    [Theory]
    [MemberData(nameof(GetDataWithMagicAndSkillPoints))]
    public void Ctor_DataWithMagicAndSkillPoints_CreatesNewInstanceOfCharacterDetails(Profession profession, Race race,
        Magic magic, ICollection<Characteristic> characteristics, byte skillPoints, byte energy)
    {
        var charactersDetails = new CharactersDetails(profession, race, magic, characteristics, skillPoints, energy);
        Assert.Equal(profession, charactersDetails.Profession);
        Assert.Equal(race, charactersDetails.Race);
        Assert.Equal(energy, charactersDetails.Energy);
        Assert.Equal(skillPoints, skillPoints);
        Assert.NotNull(charactersDetails.Characteristics);
        Assert.Equal(characteristics, charactersDetails.Characteristics);
        Assert.Equal(magic, charactersDetails.Magic);
    }

    [Theory]
    [MemberData(nameof(GetIncorrectDataWithMagic))]
    public void Ctor_DataWithMagic_ThrowsUnsupportedMatchException(Profession profession, Race race, Magic magic,
        ICollection<Characteristic> characteristics, byte energy)
    {
        var charactersDetailsAction = () => new CharactersDetails(profession, race, magic, characteristics, energy);
        Assert.Throws<UnsupportedMatchException>(charactersDetailsAction);
    }

    [Theory]
    [MemberData(nameof(GetDataToSetValue))]
    public void SetCharacteristicValue_Positive(Profession profession, Race race,
        ICollection<Characteristic> characteristics, byte newValue, string expectedArmModifier, string expectedLegModifier)
    {
        var charactersDetails = new CharactersDetails(profession, race, characteristics);
        charactersDetails.SetSkillBaseValue(CharacteristicsConstants.Physique, newValue);

        var physique = charactersDetails.Characteristics.First(s => s.Name == CharacteristicsConstants.Physique);
        Assert.Equal(newValue, physique.Value);
        Assert.Equal(expectedArmModifier, charactersDetails.Hand2HandCombat.ArmAttack);
        Assert.Equal(expectedLegModifier, charactersDetails.Hand2HandCombat.LegAttack);
    }

    [Theory]
    [MemberData(nameof(GetDataToIncrementValue))]
    public void Increment_NameOfSkill_IncrementsValue(Profession profession, Race race,
        ICollection<Characteristic> characteristics, string skillName)
    {
        var charactersDetails = new CharactersDetails(profession, race, characteristics);
        var skill = charactersDetails.Characteristics.First(s => s.Name == skillName);
        var skillValueBeforeIncrement = skill.Value;
        charactersDetails.IncrementSkillBaseValue(skillName);
        var skillValueAfterIncrement = skill.Value;

        Assert.Equal(skillValueBeforeIncrement + 1, skillValueAfterIncrement);
    }

    public static IEnumerable<object[]> GetDataWithoutMagic()
    {
        yield return
        [
            Profession.Medic,
            Race.Elf,
            CharacteristicsConstants.GetCharacteristics()
        ];
    }

    public static IEnumerable<object[]> GetDataToSetValue()
    {
        yield return
        [
            Profession.Medic,
            Race.Elf,
            CharacteristicsConstants.GetCharacteristics(),
            5,
            "1d6+0",
            "1d6+4"
        ];
        yield return
        [
            Profession.Medic,
            Race.Elf,
            CharacteristicsConstants.GetCharacteristics(),
            12,
            "1d6+6",
            "1d6+10"
        ];
    }

    public static IEnumerable<object[]> GetDataToIncrementValue()
    {
        yield return
        [
            Profession.Medic,
            Race.Elf,
            CharacteristicsConstants.GetCharacteristics(),
            CharacteristicsConstants.Agility
        ];
        yield return
        [
            Profession.Medic,
            Race.Elf,
            CharacteristicsConstants.GetCharacteristics(),
            CharacteristicsConstants.Empathy
        ];
        yield return
        [
            Profession.Medic,
            Race.Elf,
            CharacteristicsConstants.GetCharacteristics(),
            CharacteristicsConstants.Physique
        ];
    }

    public static IEnumerable<object[]> GetDataWithSkillPoints()
    {
        yield return
        [
            Profession.Medic,
            Race.Elf,
            CharacteristicsConstants.GetCharacteristics(),
            (byte)10
        ];
    }

    public static IEnumerable<object[]> GetDataWithMagic()
    {
        yield return
        [
            Profession.Priest,
            Race.Elf,
            new Magic(),
            CharacteristicsConstants.GetCharacteristics(),
            (byte)5
        ];
        yield return
        [
            Profession.Medic,
            Race.Elf,
            new Magic(),
            CharacteristicsConstants.GetCharacteristics(),
            (byte)0
        ];
    }

    public static IEnumerable<object[]> GetDataWithMagicAndSkillPoints()
    {
        yield return
        [
            Profession.Priest,
            Race.Elf,
            new Magic(),
            CharacteristicsConstants.GetCharacteristics(),
            (byte)5,
            (byte)15
        ];
        yield return
        [
            Profession.Medic,
            Race.Elf,
            new Magic(),
            CharacteristicsConstants.GetCharacteristics(),
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
            new Magic(),
            CharacteristicsConstants.GetCharacteristics(),
            (byte)5
        ];
        yield return
        [
            Profession.Witcher,
            Race.Dwarf,
            new Magic(),
            CharacteristicsConstants.GetCharacteristics(),
            (byte)5
        ];
        yield return
        [
            Profession.Medic,
            Race.Witcher,
            new Magic(),
            CharacteristicsConstants.GetCharacteristics(),
            (byte)5
        ];
    }
}