using DungeonsAndDragons.Models;

namespace DungeonsAndDragons.Seeding;

public static class DataSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.PlayerAccounts.Any())
        {
            var players = new List<PlayerAccount>
            {
                new PlayerAccount
                {
                    Id = 1,
                    Username = "Player1",
                    Email = "player1@example.com",
                    PasswordHash = "hashedpassword1",
                    Characters = new List<Character>
                    {
                        new Character
                        {
                            Id = 1,
                            Name = "Aragorn",
                            Race = Race.Human, // Fixed to use Race enum
                            Class = PlayerClass.Ranger,
                            Background = Background.Noble,
                            Subclass = "Hunter",
                            Level = 5,
                            Strength = 16,
                            Dexterity = 14,
                            Constitution = 14,
                            Intelligence = 12,
                            Wisdom = 15,
                            Charisma = 13,
                            HitPoints = 45,
                            Speed = 30,
                            ArmorClass = 16,
                            Alignment = Alignment.LawfulGood,
                            Inventory = new List<Item>
                            {
                                new Item { Id = 1, Name = "Sword", Description = "A sharp blade", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 50 },
                                new Item { Id = 2, Name = "Shield", Description = "A sturdy shield", Type = "Armor", Quantity = 1, Weight = 5, Cost = 75 }
                            }
                        },
                        new Character
                        {
                            Id = 2,
                            Name = "Legolas",
                            Race = Race.Elf, // Fixed to use Race enum
                            Class = PlayerClass.Ranger,
                            Background = Background.Soldier,
                            Subclass = "Archer",
                            Level = 4,
                            Strength = 12,
                            Dexterity = 18,
                            Constitution = 12,
                            Intelligence = 14,
                            Wisdom = 13,
                            Charisma = 10,
                            HitPoints = 38,
                            Speed = 35,
                            ArmorClass = 15,
                            Alignment = Alignment.ChaoticGood,
                            Inventory = new List<Item>
                            {
                                new Item { Id = 3, Name = "Bow", Description = "A longbow", Type = "Weapon", Quantity = 1, Weight = 2, Cost = 100 },
                                new Item { Id = 4, Name = "Quiver", Description = "A quiver of arrows", Type = "Ammunition", Quantity = 20, Weight = 1, Cost = 10 }
                            }
                        }
                    }
                },
                new PlayerAccount
                {
                    Id = 2,
                    Username = "Player2",
                    Email = "player2@example.com",
                    PasswordHash = "hashedpassword2",
                    Characters = new List<Character>
                    {
                        new Character
                        {
                            Id = 3,
                            Name = "Gimli",
                            Race = Race.Dwarf, // Fixed to use Race enum
                            Class = PlayerClass.Fighter,
                            Background = Background.Soldier,
                            Subclass = "Champion",
                            Level = 6,
                            Strength = 18,
                            Dexterity = 10,
                            Constitution = 16,
                            Intelligence = 10,
                            Wisdom = 12,
                            Charisma = 10,
                            HitPoints = 60,
                            Speed = 25,
                            ArmorClass = 18,
                            Alignment = Alignment.LawfulNeutral,
                            Inventory = new List<Item>
                            {
                                new Item { Id = 5, Name = "Axe", Description = "A battle axe", Type = "Weapon", Quantity = 1, Weight = 4, Cost = 60 },
                                new Item { Id = 6, Name = "Helmet", Description = "A sturdy helmet", Type = "Armor", Quantity = 1, Weight = 3, Cost = 40 }
                            }
                        },
                        new Character
                        {
                            Id = 4,
                            Name = "Thorin",
                            Race = Race.Dwarf, // Fixed to use Race enum
                            Class = PlayerClass.Fighter,
                            Background = Background.Noble,
                            Subclass = "Champion",
                            Level = 5,
                            Strength = 16,
                            Dexterity = 12,
                            Constitution = 14,
                            Intelligence = 12,
                            Wisdom = 12,
                            Charisma = 14,
                            HitPoints = 50,
                            Speed = 25,
                            ArmorClass = 17,
                            Alignment = Alignment.TrueNeutral,
                            Inventory = new List<Item>
                            {
                                new Item { Id = 7, Name = "Hammer", Description = "A war hammer", Type = "Weapon", Quantity = 1, Weight = 5, Cost = 70 },
                                new Item { Id = 8, Name = "Chainmail", Description = "A chainmail armor", Type = "Armor", Quantity = 1, Weight = 10, Cost = 150 }
                            }
                        }
                    }
                },
                new PlayerAccount
                {
                    Id = 3,
                    Username = "Player3",
                    Email = "player3@example.com",
                    PasswordHash = "hashedpassword3",
                    Characters = new List<Character>
                    {
                        new Character
                        {
                            Id = 5,
                            Name = "Gandalf",
                            Race = Race.Human, // Fixed to use Race enum
                            Class = PlayerClass.Wizard,
                            Background = Background.Sage,
                            Subclass = "Evoker",
                            Level = 10,
                            Strength = 10,
                            Dexterity = 12,
                            Constitution = 14,
                            Intelligence = 20,
                            Wisdom = 18,
                            Charisma = 16,
                            HitPoints = 40,
                            Speed = 30,
                            ArmorClass = 14,
                            Alignment = Alignment.LawfulGood,
                            Inventory = new List<Item>
                            {
                                new Item { Id = 9, Name = "Staff", Description = "A magical staff", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 200 },
                                new Item { Id = 10, Name = "Spellbook", Description = "A book of spells", Type = "Miscellaneous", Quantity = 1, Weight = 2, Cost = 300 }
                            }
                        },
                        new Character
                        {
                            Id = 6,
                            Name = "Saruman",
                            Race = Race.Human, // Fixed to use Race enum
                            Class = PlayerClass.Wizard,
                            Background = Background.Sage,
                            Subclass = "Necromancer",
                            Level = 9,
                            Strength = 10,
                            Dexterity = 12,
                            Constitution = 14,
                            Intelligence = 18,
                            Wisdom = 16,
                            Charisma = 14,
                            HitPoints = 38,
                            Speed = 30,
                            ArmorClass = 13,
                            Alignment = Alignment.ChaoticEvil,
                            Inventory = new List<Item>
                            {
                                new Item { Id = 11, Name = "Staff", Description = "A dark magical staff", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 250 },
                                new Item { Id = 12, Name = "Robe", Description = "A dark robe", Type = "Armor", Quantity = 1, Weight = 1, Cost = 100 }
                            }
                        }
                    }
                }
            };

            context.PlayerAccounts.AddRange(players);
            context.SaveChanges();
        }
    }
}
