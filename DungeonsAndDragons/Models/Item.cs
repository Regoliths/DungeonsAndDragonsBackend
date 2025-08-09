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
