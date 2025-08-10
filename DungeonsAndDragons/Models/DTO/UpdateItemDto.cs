namespace DungeonsAndDragons.Models.DTO;

public class UpdateItemDto
{
    // We use nullable types so we can tell which properties the client wants to update.
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public int? Weight { get; set; }
    public int? Quantity { get; set; }
    public int? Cost { get; set; }
    public string? DamageDice { get; set; }
    public string? DamageType { get; set; }
    public int? ArmorClass { get; set; }
    public int? AcBonus { get; set; }
    public string? ArmorType { get; set; }
}