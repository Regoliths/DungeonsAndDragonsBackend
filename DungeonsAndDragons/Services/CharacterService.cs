using DungeonsAndDragons.Models;
using DungeonsAndDragons.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Services;

public class CharacterService
{
    private readonly ApplicationDbContext _context;

    private Dictionary<string, Race> _raceMapping;
    private Dictionary<string, PlayerClass> _classMapping;
    private Dictionary<string, Alignment> _alignmentMapping;
    private Dictionary<string, Background> _backgroundMapping;
    public CharacterService(ApplicationDbContext context)
    {
        _context = context;
        _alignmentMapping = new Dictionary<string, Alignment>
        {
            { "Lawful Good", Alignment.LawfulGood },
            { "Neutral Good", Alignment.NeutralGood },
            { "Chaotic Good", Alignment.ChaoticGood },
            { "Lawful Neutral", Alignment.LawfulNeutral },
            { "True Neutral", Alignment.TrueNeutral },
            { "Chaotic Neutral", Alignment.ChaoticNeutral },
            { "Lawful Evil", Alignment.LawfulEvil },
            { "Neutral Evil", Alignment.NeutralEvil },
            { "Chaotic Evil", Alignment.ChaoticEvil }
        };
        _classMapping = new Dictionary<string, PlayerClass>
        {
            { "Barbarian", PlayerClass.Barbarian },
            { "Bard", PlayerClass.Bard },
            { "Cleric", PlayerClass.Cleric },
            { "Druid", PlayerClass.Druid },
            { "Fighter", PlayerClass.Fighter },
            { "Monk", PlayerClass.Monk },
            { "Paladin", PlayerClass.Paladin },
            { "Ranger", PlayerClass.Ranger },
            { "Rogue", PlayerClass.Rogue },
            { "Sorcerer", PlayerClass.Sorcerer },
            { "Warlock", PlayerClass.Warlock },
            { "Wizard", PlayerClass.Wizard }
        };
        _raceMapping = new Dictionary<string, Race>
        {
            { "Human", Race.Human },
            { "Elf", Race.Elf },
            { "Dwarf", Race.Dwarf },
            { "Halfling", Race.Halfling },
            { "Dragonborn", Race.Dragonborn },
            { "Gnome", Race.Gnome },
            { "Half-Elf", Race.HalfElf },
            { "Half-Orc", Race.HalfOrc },
            { "Tiefling", Race.Tiefling },
            { "Genasi", Race.Genasi },
            { "Goliath", Race.Goliath },
            { "Aasimar", Race.Aasimar },
            { "Firbolg", Race.Firbolg }
        };
        _backgroundMapping = new Dictionary<string, Background>
        {
            { "Acolyte", Background.Acolyte },
            { "Charlatan", Background.Charlatan },
            { "Criminal", Background.Criminal },
            { "Entertainer", Background.Entertainer },
            { "Folk Hero", Background.FolkHero },
            { "Guild Artisan", Background.GuildArtisan },
            { "Hermit", Background.Hermit },
            { "Noble", Background.Noble },
            { "Outlander", Background.Outlander },
            { "Sage", Background.Sage },
            { "Soldier", Background.Soldier },
            { "Urchin", Background.Urchin }
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
            .Include(c => c.Inventory)
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
