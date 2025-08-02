namespace DungeonsAndDragons.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Race Race { get; set; }
    public PlayerClass Class { get; set; } 
    public string? Subclass { get; set; } = string.Empty;
    public Background Background { get; set; }

    public int Level { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int HitPoints { get; set; }
    public int? HitDice { get; set; }
    public int Speed { get; set; } = 30; // Default speed for a human is 30 feet
    public int Initiative { get; set; }
    public int ArmorClass { get; set; } 
    public string? Notes { get; set; } = string.Empty; 
    public Alignment Alignment { get; set; }
    public PlayerAccount? PlayerAccount { get; set; }
    //public ICollection<Proficiency> Proficiencies { get; set; } = new List<Proficiency>(); // Proficiencies of the monster
    public Equipment Equipment { get; set; }
    public Inventory Inventory { get; set; }
}

