using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Services;

public class CharacterService
{
    private readonly ApplicationDbContext _context;

    private Dictionary<int, Race> _raceMapping;
    private Dictionary<int, PlayerClass> _classMapping;
    private Dictionary<int, Alignment> _alignmentMapping;
    private Dictionary<int, Background> _backgroundMapping;
    public CharacterService(ApplicationDbContext context)
    {
        _context = context;
        _alignmentMapping = new Dictionary<int, Alignment>
        {
            { 1, Alignment.LawfulGood },
            { 2, Alignment.NeutralGood },
            { 3, Alignment.ChaoticGood },
            { 4, Alignment.LawfulNeutral },
            { 5, Alignment.TrueNeutral },
            { 6, Alignment.ChaoticNeutral },
            { 7, Alignment.LawfulEvil },
            { 8, Alignment.NeutralEvil },
            { 9, Alignment.ChaoticEvil }
        };
        _classMapping = new Dictionary<int, PlayerClass>
        {
            { 1, PlayerClass.Barbarian },
            { 2, PlayerClass.Bard },
            { 3, PlayerClass.Cleric },
            { 4, PlayerClass.Druid },
            { 5, PlayerClass.Fighter },
            { 6, PlayerClass.Monk },
            { 7, PlayerClass.Paladin },
            { 8, PlayerClass.Ranger },
            { 9, PlayerClass.Rogue },
            { 10, PlayerClass.Sorcerer },
            { 11, PlayerClass.Warlock },
            { 12, PlayerClass.Wizard }
        };
        _raceMapping = new Dictionary<int, Race>
        {
            { 0, Race.Human },
            { 1, Race.Elf },
            { 2, Race.Dwarf },
            { 3, Race.Halfling },
            { 4, Race.Dragonborn },
            { 5, Race.Gnome },
            { 6, Race.HalfElf },
            { 7, Race.HalfOrc },
            { 8, Race.Tiefling },
            { 9, Race.Genasi },
            { 10,Race.Goliath },
            {  11, Race.Aasimar },
            {  12, Race.Firbolg }
        };
        _backgroundMapping = new Dictionary<int, Background>
        {
            { 1, Background.Acolyte },
            { 2, Background.Charlatan },
            { 3, Background.Criminal },
            { 4, Background.Entertainer },
            { 5, Background.FolkHero },
            { 6, Background.GuildArtisan },
            { 7, Background.Hermit },
            { 8, Background.Noble },
            { 9, Background.Outlander },
            { 10, Background.Sage },
            { 11, Background.Soldier },
            { 12, Background.Urchin }
        };
    }

    public Character CreateCharacter(PlayerCharacterDto characterDto)
    {

        var character = new Character
        {
            Name = characterDto.Name,
            Race = _raceMapping.ContainsKey(characterDto.Race) ? _raceMapping[characterDto.Race] : Race.Human,
            Class = _classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : PlayerClass.Barbarian,
            Background = _backgroundMapping.ContainsKey(characterDto.Background) ? _backgroundMapping[characterDto.Background] : Background.Acolyte,
            Alignment = _alignmentMapping.ContainsKey(characterDto.Alignment) ? _alignmentMapping[characterDto.Alignment] : Alignment.TrueNeutral,
            Level = characterDto.Level,
            Strength = characterDto.Strength,
            Dexterity = characterDto.Dexterity,
            Constitution = characterDto.Constitution,
            Intelligence = characterDto.Intelligence,
            Wisdom = characterDto.Wisdom,
            Charisma = characterDto.Charisma,
            HitPoints = characterDto.HitPoints,
            HitDice = HitDieSize(_classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : PlayerClass.Barbarian),
            ArmorClass = characterDto.ArmorClass,
            Speed = characterDto.Speed,
            Initiative = 10 + characterDto.Dexterity, // Initiative is calculated based on Dexterity
            Notes = characterDto.Notes
        };

        _context.PlayerCharacters.Add(character);
        _context.SaveChanges();

        return character;
    }

    public void UpdateCharacter(PlayerCharacterDto characterDto, Character character)
    {
        
        character.Name = characterDto.Name;
        character.Race = _raceMapping.ContainsKey(characterDto.Race) ? _raceMapping[characterDto.Race] : character.Race;
        character.Class = _classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : character.Class;
        character.Background = _backgroundMapping.ContainsKey(characterDto.Background) ? _backgroundMapping[characterDto.Background] : character.Background;
        character.Level = characterDto.Level;
        character.Strength = characterDto.Strength;
        character.Dexterity = characterDto.Dexterity;
        character.Constitution = characterDto.Constitution;
        character.Intelligence = characterDto.Intelligence;
        character.Wisdom = characterDto.Wisdom;
        character.Charisma = characterDto.Charisma;
        character.HitPoints = characterDto.HitPoints;
        character.HitDice = HitDieSize(_classMapping.ContainsKey(characterDto.Class) ? _classMapping[characterDto.Class] : character.Class);
        character.Speed = characterDto.Speed;
        character.Initiative = 10 + characterDto.Dexterity; // Initiative is calculated based on Dexterity
        character.ArmorClass = characterDto.ArmorClass;
        character.Alignment = _alignmentMapping.ContainsKey(characterDto.Alignment) ? _alignmentMapping[characterDto.Alignment] :character.Alignment;

        _context.SaveChanges();

    } 
    
    public Character? GetCharacter(int characterId)
    {
        var character = _context.PlayerCharacters
            .Include(c => c.Inventory).ThenInclude(i => i.Items)
            .Include(c => c.Equipment).ThenInclude(i => i.Items)
            .FirstOrDefault(c => c.Id == characterId);

        return character;
    }
    
    public IEnumerable<Character> GetAllCharacters()
    {
        return _context.PlayerCharacters.ToList();
    }
    
    private int HitDieSize(PlayerClass playerClass)
    {
        return playerClass switch
        {
            PlayerClass.Barbarian => 12,
            PlayerClass.Bard => 8,
            PlayerClass.Cleric => 8,
            PlayerClass.Druid => 8,
            PlayerClass.Fighter => 10,
            PlayerClass.Monk => 8,
            PlayerClass.Paladin => 10,
            PlayerClass.Ranger => 10,
            PlayerClass.Rogue => 8,
            PlayerClass.Sorcerer => 6,
            PlayerClass.Warlock => 8,
            PlayerClass.Wizard => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(playerClass), "Unknown player class")
        };
    }
    
}
