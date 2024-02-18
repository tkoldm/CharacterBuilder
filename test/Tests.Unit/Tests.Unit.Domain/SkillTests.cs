using Domain.Entities;
using Domain.Entities.SkillEntites;
using Domain.Entities.SkillEntites.Constants;

namespace Tests.Unit.Domain;

public class SkillTests
{
    [Fact]
    public void Ctor_NoData_CreatesNewSkillsAndHand2HandCombat()
    {
        var skills = new Skills();
        Assert.NotNull(skills.Hand2HandCombat);
        Assert.NotNull(skills.SkillsCollection);
        Assert.NotEmpty(skills.SkillsCollection);
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void Ctor_SkillsData_CreatesNewSkillsAndHand2HandCombat(Сharacteristic[] skillsCollection)
    {
        var skills = new Skills(skillsCollection);
        Assert.NotNull(skills.Hand2HandCombat);
        Assert.NotNull(skills.SkillsCollection);
        Assert.NotEmpty(skills.SkillsCollection);
    }

    [Theory]
    [InlineData(5, "1d6+0", "1d6+4")]
    [InlineData(12, "1d6+6", "1d6+10")]
    public void SetValue_PhysiqueSkillNewValue_UpdatesPhysiqueValueAndReCalculatesHand2HandCombat(byte newValue,
        string expectedArmModifier, string expectedLegModifier)
    {
        var skills = new Skills();
        skills.SetSkillBaseValue(SkillsConstants.Physique, newValue);

        var physique = skills.SkillsCollection.First(s => s.Name == SkillsConstants.Physique);
        Assert.Equal(newValue, physique.Value);
        Assert.Equal(expectedArmModifier, skills.Hand2HandCombat.ArmAttack);
        Assert.Equal(expectedLegModifier, skills.Hand2HandCombat.LegAttack);
    }

    [Theory]
    [InlineData(SkillsConstants.Agility)]
    [InlineData(SkillsConstants.Empathy)]
    [InlineData(SkillsConstants.Physique)]
    public void Increment_NameOfSkill_IncrementsValue(string skillName)
    {
        var skills = new Skills();
        var skill = skills.SkillsCollection.First(s => s.Name == skillName);
        var skillValueBeforeIncrement = skill.Value;
        skills.IncrementSkillBaseValue(skillName);
        var skillValueAfterIncrement = skill.Value;

        Assert.Equal(skillValueBeforeIncrement + 1, skillValueAfterIncrement);
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void GetStartedSkillPoints_SkillsData_CalculatesSkillPointsForCharacter(Сharacteristic[] skillsCollection)
    {
        var skills = new Skills(skillsCollection);
        var intellect = skills.SkillsCollection.First(s => s.Name == SkillsConstants.Intellect).Value;
        var reaction = skills.SkillsCollection.First(s => s.Name == SkillsConstants.Reaction).Value;
        var expectedStartSkillPoints = intellect + reaction + 44;

        var factStartSkillPoints = skills.GetStartedSkillPoints();

        Assert.Equal(expectedStartSkillPoints, factStartSkillPoints);
    }

    public static IEnumerable<object[]> GetData()
    {
        yield return
        [
            new object[]
            {
                new Сharacteristic(SkillsConstants.Agility, 4, new AgilitySkillsConstants().GetSkills()),
                new Сharacteristic(SkillsConstants.Craft, 8, new CraftSkillsConstants().GetSkills()),
                new Сharacteristic(SkillsConstants.Empathy, 9, new EmpathySkillsConstants().GetSkills()),
                new Сharacteristic(SkillsConstants.Intellect, 4, new IntellectSkillsConstants().GetSkills()),
                new Сharacteristic(SkillsConstants.Physique, 7, new PhysiqueSkillsConstants().GetSkills()),
                new Сharacteristic(SkillsConstants.Will, 3, new WillSkillsConstants().GetSkills()),
                new Сharacteristic(SkillsConstants.Reaction, 9, new ReactionSkillsConstants().GetSkills()),
            }
        ];
    }
}