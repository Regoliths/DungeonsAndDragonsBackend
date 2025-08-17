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
    }
}

public class Weapon : Item
{
    public string DamageDice { get; set; } // e.g., "1d6"
    public string DamageType { get; set; } // e.g., "slashing"
    public int Range { get; set; }
    public string RangeType { get; set; } // e.g., "melee", "ranged"
    public Weapon() : base() { }
    public Weapon(ItemDto itemDto) : base(itemDto) { }
}

public class Armor : Item
{
    public int ArmorClass { get; set; } // e.g., 15
    public int AcBonus { get; set; } // e.g., +1
    public string ArmorType { get; set; } // e.g., "light", "medium", "heavy"
    public int strengthRequirement { get; set; } // e.g., 13 for heavy armor
    public bool StealthDisadvantage { get; set; } // e.g., true for heavy armor
    public Armor() : base() { }
    public Armor(ItemDto itemDto) : base(itemDto) { }
}