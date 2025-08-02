using DungeonsAndDragons.Models;

namespace DungeonsAndDragons.Factory;

public static class CharacterFactory
{
    // This method will build the entire object graph for us.
    public static Character Create(
        int id, string name, Race race, PlayerClass playerClass,
        Background background, Alignment alignment, int level,
        int strength, int dexterity, int constitution, int intelligence,
        int wisdom, int charisma, int hitPoints, int speed, int armorClass,
        int equipmentId, List<Item> equipmentItems, int inventoryId, List<Item> inventoryItems,
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
            HitDice = hitDice,
            Speed = speed,
            ArmorClass = armorClass,
            Notes = notes,
            PlayerAccount = playerAccount,
            Initiative = 10 + dexterity, // Initiative is calculated based on Dexterity
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

        // 4. Return the fully constructed character.
        return character;
    }
}