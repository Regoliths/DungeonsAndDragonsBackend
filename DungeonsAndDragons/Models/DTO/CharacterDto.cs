namespace DungeonsAndDragons.Models.DTO;

public class CharacterDto
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
    public int MaxHitPoints { get; set; } // Assuming maxHitPoints is the same as HitPoints for simplicity
    public int HitDice { get; set; } // Represents the size of the hit die (e.g., d6, d8)
    public int ArmorClass { get; set; }
    public int Speed { get; set; }
    public int Initiative => 10 + Dexterity; // Initiative is calculated based on Dexterity
    public string Notes { get; set; } = string.Empty; // New property for additional notes

    public EquipmentDto Equipment { get; set; } // New property for equipment
    public InventoryDto Inventory { get; set; }  // New property for inventory
    public ICollection<ActionDto> Actions { get; set; } //New property for actions

    public static CharacterDto FromCharacter(Character character)
    {
        var newCharacter = new CharacterDto()
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
            MaxHitPoints = character.MaxHitPoints, // Assuming MaxHitPoints is nullable in Character
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
                }).ToList(),
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
            },
            Actions = new List<ActionDto>(
                character.Actions.Select(a => new ActionDto()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Range = a.Range,
                    Description = a.Description,
                    DiceCount = a.Damage.DiceCount,
                    DiceSize = a.Damage.DiceSides,
                    DamageType = a.Damage.DamageType
                }).ToList())
        };
        
        return newCharacter;
    }
}
