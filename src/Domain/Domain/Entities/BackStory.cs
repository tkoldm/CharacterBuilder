namespace Domain.Entities;

public class BackStory
{
    public string CharacterData { get; private set; }
    public string Childhood { get; private set; }
    public IDictionary<short, string> Events { get; private set; }

    public BackStory()
    {
    }
}