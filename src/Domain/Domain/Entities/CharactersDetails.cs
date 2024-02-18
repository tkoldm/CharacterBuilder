using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class CharactersDetails
{
    public Profession Profession { get; private set; }
    public Race Race { get; private set; }
    public Magic Magic { get; private set; }
    public Skills Skills { get; private set; }
    public byte SkillPoints { get; private set; }
    public byte Energy { get; private set; }

    public CharactersDetails(Profession profession, Race race, Magic magic, Skills skills, byte skillPoints,
        byte energy)
    {
        Profession = profession;
        Race = race;
        Magic = magic;
        Skills = skills;
        SkillPoints = skillPoints;
        Energy = energy;
    }

    public CharactersDetails(Profession profession, Race race, Magic magic, Skills skills, byte energy)
    {
        IsMagicRaceAndProfession(profession, race, energy);
        Profession = profession;
        Race = race;
        Magic = magic;
        Skills = skills;
        Energy = energy;
        SkillPoints = Skills.GetStartedSkillPoints();
    }

    public CharactersDetails(Profession profession, Race race, Skills skills)
    {
        Profession = profession;
        Race = race;
        Magic = new Magic();
        Skills = skills;
        Energy = 0;
        SkillPoints = Skills.GetStartedSkillPoints();
    }

    public CharactersDetails(Profession profession, Race race, Skills skills, byte skillPoints)
    {
        Profession = profession;
        Race = race;
        Magic = new Magic();
        Skills = skills;
        Energy = 0;
        SkillPoints = skillPoints;
    }

    private static void IsMagicRaceAndProfession(Profession profession, Race race, byte energy)
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