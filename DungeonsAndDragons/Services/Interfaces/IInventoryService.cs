using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;

namespace DungeonsAndDragons.Services.Interfaces;

public interface IInventoryService
{
    Task<Inventory> GetInventoryAsync(int characterId);
    Task<Item> GetItemInInventoryAsync(int characterId, int itemId);
    Task<List<Item>> GetItemsInInventoryAsync(int characterId);
    Task<Item> AddItemToInventoryAsync(int characterId, Item item);
    void RemoveItemFromInventoryAsync(int characterId, int itemId);
    Task<Item> UpdateItemInInventoryAsync(int characterId, int itemId, UpdateItemDto updatedItem);
    Task<Item> MoveItemToEquipmentAsync(int characterId, int itemId);

}