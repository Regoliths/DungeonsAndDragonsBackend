using Microsoft.AspNetCore.Mvc;
using DungeonsAndDragons.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PlayerController(ApplicationDbContext context)
    {
        _context = context;
        
    }

    [HttpGet("{id}")]
    public ActionResult<PlayerAccount> GetPlayerAccount(int id)
    {
        var player = _context.PlayerAccounts
            .Include(p => p.Characters)
            .FirstOrDefault(p => p.Id == id);

        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }
}
