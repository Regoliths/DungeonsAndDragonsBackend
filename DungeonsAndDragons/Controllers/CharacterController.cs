using Microsoft.AspNetCore.Mvc;
using DungeonsAndDragons.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CharacterController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{characterId}")]
    public ActionResult<PlayerCharacter> GetCharacter(int characterId)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory)
            .FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        return Ok(character);
    }

    [HttpPost]
    public ActionResult<PlayerCharacter> CreateCharacter([FromBody] PlayerCharacterDto characterDto)
    {
        var character = new PlayerCharacter
        {
            Name = characterDto.Name,
            Race = characterDto.Race,
            Class = characterDto.Class, // Updated to use PlayerClass enum
            Subclass = characterDto.Subclass,
            Level = characterDto.Level,
            Strength = characterDto.Strength,
            Dexterity = characterDto.Dexterity,
            Constitution = characterDto.Constitution,
            Intelligence = characterDto.Intelligence,
            Wisdom = characterDto.Wisdom,
            Charisma = characterDto.Charisma,
            HitPoints = characterDto.HitPoints,
            Speed = characterDto.Speed,
            ArmorClass = characterDto.ArmorClass,
            Alignment = characterDto.Alignment,
        };

        _context.PlayerCharacters.Add(character);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCharacter), new { characterId = character.Id }, character);
    }

    [HttpPut("{characterId}")]
    public ActionResult UpdateCharacter(int characterId, [FromBody] PlayerCharacterDto characterDto)
    {
        var character = _context.PlayerCharacters.FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        character.Name = characterDto.Name;
        character.Race = characterDto.Race;
        character.Class = characterDto.Class; // Updated to use PlayerClass enum
        character.Subclass = characterDto.Subclass;
        character.Level = characterDto.Level;
        character.Strength = characterDto.Strength;
        character.Dexterity = characterDto.Dexterity;
        character.Constitution = characterDto.Constitution;
        character.Intelligence = characterDto.Intelligence;
        character.Wisdom = characterDto.Wisdom;
        character.Charisma = characterDto.Charisma;
        character.HitPoints = characterDto.HitPoints;
        character.Speed = characterDto.Speed;
        character.ArmorClass = characterDto.ArmorClass;
        character.Alignment = characterDto.Alignment;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{characterId}")]
    public ActionResult DeleteCharacter(int characterId)
    {
        var character = _context.PlayerCharacters.FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        _context.PlayerCharacters.Remove(character);
        _context.SaveChanges();

        return NoContent();
    }
}
