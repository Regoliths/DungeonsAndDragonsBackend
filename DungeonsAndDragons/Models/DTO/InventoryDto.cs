namespace DungeonsAndDragons.Models.DTO;

public class InventoryDto
{
    public int CharacterId { get; set; }
    public int TotalWeight { get; set; } // Total weight of the items in the inventory
    public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>(); // Collection of items in the inventory
    
}