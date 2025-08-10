using DungeonsAndDragons.Models.DTO;

namespace DungeonsAndDragons.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;// Item name
    public string Description { get; set; } = string.Empty; // Item description
    public string Type { get; set; } = string.Empty; // Item type (e.g., weapon, armor, potion)
    public int Quantity { get; set; } // Number of items
    public int Weight { get; set; } // Weight of the item
    public int Cost { get; set; } // Cost of the item in gold pieces
    public string? DamageDice { get; set; } // e.g., "1d6"
    public string? DamageType { get; set; } // e.g., "slashing"
    public int? ArmorClass { get; set; } // e.g., 15
    public int? AcBonus { get; set; } // e.g., +1
    public string? ArmorType { get; set; } // e.g., "light", "medium", "heavy"

    public Item() { }
    public Item(ItemDto itemDto)
    {
        Id = itemDto.Id;
        Name = itemDto.Name;
        Description = itemDto.Description;
        Type = itemDto.Type;
        Quantity = itemDto.Quantity;
        Weight = itemDto.Weight;
        Cost = itemDto.Cost;
        DamageDice = itemDto.DamageDice;
        DamageType = itemDto.DamageType;
        ArmorClass = itemDto.ArmorClass;
        AcBonus = itemDto.AcBonus;
        ArmorType = itemDto.ArmorType;
    }
}
