namespace Domain.Enums;

/// <summary>
/// Эффект оружия
/// </summary>
public enum Effect
{
    Undefined = 0,

    /// <summary>
    /// Незаметное
    /// </summary>
    Unnoticeable = 1,

    /// <summary>
    /// Кровопускающее
    /// </summary>
    Bloodletting = 2,

    /// <summary>
    /// Пробивающее броню
    /// </summary>
    ArmorPiercing = 3,

    /// <summary>
    /// Дезориентирующее
    /// </summary>
    Disorienting = 4,

    /// <summary>
    /// Метеоритное
    /// </summary>
    Meteorite = 5,

    /// <summary>
    /// Длинное
    /// </summary>
    Long = 6,

    /// <summary>
    /// Фокусирующее
    /// </summary>
    Focusing = 7,

    /// <summary>
    /// Улучшенное фокусирующее
    /// </summary>
    ImprovedFocusing = 8,

    /// <summary>
    /// Захватное
    /// </summary>
    Gripper = 9,

    /// <summary>
    /// Медленно перезаряжающееся
    /// </summary>
    SlowToRecharge = 10,

    /// <summary>
    /// Несмертельное
    /// </summary>
    NonLethal = 11,

    /// <summary>
    /// Сбалансированное
    /// </summary>
    Balanced = 12,

    /// <summary>
    /// Разрушающее
    /// </summary>
    Destructive = 13,

    /// <summary>
    /// Рукопашное
    /// </summary>
    HandToHand = 14,
}