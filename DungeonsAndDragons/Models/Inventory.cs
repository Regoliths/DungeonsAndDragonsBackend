using DungeonsAndDragons.Models.DTO;

namespace DungeonsAndDragons.Models;

public class Inventory
{
    
    public int Id { get; set; }
    public int TotalWeight { get; set; } // Total weight of the items in the inventory
    public int CharacterId { get; set; }
    public Character Character { get; set; } = new Character(); // The character that owns the equipment
    public ICollection<Item> Items { get; set; } = new List<Item>(); // Collection of items in the equipment
    public Inventory() { }
    public Inventory(InventoryDto inventoryDto)
    {
        CharacterId = inventoryDto.CharacterId;
        TotalWeight = inventoryDto.TotalWeight;
        Items = inventoryDto.Items.Select(i => new Item(i)).ToList();
    }
}