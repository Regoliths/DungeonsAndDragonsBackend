using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Models;

public class Action
{
        public int Id { get; set; } // Unique identifier for the action
        public string Name { get; set; } = string.Empty; // Name of the action
        public string Description { get; set; } = string.Empty; // Description of the action
        public int Range { get; set; } // Range of the action, e.g., melee, ranged, etc.
        public int AttackBonus { get; set; } // Attack bonus for the action
        public Damage Damage { get; set; } = new Damage(); // Damage dealt by the action
}

public class SpecialAbility
{
        public string Name { get; set; } = string.Empty; // Name of the special ability
        public string Description { get; set; } = string.Empty; // Description of the special ability
}

public class LegendaryAction
{
        public string Name { get; set; } = string.Empty; // Name of the legendary action
        public string Description { get; set; } = string.Empty; // Description of the legendary action
        public Damage Damage { get; set; } = new Damage(); // Damage dealt by the legendary action
}

[Owned]                  // 👈 tells EF Core “treat this as part of the owner”
public class Damage
{
        public string? DamageType { get; set; } = string.Empty; // Type of damage (e.g., bludgeoning, acid)
        public int DiceCount { get; set; }
        public int DiceSides { get; set; }// Dice roll for damage (e.g., 2d6+5)

        public Damage() {}
        
        public Damage(int numberOfDice, int diceSides, string damageType)
        { 
                DiceCount = numberOfDice; 
                DiceSides = diceSides; 
                DamageType = damageType;
        }
}
