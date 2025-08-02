using Microsoft.AspNetCore.Mvc;
using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using DungeonsAndDragons.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DungeonsAndDragons.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CharacterController> _logger;
    private readonly CharacterService _characterService;

    public CharacterController(ApplicationDbContext context)
    {
        _context = context;
        _logger = context.GetService<ILogger<CharacterController>>();
        _characterService = new CharacterService(_context); 

    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Character>> GetAllCharacters()
    {
        var characters = _characterService.GetAllCharacters();

        if (characters == null || !characters.Any())
        {
            return NotFound("No characters found.");
        }

        return Ok(characters);
    }

    [HttpGet("{characterId}")]
    public ActionResult<PlayerCharacterDto> GetCharacter(int characterId)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }
        
        // Convert to DTO if necessary
        var characterDto = PlayerCharacterDto.FromCharacter(character);

        return Ok(character);
    }

    [HttpPost]
    public ActionResult<Character> CreateCharacter([FromBody] PlayerCharacterDto characterDto)
    {
        var character = _characterService.CreateCharacter(characterDto); 

        return CreatedAtAction(nameof(GetCharacter), new { characterId = character.Id }, character);
    }

    [HttpPut("{characterId}")]
    public ActionResult UpdateCharacter(int characterId, [FromBody] PlayerCharacterDto characterDto)
    {
        var character = _characterService.GetCharacter(characterId);

        if (character == null)
        {
            return NotFound($"Character with ID {characterId} not found.");
        }

        _characterService.UpdateCharacter(characterDto, character);
        
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
