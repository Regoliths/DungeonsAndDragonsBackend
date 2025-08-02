namespace DungeonsAndDragons.Models;

public class Equipment
{
    public int Id { get; set; }
    public int TotalWeight { get; set; } // Total weight of the equipment
    public int CharacterId { get; set; }
    public Character Character { get; set; } = new Character(); // The character that owns the equipment
    public ICollection<Item> Items { get; set; } = new List<Item>(); // Collection of items in the equipment
}