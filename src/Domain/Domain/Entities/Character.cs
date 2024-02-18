namespace Domain.Entities;

public class Character
{
    public string PlayerName { get; private set; }
    public string CharacterName { get; private set; }
    public CharactersDetails CharactersDetails { get; private set; }
    public Inventory Inventory { get; private set; }

    public Character(string playerName, string characterName, CharactersDetails charactersDetails, Inventory inventory)
    {
        PlayerName = playerName;
        CharacterName = characterName;
        CharactersDetails = charactersDetails;
        Inventory = inventory;
    }
}