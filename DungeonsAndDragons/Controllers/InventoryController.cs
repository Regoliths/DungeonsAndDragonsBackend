using Microsoft.AspNetCore.Mvc;
using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using DungeonsAndDragons.Services;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private InventoryService _inventoryService;

    public InventoryController(ApplicationDbContext context)
    {
        _context = context;
        _inventoryService = new InventoryService(_context);
    }

    [HttpGet("{characterId}")]
    public ActionResult<IEnumerable<Inventory>> GetInventory(int characterId)
    {
        var inventory = _inventoryService.GetInventoryAsync(characterId);
        return Ok(inventory.Result);
    }

    [HttpGet("{characterId}/{itemId}")]
    public ActionResult<Item> GetItemFromInventory(int characterId, int itemId)
    {
        var item = _inventoryService.GetItemInInventoryAsync(characterId, itemId);
        if (item == null)
        {
            return NotFound($"Item with ID {itemId} not found in character {characterId}'s inventory.");
        }
        return Ok(item.Result);
    }
    
    [HttpGet("{characterId}/items")]
    public ActionResult<IEnumerable<Item>> GetItemsInInventory(int characterId)
    {
        var items = _inventoryService.GetItemsInInventoryAsync(characterId);
        if (items == null || !items.Result.Any())
        {
            return NotFound($"No items found in character {characterId}'s inventory.");
        }
        return Ok(items.Result);
    }

    [HttpPost("{characterId}")]
    public ActionResult<Item> AddItemToInventory(int characterId, [FromBody] Item item)
    {
        if (item == null)
        {
            return BadRequest("Item cannot be null.");
        }

        var addedItem = _inventoryService.AddItemToInventoryAsync(characterId, item);
        if (addedItem == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        return CreatedAtAction(nameof(GetItemFromInventory), new { characterId = characterId, itemId = addedItem.Result.Id }, addedItem.Result);
    }

    [HttpPut("{characterId}/{itemId}")]
    public ActionResult UpdateItemInInventory(int characterId, int itemId, [FromBody] UpdateItemDto updatedItem)
    {
        if (updatedItem == null)
        {
            return BadRequest("Updated item cannot be null.");
        }

        var existingItem = _inventoryService.GetItemInInventoryAsync(characterId, itemId);
        if (existingItem == null)
        {
            return NotFound($"Item with ID {itemId} not found in character {characterId}'s inventory.");
        }

        _inventoryService.UpdateItemInInventoryAsync(characterId, itemId, updatedItem);
        
        return NoContent();
    }

    [HttpDelete("{characterId}/{itemId}")]
    public ActionResult DeleteItemFromEquipment(int characterId, int itemId)
    {
       _inventoryService.RemoveItemFromInventoryAsync(characterId, itemId);
       
        return NoContent();
    }
}
