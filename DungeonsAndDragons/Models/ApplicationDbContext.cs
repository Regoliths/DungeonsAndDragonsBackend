using Microsoft.EntityFrameworkCore;
    
namespace DungeonsAndDragons.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<PlayerAccount> PlayerAccounts { get; set; }
    public DbSet<Character> PlayerCharacters { get; set; }
    public DbSet<Item> Items { get; set; }
    
}

