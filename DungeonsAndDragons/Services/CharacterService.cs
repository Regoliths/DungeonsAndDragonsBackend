using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Action = DungeonsAndDragons.Models.Action;

namespace DungeonsAndDragons.Services;

public class CharacterService
{
    private readonly ApplicationDbContext _context;

    private Dictionary<int, Race> _raceMapping;
    private Dictionary<int, PlayerClass> _classMapping;
    private Dictionary<int, Alignment> _alignmentMapping;
    private Dictionary<int, Background> _backgroundMapping;
    public CharacterService(ApplicationDbContext context)
    {
        _context = context;
        _alignmentMapping = new Dictionary<int, Alignment>
        {
            { 0, Alignment.LawfulGood },
            { 1, Alignment.NeutralGood },
            { 2, Alignment.ChaoticGood },
            { 3, Alignment.LawfulNeutral },
            { 4, Alignment.TrueNeutral },
            { 5, Alignment.ChaoticNeutral },
            { 6, Alignment.LawfulEvil },
            { 7, Alignment.NeutralEvil },
            { 8, Alignment.ChaoticEvil }
        };
        _classMapping = new Dictionary<int, PlayerClass>
        {
            { 0, PlayerClass.Barbarian },
            { 1, PlayerClass.Bard },
            { 2, PlayerClass.Cleric },
            { 3, PlayerClass.Druid },
            { 4, PlayerClass.Fighter },
            { 5, PlayerClass.Monk },
            { 6, PlayerClass.Paladin },
            { 7, PlayerClass.Ranger },
            { 8, PlayerClass.Rogue },
            { 9, PlayerClass.Sorcerer },
            { 10, PlayerClass.Warlock },
            { 11, PlayerClass.Wizard }
        };
        _raceMapping = new Dictionary<int, Race>
        {
            { 0, Race.Dragonborn },
            { 1, Race.Dwarf },
            { 2, Race.Elf },
            { 3, Race.Gnome },
            { 4, Race.HalfOrc },
            { 5, Race.HalfOrc },
            { 6, Race.Halfling },
            { 7, Race.Human },
            { 8, Race.Tiefling },
        };
        _backgroundMapping = new Dictionary<int, Background>
        {
            { 0, Background.Acolyte },
            { 1, Background.Criminal },
            { 2, Background.FolkHero },
            { 4, Background.Noble },
            { 5, Background.Sage },
            { 6, Background.Soldier },
            { 7, Background.Charlatan },
            { 8, Background.Entertainer },
            { 9, Background.GuildArtisan },
            { 10, Background.Hermit },
            { 11, Background.Outlander },
            { 12, Background.Sailor },
            { 13, Background.Urchin }
        };
    }

    public Character CreateCharacter(CharacterDto characterDto)
    {

        var character = new Character
        {
            Name = characterDto.Name,
            Race = _raceMapping.ContainsKey(characterDto.Race) ? _raceMapping[characterDto.Race] : Race.Human,
            Class = _classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : PlayerClass.Barbarian,
            Background = _backgroundMapping.ContainsKey(characterDto.Background) ? _backgroundMapping[characterDto.Background] : Background.Acolyte,
            Alignment = _alignmentMapping.ContainsKey(characterDto.Alignment) ? _alignmentMapping[characterDto.Alignment] : Alignment.TrueNeutral,
            Level = characterDto.Level,
            Strength = characterDto.Strength,
            Dexterity = characterDto.Dexterity,
            Constitution = characterDto.Constitution,
            Intelligence = characterDto.Intelligence,
            Wisdom = characterDto.Wisdom,
            Charisma = characterDto.Charisma,
            HitPoints = characterDto.HitPoints,
            MaxHitPoints = characterDto.MaxHitPoints,
            HitDice = HitDieSize(_classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : PlayerClass.Barbarian),
            ArmorClass = characterDto.ArmorClass,
            Speed = characterDto.Speed,
            Initiative = 10 + characterDto.Dexterity, // Initiative is calculated based on Dexterity
            Notes = characterDto.Notes
        };
        character.Equipment = new Equipment
        {
            CharacterId = character.Id,
            Items = new List<Item>(),
            TotalWeight = 0
        };
        character.Inventory = new Inventory
        {
            CharacterId = character.Id,
            Items = new List<Item>(),
            TotalWeight = 0
        };
        character.Actions = new List<Action>();

        _context.PlayerCharacters.Add(character);
        _context.SaveChanges();

        return character;
    }

    public void UpdateCharacter(CharacterDto characterDto, Character character)
    {
        
        character.Name = characterDto.Name;
        character.Race = _raceMapping.ContainsKey(characterDto.Race) ? _raceMapping[characterDto.Race] : character.Race;
        character.Class = _classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : character.Class;
        character.Background = _backgroundMapping.ContainsKey(characterDto.Background) ? _backgroundMapping[characterDto.Background] : character.Background;
        character.Level = characterDto.Level;
        character.Strength = characterDto.Strength;
        character.Dexterity = characterDto.Dexterity;
        character.Constitution = characterDto.Constitution;
        character.Intelligence = characterDto.Intelligence;
        character.Wisdom = characterDto.Wisdom;
        character.Charisma = characterDto.Charisma;
        character.HitPoints = characterDto.HitPoints;
        character.HitDice = HitDieSize(_classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : character.Class);
        character.Speed = characterDto.Speed;
        character.Initiative = 10 + characterDto.Dexterity; // Initiative is calculated based on Dexterity
        character.ArmorClass = characterDto.ArmorClass;
        character.Alignment = _alignmentMapping.ContainsKey(characterDto.Alignment) ? _alignmentMapping[characterDto.Alignment] :character.Alignment;
        character.Notes = characterDto.Notes;
        character.MaxHitPoints = characterDto.MaxHitPoints;
        character.Equipment.TotalWeight = characterDto.Equipment?.TotalWeight ?? 0;
        character.Inventory.TotalWeight = characterDto.Inventory?.TotalWeight ?? 0;
        
        if (characterDto.Equipment?.Items != null)
        {
            // Track current item IDs before update
            var previousEquipmentItemIds = character.Equipment.Items.Select(i => i.Id).ToList();
            var newEquipmentItemIds = characterDto.Equipment.Items.Where(i => i.Id != 0).Select(i => i.Id).ToList();
            var existingItems = _context.Items.Where(i => newEquipmentItemIds.Contains(i.Id)).ToList();

            character.Equipment.Items = characterDto.Equipment.Items.Select(i =>
            {
                if (i.Id == 0 || !existingItems.Any(ei => ei.Id == i.Id))
                {
                    var newItem = new Item(i);
                    _context.Items.Add(newItem);
                    return newItem;
                }
                else
                {
                    return existingItems.First(ei => ei.Id == i.Id);
                }
            }).ToList();

            // Remove items that were in Equipment but are no longer present
            var updatedEquipmentItemIds = character.Equipment.Items.Select(i => i.Id).ToList();
            var removedEquipmentItemIds = previousEquipmentItemIds.Except(updatedEquipmentItemIds).ToList();
            var removedEquipmentItems = _context.Items.Where(i => removedEquipmentItemIds.Contains(i.Id)).ToList();
            foreach (var removedItem in removedEquipmentItems)
            {
                _context.Items.Remove(removedItem);
            }

            // Recalculate ArmorClass based on equipped items
            int baseAC = 10 + (character.Dexterity - 10) / 2; 
            int armorAc= character.Equipment.Items 
                .OfType<Armor>() 
                .Max(armor => armor.ArmorClass);       
            int acBonus = character.Equipment.Items
                .OfType<Armor>() // Filters and casts to Armor type
                .Sum(armor => armor.AcBonus);
            int? shieldAC = character.Equipment.Items
                .OfType<Armor>() // Filters and casts to Armor type
                .FirstOrDefault(armor => armor.Name.Equals("Shield", StringComparison.OrdinalIgnoreCase))?.ArmorClass ?? 0;            
            if (armorAc > 0)
            {
                character.ArmorClass = armorAc + acBonus;
            }
            else
            {
                character.ArmorClass = baseAC + acBonus;
            }

            if (shieldAC.HasValue)
            {
                character.ArmorClass += shieldAC.Value + acBonus;
            }
        }

        if (characterDto.Inventory?.Items != null)
        {
            // Track current item IDs before update
            var previousInventoryItemIds = character.Inventory.Items.Select(i => i.Id).ToList();
            var newInventoryItemIds = characterDto.Inventory.Items.Where(i => i.Id != 0).Select(i => i.Id).ToList();
            var existingItems = _context.Items.Where(i => newInventoryItemIds.Contains(i.Id)).ToList();

            character.Inventory.Items = characterDto.Inventory.Items.Select(i =>
            {
                if (i.Id == 0 || !existingItems.Any(ei => ei.Id == i.Id))
                {
                    var newItem = new Item(i);
                    _context.Items.Add(newItem);
                    return newItem;
                }
                else
                {
                    return existingItems.First(ei => ei.Id == i.Id);
                }
            }).ToList();

            // Remove items that were in Inventory but are no longer present
            var updatedInventoryItemIds = character.Inventory.Items.Select(i => i.Id).ToList();
            var removedInventoryItemIds = previousInventoryItemIds.Except(updatedInventoryItemIds).ToList();
            var removedInventoryItems = _context.Items.Where(i => removedInventoryItemIds.Contains(i.Id)).ToList();
            foreach (var removedItem in removedInventoryItems)
            {
                _context.Items.Remove(removedItem);
            }
        }
        
        _context.PlayerCharacters.Update(character);
        _context.SaveChanges();

    } 
    
    public Character? GetCharacter(int characterId)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory).ThenInclude(i => i.Items)
            .Include(c => c.Equipment).ThenInclude(i => i.Items)
            .Include(c => c.Actions)
            .FirstOrDefault(c => c.Id == characterId);
        
        //check chracter equipement and inventory itemm types to ensure they are correctly cast as Item, Armor, Weapon, etc.
        if (character != null)
        {
            character.Inventory.Items = character.Inventory.Items.Select(i => i as Item).ToList();
            character.Equipment.Items = character.Equipment.Items.Select(i => i as Item).ToList();
            character.Actions = character.Actions.Select(a => a as Action).ToList();
        }

        return character;
    }
    
    public IEnumerable<Character> GetAllCharacters()
    {
        return _context.PlayerCharacters.ToList();
    }
    
    public void DeleteCharacter(int characterId)
    {
        var character = _context.PlayerCharacters.Find(characterId);
        if (character != null)
        {
            _context.PlayerCharacters.Remove(character);
            _context.SaveChanges();
        }
    }
    
    
    private int HitDieSize(PlayerClass playerClass)
    {
        return playerClass switch
        {
            PlayerClass.Barbarian => 12,
            PlayerClass.Bard => 8,
            PlayerClass.Cleric => 8,
            PlayerClass.Druid => 8,
            PlayerClass.Fighter => 10,
            PlayerClass.Monk => 8,
            PlayerClass.Paladin => 10,
            PlayerClass.Ranger => 10,
            PlayerClass.Rogue => 8,
            PlayerClass.Sorcerer => 6,
            PlayerClass.Warlock => 8,
            PlayerClass.Wizard => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(playerClass), "Unknown player class")
        };
    }

    private Armor chckArmorType(Item item)
    {
        if (item is Armor armor)
        {
            return armor;
        }
        else
        {
            throw new InvalidCastException("Item is not of type Armor.");
        }
    }
    
    private Weapon chckWeaponType(Item item)
    {
        if (item is Weapon weapon)
        {
            return weapon;
        }
        else
        {
            throw new InvalidCastException("Item is not of type Weapon.");
        }
    }

}
