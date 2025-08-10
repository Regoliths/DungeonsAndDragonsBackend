using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using DungeonsAndDragons.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Services;

public class ItemService : IItemService
{
    private readonly ApplicationDbContext _context;

    public ItemService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Fully async, uses FirstOrDefaultAsync, throws specific exception
    public async Task<Item> GetItemAsync(int itemId)
    {
        var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);

        if (item == null)
        {
            throw new ItemNotFoundException(itemId);
        }

        return item;
    }

    // A single, powerful update method using the DTO
    public async Task<Item> UpdateItemAsync(int itemId, UpdateItemDto updateDto)
    {
        var item = await GetItemAsync(itemId); // Re-uses our Get method, which includes the null check

        // Conditionally update properties only if they were provided in the DTO
        if (updateDto.Name != null)
        {
            item.Name = updateDto.Name;
        }
        if (updateDto.Description != null)
        {
            item.Description = updateDto.Description;
        }
        if (updateDto.Type != null)
        {
            item.Type = updateDto.Type;
        }
        if (updateDto.Weight.HasValue)
        {
            item.Weight = updateDto.Weight.Value;
        }
        if (updateDto.Quantity.HasValue)
        {
            item.Quantity = updateDto.Quantity.Value;
        }
        if (updateDto.Cost.HasValue)
        {
            item.Cost = updateDto.Cost.Value;
        }
        if (updateDto.DamageDice != null)
        {
            item.DamageDice = updateDto.DamageDice;
        }
        if (updateDto.DamageType != null)
        {
            item.DamageType = updateDto.DamageType;
        }
        if (updateDto.ArmorClass.HasValue)
        {
            item.ArmorClass = updateDto.ArmorClass;
        }
        if (updateDto.AcBonus.HasValue)
        {
            item.AcBonus = updateDto.AcBonus;
        }
        if (updateDto.ArmorType != null)
        {
            item.ArmorType = updateDto.ArmorType;
        }

        await _context.SaveChangesAsync();

        return item;
    }

    // Fully async delete method
    public async Task DeleteItemAsync(int itemId)
    {
        var item = await GetItemAsync(itemId); // Re-uses our Get method for the check and fetch
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }
}