using DungeonsAndDragons.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Services;

public class InventoryService
{
    private readonly ApplicationDbContext _context;
    
    private CharacterService _characterService;

    public InventoryService(ApplicationDbContext context)
    {
        _context = context;
        _characterService = new CharacterService(_context);
    }
    
    public Task<List<Item>> GetInventoryAsync(int characterId)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            throw new Exception("Character not found");
        }

        return Task.FromResult(character.Inventory.ToList());
    }
    
    public Task<Item> GetItemAsync(int characterId, int itemId)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            throw new Exception("Character not found");
        }

        var item = character.Inventory.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            throw new Exception("Item not found in character's inventory");
        }

        return Task.FromResult(item);
    }
    
    public Task<Item> AddItemAsync(int characterId, Item item)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            throw new Exception("Character not found");
        }

        character.Inventory.Add(item);
        _context.SaveChanges();

        return Task.FromResult(item);
    }

    public void RemoveItem(int characterId, int itemId)
    {
        var character = _characterService.GetCharacter(characterId);
        if (character == null)
        {
            throw new Exception("Character not found");
        }
        var item = character.Inventory.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            throw new Exception("Item not found in character's inventory");
        }
        character.Inventory.Remove(item);
        _context.SaveChanges();
    }

    public void UpdateQuantity(int characterId, int itemId, int newQuantity)
    {
        var character = _characterService.GetCharacter(characterId);
        if (character == null)
        {
            throw new Exception("Character not found");
        }
        var item = character.Inventory.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            throw new Exception("Item not found in character's inventory");
        }
        item.Quantity = newQuantity;
        _context.SaveChanges();
    }
    
    public void UpdateCost(int characterId, int itemId, int newCost)
    {
        var character = _characterService.GetCharacter(characterId);
        if (character == null)
        {
            throw new Exception("Character not found");
        }
        var item = character.Inventory.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            throw new Exception("Item not found in character's inventory");
        }
        item.Cost = newCost;
        _context.SaveChanges();
    }

}