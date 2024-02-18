namespace Domain.Entities;

public class Hand2HandCombat
{
    public string ArmAttack { get; private set; }
    public string LegAttack { get; private set; }

    public Hand2HandCombat(int physiqueModifier)
    {
        var armModifier = GetModifier(physiqueModifier);
        var legModifier = GetModifier(physiqueModifier) + 4;
        ArmAttack = armModifier < 0
            ? $"1d6{armModifier}"
            : $"1d6+{armModifier}";
        LegAttack = $"1d6+{legModifier}";
    }

    private static int GetModifier(int bodyTypeModifier) => bodyTypeModifier switch
    {
        1 or 2 => -4,
        3 or 4 => -2,
        5 or 6 => 0,
        7 or 8 => 2,
        9 or 10 => 4,
        11 or 12 => 6,
        13 => 8,
        _ => throw new ArgumentOutOfRangeException(nameof(bodyTypeModifier), "Incorrect value of body type modifier")
    };
}