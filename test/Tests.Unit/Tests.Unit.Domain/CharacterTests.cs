using Domain.Entities;
using Domain.Entities.InventoryEntities;
using Domain.Entities.MagicEntities;
using Domain.Enums;

namespace Tests.Unit.Domain;

public class CharacterTests
{
    [Theory]
    [MemberData(nameof(GetData))]
    public void Ctor_FullData_CreatesNewInstanceOfCharacter(string playerName, string characterName,
        CharactersDetails charactersDetails,
        Inventory inventory)
    {
        var character = new Character(playerName, characterName, charactersDetails, inventory);
        Assert.Equal(playerName, character.PlayerName);
        Assert.Equal(characterName, character.CharacterName);
        Assert.NotNull(character.CharactersDetails);
        Assert.NotNull(character.Inventory);
    }

    public static IEnumerable<object[]> GetData()
    {
        yield return
        [
            "Test User",
            "Test Character",
            new CharactersDetails(Profession.Medic, Race.Elf, new Skills(), 10),
            new Inventory()
        ];
        yield return
        [
            "Test User Second",
            "Test Character Second",
            new CharactersDetails(Profession.Medic, Race.Elf, new Skills(), 10),
            new Inventory(new List<Armor>
                {
                    new("Аэдирнский Гамбезон", 1.5f, 75, BodyPart.Body, 5)
                },
                new List<Weapon>
                {
                    new("Гледдиф", 3, 689, 0, "3d6+2", 5, 2,
                        [new WeaponEffect(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров", null)],
                        WeaponSize.Large, 0)
                },
                new List<Equipment>
                {
                    new("Письменные принадлежности", 1, 50, "Позволяют писать записки, письма и т.д.")
                },
                new List<Component>
                {
                    new("Свечи *5", 0.5f, 10)
                })
        ];
        yield return
        [
            "Test User Third",
            "Test Character Third",
            new CharactersDetails(Profession.Priest, Race.Elf,
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
                new Skills(), 5),
            new Inventory(new List<Armor>
                {
                    new("Аэдирнский Гамбезон", 1.5f, 75, BodyPart.Body, 5)
                },
                new List<Weapon>
                {
                    new("Гледдиф", 3, 689, 0, "3d6+2", 5, 2,
                        [new WeaponEffect(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров", null)],
                        WeaponSize.Large, 0)
                },
                new List<Equipment>
                {
                    new("Письменные принадлежности", 1, 50, "Позволяют писать записки, письма и т.д.")
                },
                new List<Component>
                {
                    new("Свечи *5", 0.5f, 10)
                })
        ];
    }
}