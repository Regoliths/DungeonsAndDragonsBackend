namespace DungeonsAndDragons.Services;

public class CharacterNotFoundException : Exception
{
    public CharacterNotFoundException(int characterId) : base($"Character with ID {characterId} not found.") { }

}