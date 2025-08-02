using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using DungeonsAndDragons.Services.Interfaces;

namespace DungeonsAndDragons.Services;

public class EquipmentService : IEquipmentService
{
     private readonly ApplicationDbContext _context;
    
    private CharacterService _characterService;
    private ItemService _itemService;

    public EquipmentService(ApplicationDbContext context)
    {
        _context = context;
        _characterService = new CharacterService(_context);
        _itemService = new ItemService(_context);
    }
    
    public Task<Equipment> GetEquipmentAsync(int characterId)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            throw new CharacterNotFoundException(characterId);
        }

        return Task.FromResult(character.Equipment);
    }

    public Task<Item> GetItemInEquipmentAsync(int characterId, int itemId)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            throw new CharacterNotFoundException(characterId);
        }

        var item = character.Equipment.Items.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            throw new ItemNotFoundException(itemId);
        }

        return Task.FromResult(item);
    }

    public Task<List<Item>> GetItemsInEquipmentAsync(int characterId)
    {
        var character = _characterService.GetCharacter(characterId);
        
        if (character == null)
        {
            throw new CharacterNotFoundException(characterId);
        }
        
        var items = character.Equipment.Items;
        
        if (items == null || !items.Any())
        {
            throw new Exception("No items found in equipment.");
        }
        if (items.Count == 0)
        {
            return Task.FromResult(new List<Item>());
        }
        return Task.FromResult(items.ToList());
    }

    public Task<Item> AddItemToEquipmentAsync(int characterId, Item item)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            throw new CharacterNotFoundException(characterId);
        }

        character.Equipment.Items.Add(item);
        _context.SaveChanges();

        return Task.FromResult(item);
    }
    
    public void RemoveItemFromEquipmentAsync(int characterId, int itemId)
    {
        var character = _characterService.GetCharacter(characterId);
        if (character == null)
        {
            throw new CharacterNotFoundException(characterId);
        }

        var item = character.Equipment.Items.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            throw new ItemNotFoundException(itemId);
        }

        character.Equipment.Items.Remove(item);
        _context.SaveChanges();
    }
    
    public Task<Item> UpdateItemInEquipmentAsync(int characterId, int itemId, UpdateItemDto updatedItem)
    {
        var character = _characterService.GetCharacter(characterId);
        if (character == null)
        {
            throw new CharacterNotFoundException(characterId);
        }

        var item =_itemService.UpdateItemAsync(itemId, updatedItem);

        _context.SaveChanges();
        
        return Task.FromResult(item.Result);
    }
    
    public Task<Item> MoveItemToInventoryAsync(int characterId, int itemId)
    {
        var character = _characterService.GetCharacter(characterId);
        if (character == null)
        {
            throw new CharacterNotFoundException(characterId);
        }

        var item = character.Equipment.Items.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            throw new ItemNotFoundException(itemId);
        }

        character.Equipment.Items.Remove(item);
        character.Inventory.Items.Add(item);
        
        _context.SaveChanges();

        return Task.FromResult(item);
    }
}