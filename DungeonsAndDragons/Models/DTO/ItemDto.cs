namespace DungeonsAndDragons.Models.DTO;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public int Weight { get; set; }
    public int Cost { get; set; }
    public string? DamageDice { get; set; }
    public string? DamageType { get; set; }
    public int? ArmorClass { get; set; }
    public int? AcBonus { get; set; }
    public string? ArmorType { get; set; }
    public int? StrengthRequirement { get; set; } // e.g., 13 for heavy armor
    public bool? StealthDisadvantage { get; set; } // e.g.,
    public int ? Range { get; set; } // e.g., 5 for melee, 30 for ranged
    public string? RangeType { get; set; } // e.g., "melee
}