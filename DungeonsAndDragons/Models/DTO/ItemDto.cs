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
}