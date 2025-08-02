using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;

namespace DungeonsAndDragons.Services.Interfaces;

public interface IItemService
{
    Task<Item> GetItemAsync(int itemId);
    Task<Item> UpdateItemAsync(int itemId, UpdateItemDto updateDto);
    Task DeleteItemAsync(int itemId);
}