namespace DungeonsAndDragons.Models.DTO;

public class PlayerCharacterDto
{
    public string Name { get; set; } = string.Empty;
    public int Race { get; set; } // Updated to accept string for flexibility
    public int Class { get; set; } // Updated to accept string for flexibility
    public int Background { get; set; } // New property for character background
    public int Alignment { get; set; } // Updated to accept string for flexibility
    public int Level { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int HitPoints { get; set; }
    public int HitDice { get; set; } // Represents the size of the hit die (e.g., d6, d8)
    public int ArmorClass { get; set; }
    public int Speed { get; set; }
    public int Initiative => 10 + Dexterity; // Initiative is calculated based on Dexterity
    public string Notes { get; set; } = string.Empty; // New property for additional notes

    public EquipmentDto Equipment { get; set; } // New property for equipment
    public InventoryDto Inventory { get; set; }  // New property for inventory

    public static PlayerCharacterDto FromCharacter(Character character)
    {
        var newCharacter = new PlayerCharacterDto()
        {
            Name = character.Name,
            Race = (int)character.Race,
            Class = (int)character.Class,
            Background = (int)character.Background,
            Alignment = (int)character.Alignment,
            Level = character.Level,
            Strength = character.Strength,
            Dexterity = character.Dexterity,
            Constitution = character.Constitution,
            Intelligence = character.Intelligence,
            Wisdom = character.Wisdom,
            Charisma = character.Charisma,
            HitPoints = character.HitPoints,
            HitDice = character.HitDice ?? 0, // Assuming HitDice is nullable in Character
            ArmorClass = character.ArmorClass,
            Speed = character.Speed,
            Notes = character.Notes ?? string.Empty, // Assuming Notes can be null in Character
            Equipment = new EquipmentDto
            {
            TotalWeight = character.Equipment.TotalWeight,
            CharacterId = character.Equipment.CharacterId,
            Items = character.Equipment.Items.Select(i => new ItemDto
            {
                Id = i.Id,
                Name = i.Name,
                Weight = i.Weight,
                Quantity = i.Quantity
            }).ToList()
        },
        Inventory = new InventoryDto
        {
            TotalWeight = character.Inventory.TotalWeight,
            CharacterId = character.Inventory.CharacterId,
            Items = character.Inventory.Items.Select(i => new ItemDto
            {
                Id = i.Id,
                Name = i.Name,
                Weight = i.Weight,
                Quantity = i.Quantity
            }).ToList()
        }
        };
        
        return newCharacter;
    }
}
