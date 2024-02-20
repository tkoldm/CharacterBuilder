using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Domain.Entities;
using Domain.Entities.InventoryEntities;
using Domain.Entities.SkillEntites.Constants;
using Domain.Enums;
using Xunit.Abstractions;

namespace Tests.Unit.Domain;

public class CharacterTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CharacterTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

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

    [Theory]
    [MemberData(nameof(GetData))]
    public async Task ExportDataAsJson(string playerName, string characterName,
        CharactersDetails charactersDetails,
        Inventory inventory)
    {
        var character = new Character(playerName, characterName, charactersDetails, inventory);
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "TestOutput");
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
        var json = JsonSerializer.Serialize(character, new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        });
        await File.WriteAllTextAsync(Path.Combine(outputPath, $"character {character.CharacterName}.json"), json, Encoding.UTF8);
        _testOutputHelper.WriteLine(outputPath);
    }

    public static IEnumerable<object[]> GetData()
    {
        yield return
        [
            "Test User",
            "Test Character",
            new CharactersDetails(Profession.Medic, Race.Elf, CharacteristicsConstants.GetCharacteristics(), 10),
            new Inventory()
        ];
        yield return
        [
            "Test User Second",
            "Test Character Second",
            new CharactersDetails(Profession.Medic, Race.Elf, CharacteristicsConstants.GetCharacteristics(), 10),
            new Inventory(new List<Armor>
                {
                    new("Аэдирнский Гамбезон", 1.5f, 75, BodyPart.Body, 5)
                },
                new List<Weapon>
                {
                    new("Гледдиф", 3, 689, 0, "3d6+2", 5, 2,
                        [new WeaponEffect(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров")],
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
                new Magic(),
                CharacteristicsConstants.GetCharacteristics(), 5),
            new Inventory(new List<Armor>
                {
                    new("Аэдирнский Гамбезон", 1.5f, 75, BodyPart.Body, 5)
                },
                new List<Weapon>
                {
                    new("Гледдиф", 3, 689, 0, "3d6+2", 5, 2,
                        [new WeaponEffect(Effect.Long, "Этим оружием можно атаковать цель в пределах 2х метров")],
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