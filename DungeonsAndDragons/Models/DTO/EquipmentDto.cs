namespace DungeonsAndDragons.Models.DTO;

public class EquipmentDto
{
    public int CharacterId { get; set; } // The ID of the character that owns the equipment
    public int TotalWeight { get; set; } // Total weight of the equipment
    public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>(); // Collection of items in the equipment
}   