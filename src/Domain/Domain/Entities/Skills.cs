using Domain.Entities.SkillEntites;
using Domain.Entities.SkillEntites.Constants;

namespace Domain.Entities;

public class Skills
{
    public ICollection<Сharacteristic> SkillsCollection { get; private set; }
    public Hand2HandCombat Hand2HandCombat { get; private set; }

    public Skills()
    {
        SkillsCollection = SkillsConstants.GetSkills();
        Hand2HandCombat = new Hand2HandCombat(SkillsCollection.First(s => s.Name == SkillsConstants.Physique).Value);
    }

    public Skills(ICollection<Сharacteristic> skillsCollection)
    {
        SkillsCollection = skillsCollection;
        Hand2HandCombat = new Hand2HandCombat(SkillsCollection.First(s => s.Name == SkillsConstants.Physique).Value);
    }

    public void IncrementSkillBaseValue(string name)
    {
        var targetSkill = SkillsCollection.First(s => s.Name == name);
        targetSkill.Increment();
        if (name == SkillsConstants.Physique)
        {
            Hand2HandCombat = new Hand2HandCombat(targetSkill.Value);
        }
    }

    public void SetSkillBaseValue(string name, byte value)
    {
        var targetSkill = SkillsCollection.First(s => s.Name == name);
        targetSkill.SetValue(value);
        if (name == SkillsConstants.Physique)
        {
            Hand2HandCombat = new Hand2HandCombat(targetSkill.Value);
        }
    }

    internal byte GetStartedSkillPoints()
    {
        return (byte)(SkillsCollection
            .Where(s => s.Name is SkillsConstants.Intellect or SkillsConstants.Reaction)
            .Sum(s => s.Value) + 44);
    }
}