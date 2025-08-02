using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;

namespace DungeonsAndDragons.Services.Interfaces;

public interface IEquipmentService
{
    Task<Equipment> GetEquipmentAsync(int characterId);
    Task<Item> GetItemInEquipmentAsync(int characterId, int itemId);
    Task<List<Item>> GetItemsInEquipmentAsync(int characterId);
    Task<Item> AddItemToEquipmentAsync(int characterId, Item item);
    void RemoveItemFromEquipmentAsync(int characterId, int itemId);
    Task<Item> UpdateItemInEquipmentAsync(int characterId, int itemId, UpdateItemDto updatedItem);
    Task<Item> MoveItemToInventoryAsync(int characterId, int itemId);

}