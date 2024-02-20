using Domain.Entities.SkillEntites;
using Domain.Entities.SkillEntites.Constants;

namespace Tests.Unit.Domain;

public class CharacteristicTests
{
    [Fact]
    public void CreateCharacteristicWithNameValueSkills_Positive()
    {
        var skills = new CraftSkillsConstants().GetSkills();
        var characteristic = new Characteristic(CharacteristicsConstants.Craft, 9, skills);

        Assert.Equal(CharacteristicsConstants.Craft, characteristic.Name);
        Assert.Equal(9, characteristic.Value);
        Assert.Equal(skills, characteristic.Skills);
    }

    [Fact]
    public void CreateCharacteristicWithNameValue_Positive()
    {
        var characteristic = new Characteristic(CharacteristicsConstants.Craft, 9);

        Assert.Equal(CharacteristicsConstants.Craft, characteristic.Name);
        Assert.Equal(9, characteristic.Value);
        Assert.Empty(characteristic.Skills);
    }
}