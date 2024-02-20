namespace Domain.Entities;

public class AdditionalCharacteristics
{
    /// <summary>
    /// Устойчивость
    /// </summary>
    public byte Stability { get; private set; }

    /// <summary>
    /// Бег
    /// </summary>
    public byte Run { get; private set; }

    /// <summary>
    /// Прыжок
    /// </summary>
    public byte Jump { get; private set; }

    /// <summary>
    /// Очки здоровья
    /// </summary>
    public byte HealthPoints { get; private set; }

    /// <summary>
    /// Выносливость
    /// </summary>
    public byte Stamina { get; private set; }

    /// <summary>
    /// Переносимый вес
    /// </summary>
    public byte CarryableWeight { get; private set; }

    /// <summary>
    /// Отдых
    /// </summary>
    public byte Rest { get; private set; }

    public AdditionalCharacteristics(byte speedValue, byte physiqueValue, byte will)
    {
        Run = CalculateRun(speedValue);
        Jump = CalculateJump();
        CarryableWeight = CalculateCarryableWeight(physiqueValue);
        var (healthPoints, rest) = CalculatePhysiqueParameters(physiqueValue, will);
        HealthPoints = healthPoints;
        Stamina = healthPoints;
        Rest = rest;
        Stability = rest;
    }

    private static byte CalculateRun(byte speedValue) => (byte)(speedValue * 3);
    private byte CalculateJump() => (byte)(Run / 3);
    private static byte CalculateCarryableWeight(byte physiqueValue) => (byte)(physiqueValue * 10);

    private static (byte healthPoints, byte rest) CalculatePhysiqueParameters(byte physique, byte will)
    {
        var modifier = (byte)((physique + will) / 2);
        return ((byte)(modifier * 5), Math.Min(modifier, (byte)10));
    }
}