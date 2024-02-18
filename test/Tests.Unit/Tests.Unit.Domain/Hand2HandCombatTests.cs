using Domain.Entities;

namespace Tests.Unit.Domain;

public class Hand2HandCombatTests
{
    [Theory]
    [InlineData(1, "1d6-4","1d6+0")]
    [InlineData(13, "1d6+8","1d6+12")]
    [InlineData(5, "1d6+0","1d6+4")]
    [InlineData(10, "1d6+4","1d6+8")]
    [InlineData(7, "1d6+2","1d6+6")]
    [InlineData(3, "1d6-2","1d6+2")]
    [InlineData(11, "1d6+6","1d6+10")]
    public void Ctor_ValidData_CreatesNewInstance(int physiqueValue, string expectedArmValue, string expectedLegValue)
    {
        var hand2HandCombat = new Hand2HandCombat(physiqueValue);
        Assert.Equal(expectedArmValue, hand2HandCombat.ArmAttack);
        Assert.Equal(expectedLegValue, hand2HandCombat.LegAttack);
    }
    [Theory]
    [InlineData(0)]
    [InlineData(15)]
    public void Ctor_IncorrectPhysiqueValue_ThrowsArgumentOutOfRangeException(int physiqueValue)
    {
        var hand2HandCombatAction =() => new Hand2HandCombat(physiqueValue);
        Assert.Throws<ArgumentOutOfRangeException>(hand2HandCombatAction);
    }
}