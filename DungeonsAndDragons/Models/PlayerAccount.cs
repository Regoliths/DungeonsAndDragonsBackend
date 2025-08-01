namespace DungeonsAndDragons.Models;

public class PlayerAccount
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public ICollection<PlayerCharacter> Characters { get; set; } = new List<PlayerCharacter>();
}
