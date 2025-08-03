namespace DungeonsAndDragons.Models.DTO;

public class ActionDto
{
    public int Id { get; set; } // Unique identifier for the action
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; // Description of the action
        
    public int Range { get; set; } // Range of the action, e.g., melee, ranged, etc.
        
    public int AttackBonus { get; set; } // Bonus to the attack roll
    
    public string DamageType { get; set; } = string.Empty; // Type of damage dealt by the action, e.g., slashing, piercing, etc.

    public int DiceCount { get; set; } // Number of dice to roll for damage
    public int DiceSize { get; set; } // Size of the dice to roll for damage, e.g., d6, d8, etc.
}