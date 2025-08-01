namespace DungeonsAndDragons.Models;

public class Spell
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Name of the spell
    public string Description { get; set; } = string.Empty; // Spell description
    public string HigherLevel { get; set; } = string.Empty; // Effects when cast at higher levels
    public string Range { get; set; } = string.Empty; // Range of the spell
    public ICollection<string> Components { get; set; } = new List<string>(); // Components required (V, S, M)
    public string Material { get; set; } = string.Empty; // Material required for the spell
    public bool Ritual { get; set; } // Whether the spell can be cast as a ritual
    public string Duration { get; set; } = string.Empty; // Duration of the spell
    public bool Concentration { get; set; } // Whether the spell requires concentration
    public string CastingTime { get; set; } = string.Empty; // Casting time of the spell
    public int Level { get; set; } // Spell level
    public string AttackType { get; set; } = string.Empty; // Type of attack (e.g., ranged, melee)
    public string DamageType { get; set; } = string.Empty; // Type of damage (e.g., acid, fire)
    public Dictionary<int, string> DamageAtSlotLevel { get; set; } = new Dictionary<int, string>(); // Damage at each slot level
    public string School { get; set; } = string.Empty; // Magic school of the spell
    public ICollection<PlayerClass> Classes { get; set; } = new List<PlayerClass>(); // Classes that can use the spell
    public ICollection<string> Subclasses { get; set; } = new List<string>(); // Subclasses that can use the spell
}
