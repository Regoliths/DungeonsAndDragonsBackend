using DungeonsAndDragons.Models;
using Action = DungeonsAndDragons.Models.Action;

namespace DungeonsAndDragons.Factory;

public static class CharacterFactory
{
    // This method will build the entire object graph for us.
    public static Character Create(
        int id, string name, Race race, PlayerClass playerClass,
        Background background, Alignment alignment, int level,
        int strength, int dexterity, int constitution, int intelligence,
        int wisdom, int charisma, int hitPoints, int speed,
        int equipmentId, List<Item> equipmentItems, int inventoryId, List<Item> inventoryItems, List<Action> actions,
        string? subclass = "", int? hitDice = 0, string? notes = "", PlayerAccount? playerAccount = null
        )
    {
        // 1. Create the parent object.
        var character = new Character
        {
            Id = id,
            Name = name,
            Race = race,
            Class = playerClass,
            Subclass = subclass,
            Background = background,
            Alignment = alignment,
            Level = level,
            Strength = strength,
            Dexterity = dexterity,
            Constitution = constitution,
            Intelligence = intelligence,
            Wisdom = wisdom,
            Charisma = charisma,
            HitPoints = hitPoints,
            MaxHitPoints = hitPoints, // Assuming maxHitPoints is the same as HitPoints for simplicity
            HitDice = hitDice,
            Speed = speed,
            ArmorClass = 10, // Example of logic for Armor Class
            Notes = notes,
            PlayerAccount = playerAccount ?? null,
            Initiative = 10 + dexterity, // Initiative is calculated based on Dexterity
            Actions = actions ?? new List<Action>() // Initialize with an empty list if null
        };

        // 2. Create the child object, passing the parent reference.
        var equipment = new Equipment
        {
            Id = equipmentId,
            Character = character, // <-- The crucial back-reference is set here!
            Items = equipmentItems,
            TotalWeight = equipmentItems.Sum(i => i.Weight * i.Quantity) // Example of logic
        };
        
        var inventory = new Inventory
        {
            Id = inventoryId,
            Character = character, // <-- The crucial back-reference is set here!
            Items = inventoryItems,
            TotalWeight = inventoryItems.Sum(i => i.Weight * i.Quantity) // Example of logic
        };
        

        // 3. Assign the child to the parent.
        character.Equipment = equipment;
        
        character.Inventory = inventory;
        
        // 4. calculate the Armor Class based on Dexterity annd items in Equipment
        character.ArmorClass = CalculateArmorClass(character);
        // 5. Return the fully constructed character.
        return character;
    }
    
    private static int CalculateArmorClass(Character character)
    {
        int baseAc = 10; // Base AC for an unarmored character
        int dexModifier = CalculateDexterityModifier(character.Dexterity);

        // Find the primary armor worn by the character (not a shield)
        var wornArmor = character.Equipment.Items
            .OfType<Armor>()
            .Max(a => a.ArmorClass);
            
            // Total AC starts with base (from armor or 10) + dex modifier
            int totalAc = Math.Max(wornArmor, 10 + dexModifier); // Ensure AC is at least 10

            // Check if a shield is equipped and add its bonus
            var shield = character.Equipment.Items
                .OfType<Armor>()
                .FirstOrDefault(a => a.Name != "Shield") ?? new Armor();

            if (shield != null)
            {
                totalAc += shield.ArmorClass; // Shields provide a direct bonus, stored in BaseAC
            }

            return totalAc;
    }
    
    private static int CalculateDexterityModifier(int dexterity)
    {
        // Example logic to calculate Dexterity modifier
        return (dexterity - 10) / 2;
    }
}
