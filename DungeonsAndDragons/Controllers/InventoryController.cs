using Microsoft.AspNetCore.Mvc;
using DungeonsAndDragons.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InventoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{characterId}")]
    public ActionResult<IEnumerable<Item>> GetInventory(int characterId)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory)
            .FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        return Ok(character.Inventory);
    }

    [HttpGet("{characterId}/{itemId}")]
    public ActionResult<Item> GetItem(int characterId, int itemId)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory)
            .FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        var item = character.Inventory.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return NotFound($"Item with ID {itemId} not found in character {characterId}'s inventory.");
        }

        return Ok(item);
    }

    [HttpPost("{characterId}")]
    public ActionResult<Item> AddItem(int characterId, [FromBody] Item item)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory)
            .FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        item.PlayerCharacter = character;
        _context.Items.Add(item);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetItem), new { characterId = characterId, itemId = item.Id }, item);
    }

    [HttpPut("{characterId}/{itemId}")]
    public ActionResult UpdateItem(int characterId, int itemId, [FromBody] Item updatedItem)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory)
            .FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        var item = character.Inventory.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return NotFound($"Item with ID {itemId} not found in character {characterId}'s inventory.");
        }

        item.Name = updatedItem.Name;
        item.Description = updatedItem.Description;
        item.Type = updatedItem.Type;
        item.Quantity = updatedItem.Quantity;
        item.Weight = updatedItem.Weight;
        item.Cost = updatedItem.Cost;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{characterId}/{itemId}")]
    public ActionResult DeleteItem(int characterId, int itemId)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory)
            .FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        var item = character.Inventory.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return NotFound($"Item with ID {itemId} not found in character {characterId}'s inventory.");
        }

        _context.Items.Remove(item);
        _context.SaveChanges();

        return NoContent();
    }
}
