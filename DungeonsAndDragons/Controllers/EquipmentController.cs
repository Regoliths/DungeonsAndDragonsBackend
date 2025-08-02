using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using DungeonsAndDragons.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private EquipmentService _equipementService;

    public EquipmentController(ApplicationDbContext context)
    {
        _context = context;
        _equipementService = new EquipmentService(_context);
    }

    [HttpGet("{characterId}")]
    public ActionResult<EquipmentDto> GetEquipement(int characterId)
    {
        var equipment = _equipementService.GetEquipmentAsync(characterId);
        if (equipment == null)
        {
            return NotFound($"Equipment for character with ID {characterId} not found.");
        }
        return Ok(new EquipmentDto()
        {
            CharacterId = equipment.Result.CharacterId,
            Items = equipment.Result.Items.Select(i => new ItemDto { Id = i.Id, Name = i.Name, Weight = i.Weight }).ToList(),
            TotalWeight = equipment.Result.TotalWeight
        });
    }

    [HttpGet("{characterId}/{itemId}")]
    public ActionResult<Item> GetItemFromEquipment(int characterId, int itemId)
    {
        var item = _equipementService.GetItemInEquipmentAsync(characterId, itemId);
        if (item == null)
        {
            return NotFound($"Item with ID {itemId} not found in character {characterId}'s equipment.");
        }
        return Ok(item.Result);
    }

    [HttpPost("{characterId}")]
    public ActionResult<Item> AddItemToEquipment(int characterId, [FromBody] Item item)
    {
        if (item == null)
        {
            return BadRequest("Item cannot be null.");
        }

        var addedItem = _equipementService.AddItemToEquipmentAsync(characterId, item);
        if (addedItem == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        return CreatedAtAction(nameof(GetItemFromEquipment), new { characterId = characterId, itemId = addedItem.Result.Id }, addedItem.Result);
    }

    [HttpPut("{characterId}/{itemId}")]
    public ActionResult UpdateItemInEquipment(int characterId, int itemId, [FromBody] UpdateItemDto updatedItem)
    {
        if (updatedItem == null)
        {
            return BadRequest("Updated item cannot be null.");
        }

        var existingItem = _equipementService.GetItemInEquipmentAsync(characterId, itemId);
        if (existingItem == null)
        {
            return NotFound($"Item with ID {itemId} not found in character {characterId}'s inventory.");
        }

        _equipementService.UpdateItemInEquipmentAsync(characterId, itemId, updatedItem);
        
        return NoContent();
    }

    [HttpDelete("{characterId}/{itemId}")]
    public ActionResult DeleteItemFromInventory(int characterId, int itemId)
    {
       _equipementService.RemoveItemFromEquipmentAsync(characterId, itemId);
       
        return NoContent();
    }
}