namespace DungeonsAndDragons.Models;

public class PlayerCharacter
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Race Race { get; set; }
    public PlayerClass Class { get; set; } // Updated to use PlayerClass enum
    public string Subclass { get; set; } = string.Empty;
    public string Background { get; set; } = string.Empty; // New property for character background

    public int Level { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int HitPoints { get; set; }
    public int Speed { get; set; } = 30; // Default speed for a human is 30 feet
    public int ArmorClass { get; set; } // Armor class of the character
    public string Notes { get; set; } = string.Empty; // Additional notes about the character
    public Alignment Alignment { get; set; } // Alignment of the character

    public PlayerAccount? PlayerAccount { get; set; }
    public ICollection<Item> Inventory { get; set; } = new List<Item>();
}

