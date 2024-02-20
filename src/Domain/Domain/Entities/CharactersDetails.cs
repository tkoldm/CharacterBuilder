using Domain.Entities.SkillEntites;
using Domain.Entities.SkillEntites.Constants;
using Domain.Enums;
using Domain.Exceptions;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Domain.Entities;

public class CharactersDetails
{
    /// <summary>
    /// Профессия
    /// </summary>
    public Profession Profession { get; private set; }

    /// <summary>
    /// Раса
    /// </summary>
    public Race Race { get; private set; }

    /// <summary>
    /// Магия
    /// </summary>
    public Magic Magic { get; private set; }

    /// <summary>
    /// Характеристики
    /// </summary>
    public ICollection<Characteristic> Characteristics { get; private set; }

    /// <summary>
    /// Дополнительные характеристики
    /// </summary>
    public AdditionalCharacteristics AdditionalCharacteristics { get; private set; }

    /// <summary>
    /// Параметры рукопашного боя
    /// </summary>
    public Hand2HandCombat Hand2HandCombat { get; private set; }

    /// <summary>
    /// Очки улучшения
    /// </summary>
    public byte SkillPoints { get; private set; }

    /// <summary>
    /// Энергия
    /// </summary>
    public byte Energy { get; private set; }

    public CharactersDetails(Profession profession, Race race, Magic magic, ICollection<Characteristic> characteristics,
        byte skillPoints,
        byte energy)
    {
        Profession = profession;
        Race = race;
        Magic = magic;
        Characteristics = characteristics;
        SetAdditionalCharacteristics();
        SkillPoints = skillPoints;
        Energy = energy;
    }

    public CharactersDetails(Profession profession, Race race, Magic magic, ICollection<Characteristic> characteristics,
        byte energy)
    {
        CheckMagicRaceAndProfession(profession, race, energy);
        Profession = profession;
        Race = race;
        Magic = magic;
        Characteristics = characteristics;
        SetAdditionalCharacteristics();
        Energy = energy;
        SkillPoints = GetStartedSkillPoints();
    }

    public CharactersDetails(Profession profession, Race race, ICollection<Characteristic> characteristics)
    {
        Profession = profession;
        Race = race;
        Magic = new Magic();
        Characteristics = characteristics;
        SetAdditionalCharacteristics();
        Energy = 0;
        SkillPoints = GetStartedSkillPoints();
    }

    public CharactersDetails(Profession profession, Race race, ICollection<Characteristic> characteristics,
        byte skillPoints)
    {
        Profession = profession;
        Race = race;
        Magic = new Magic();
        Characteristics = characteristics;
        SetAdditionalCharacteristics();
        Energy = 0;
        SkillPoints = skillPoints;
    }

    public void IncrementSkillBaseValue(string name)
    {
        var targetSkill = Characteristics.First(s => s.Name == name);
        targetSkill.Increment();
        if (name == CharacteristicsConstants.Physique)
        {
            Hand2HandCombat = new Hand2HandCombat(targetSkill.Value);
        }
    }

    public void SetSkillBaseValue(string name, byte value)
    {
        var targetSkill = Characteristics.First(s => s.Name == name);
        targetSkill.SetValue(value);
        if (name == CharacteristicsConstants.Physique)
        {
            Hand2HandCombat = new Hand2HandCombat(targetSkill.Value);
        }
    }

    private byte GetStartedSkillPoints()
    {
        return (byte)(Characteristics
            .Where(s => s.Name is CharacteristicsConstants.Intellect or CharacteristicsConstants.Reaction)
            .Sum(s => s.Value) + 44);
    }

    private void SetAdditionalCharacteristics()
    {
        var speedValue = Characteristics.First(c => c.Name == CharacteristicsConstants.Speed).Value;
        var physiqueValue = Characteristics.First(s => s.Name == CharacteristicsConstants.Physique).Value;
        var willValue = Characteristics.First(s => s.Name == CharacteristicsConstants.Will).Value;
        AdditionalCharacteristics = new AdditionalCharacteristics(speedValue, physiqueValue, willValue);
        Hand2HandCombat = new Hand2HandCombat(physiqueValue);
    }

    private static void CheckMagicRaceAndProfession(Profession profession, Race race, byte energy)
    {
        if (energy == 0)
        {
            return;
        }

        if ((profession is Profession.Witcher && race is not Race.Witcher) ||
            (race is Race.Witcher && profession is not Profession.Witcher))
        {
            throw new UnsupportedMatchException("Only character with race Witcher can choose profession Wither");
        }

        if (profession is Profession.Mage or Profession.Priest && race is Race.Elf or Race.Human)
        {
            return;
        }

        throw new UnsupportedMatchException(
            "Magic professions (Mage, Priest) can choose character with race Human or Elf");
    }
}