namespace DungeonsAndDragons.Models;

public class Monster
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Name of the monster
    public string Size { get; set; } = string.Empty; // Size of the monster (e.g., Large, Medium)
    public MonsterType Type { get; set; } // Type of the monster (e.g., aberration)
    public Alignment Alignment { get; set; } // Alignment of the monster
    public int ArmorClass { get; set; } // Armor class of the monster
    public int HitPoints { get; set; } // Hit points of the monster
    public string HitDice { get; set; } = string.Empty; // Hit dice of the monster
    public string Speed { get; set; } = string.Empty; // Speed of the monster (e.g., walk, swim)
    public int Strength { get; set; } // Strength score
    public int Dexterity { get; set; } // Dexterity score
    public int Constitution { get; set; } // Constitution score
    public int Intelligence { get; set; } // Intelligence score
    public int Wisdom { get; set; } // Wisdom score
    public int Charisma { get; set; } // Charisma score
    public ICollection<Proficiency> Proficiencies { get; set; } = new List<Proficiency>(); // Proficiencies of the monster
    public ICollection<string> DamageVulnerabilities { get; set; } = new List<string>(); // Damage vulnerabilities
    public ICollection<string> DamageResistances { get; set; } = new List<string>(); // Damage resistances
    public ICollection<string> DamageImmunities { get; set; } = new List<string>(); // Damage immunities
    public ICollection<string> ConditionImmunities { get; set; } = new List<string>(); // Condition immunities
    public string Senses { get; set; } = string.Empty; // Senses of the monster (e.g., darkvision)
    public string Languages { get; set; } = string.Empty; // Languages the monster can speak
    public int ChallengeRating { get; set; } // Challenge rating of the monster
    public int ProficiencyBonus { get; set; } // Proficiency bonus of the monster
    public int XP { get; set; } // Experience points for defeating the monster
    public ICollection<SpecialAbility> SpecialAbilities { get; set; } = new List<SpecialAbility>(); // Special abilities of the monster
    public ICollection<Action> Actions { get; set; } = new List<Action>(); // Actions the monster can perform
    public ICollection<LegendaryAction> LegendaryActions { get; set; } = new List<LegendaryAction>(); // Legendary actions
}