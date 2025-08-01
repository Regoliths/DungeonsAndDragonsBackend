namespace DungeonsAndDragons.Models;

public class PlayerCharacterDto
{
    public string Name { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty; // Updated to accept string for flexibility
    public string Class { get; set; } = string.Empty; // Updated to accept string for flexibility
    public string Background { get; set; } = string.Empty; // New property for character background
    public string Alignment { get; set; } = string.Empty; // Updated to accept string for flexibility
    public int Level { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int HitPoints { get; set; }
    public int ArmorClass { get; set; }
    public int Speed { get; set; }
    public string Notes { get; set; } = string.Empty; // New property for additional notes
}
