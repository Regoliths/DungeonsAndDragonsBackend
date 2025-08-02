using DungeonsAndDragons.Factory;
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
                        // Call the factory for Aragorn
                        CharacterFactory.Create(
                            id: 1, name: "Aragorn", race: Race.Human, playerClass: PlayerClass.Ranger,
                            background: Background.Noble, alignment: Alignment.LawfulGood,
                            subclass: "Hunter", level: 5, strength: 16, dexterity: 14, constitution: 14,
                            intelligence: 12, wisdom: 15, charisma: 13, hitPoints: 45, speed: 30,
                            armorClass: 16, equipmentId: 1,
                            equipmentItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 1, Name = "Sword", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 50
                                },
                                new Item
                                {
                                    Id = 2, Name = "Shield", Type = "Armor", Quantity = 1, Weight = 5, Cost = 75
                                }
                            },
                            inventoryId: 1, 
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 3, Name = "Healing Potion", Type = "Consumable", Quantity = 1, Weight = 1,
                                    Cost = 50
                                },
                                new Item
                                {
                                    Id = 4, Name = "Map of Middle-Earth", Type = "Miscellaneous", Quantity = 1,
                                    Weight = 0, Cost = 20
                                }
                            }
                        ),

                        // Call the factory for Legolas
                        CharacterFactory.Create(
                            id: 2, name: "Legolas", race: Race.Elf, playerClass: PlayerClass.Ranger,
                            background: Background.Soldier, alignment: Alignment.ChaoticGood,
                            subclass: "Archer", level: 4, strength: 12, dexterity: 18, constitution: 12,
                            intelligence: 14, wisdom: 13, charisma: 10, hitPoints: 38, speed: 35,
                            armorClass: 15, equipmentId: 2,
                            equipmentItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 5, Name = "Bow", Type = "Weapon", Quantity = 1, Weight = 2, Cost = 100
                                },
                                new Item
                                {
                                    Id = 6, Name = "Quiver", Type = "Ammunition", Quantity = 20, Weight = 1, Cost = 10
                                }
                            },
                            inventoryId: 2,
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 7, Name = "Healing Potion", Type = "Consumable", Quantity = 2, Weight = 1,
                                    Cost = 50
                                },
                                new Item
                                {
                                    Id = 8, Name = "Elven Cloak", Type = "Armor", Quantity = 1, Weight = 1, Cost = 150
                                }
                            }
                            )
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
                        CharacterFactory.Create(
                            id: 3, name: "Gimli", race: Race.Dwarf, playerClass: PlayerClass.Fighter,
                            background: Background.Soldier, alignment: Alignment.LawfulNeutral,
                            subclass: "Champion", level: 6, strength: 18, dexterity: 10, constitution: 16,
                            intelligence: 10, wisdom: 12, charisma: 10, hitPoints: 60, speed: 25,
                            armorClass: 18, equipmentId: 3,
                            equipmentItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 9, Name = "Axe", Type = "Weapon", Quantity = 1, Weight = 4, Cost = 60
                                },
                                new Item
                                {
                                    Id = 10, Name = "Helmet", Type = "Armor", Quantity = 1, Weight = 3, Cost = 40
                                }
                            },
                            inventoryId: 3,
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 11, Name = "Healing Potion", Type = "Consumable", Quantity = 3, Weight = 1,
                                    Cost = 50
                                },
                                new Item
                                {
                                    Id = 12, Name = "Map of Moria", Type = "Miscellaneous", Quantity = 1, Weight = 0,
                                    Cost = 30
                                }
                            }
                            ),
                        CharacterFactory.Create(
                            id: 4, name: "Thorin Oakenshield", race: Race.Dwarf, playerClass: PlayerClass.Fighter,
                            background: Background.Noble, alignment: Alignment.TrueNeutral,
                            subclass: "Champion", level: 5, strength: 16, dexterity: 12, constitution: 14,
                            intelligence: 12, wisdom: 12, charisma: 14, hitPoints: 50, speed: 25,
                            armorClass: 18, equipmentId: 4,
                            equipmentItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 13, Name = "Battle Axe", Type = "Weapon", Quantity = 1, Weight = 4, Cost = 70
                                },
                                new Item
                                {
                                    Id = 14, Name = "Chainmail", Type = "Armor", Quantity = 1, Weight = 5, Cost = 100
                                }
                            },
                            inventoryId: 4,
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 15, Name = "Healing Potion", Type = "Consumable", Quantity = 2, Weight = 1,
                                    Cost = 50
                                },
                                new Item
                                {
                                    Id = 16, Name = "Map of Erebor", Type = "Miscellaneous", Quantity = 1, Weight = 0,
                                    Cost = 40
                                }
                            }
                            )
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
                        CharacterFactory.Create(
                            id: 5, name: "Gandalf the grey", race: Race.Human, playerClass: PlayerClass.Wizard,
                            background: Background.Sage, alignment: Alignment.LawfulGood,
                            subclass: "Evoker", level: 10, strength: 10, dexterity: 12, constitution: 14,
                            intelligence: 20, wisdom: 18, charisma: 16, hitPoints: 40, speed: 30,
                            armorClass: 14, equipmentId: 5,
                            equipmentItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 17, Name = "Staff", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 200
                                },
                                new Item
                                {
                                    Id = 18, Name = "Spellbook", Type = "Miscellaneous", Quantity = 1, Weight = 2,
                                    Cost = 300
                                }
                            },
                            inventoryId: 5,
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 19, Name = "Potion of Mana", Type = "Consumable", Quantity = 1, Weight = 1,
                                    Cost = 100
                                },
                                new Item
                                {
                                    Id = 20, Name = "Scroll of Lightning Bolt", Type = "Spell", Quantity = 1, Weight = 0,
                                    Cost = 200
                                }
                            }
                            ),
                        CharacterFactory.Create(
                            id: 6, name: "Sauraman the white", race: Race.Human, playerClass: PlayerClass.Wizard,
                            background: Background.Sage, alignment: Alignment.ChaoticEvil,
                            subclass: "Necromancer", level: 9, strength: 10, dexterity: 12, constitution: 14,
                            intelligence: 18, wisdom: 16, charisma: 14, hitPoints: 38, speed: 30,
                            armorClass: 13, equipmentId: 6,
                            equipmentItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 21, Name = "Staff", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 250
                                },
                                new Item
                                {
                                    Id = 22, Name = "Robe", Type = "Armor", Quantity = 1, Weight = 1, Cost = 100
                                }
                            },
                            inventoryId: 6,
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 23, Name = "Potion of Healing", Type = "Consumable", Quantity = 2, Weight = 1,
                                    Cost = 50
                                },
                                new Item
                                {
                                    Id = 24, Name = "Scroll of Fireball", Type = "Spell", Quantity = 1, Weight = 0,
                                    Cost = 150
                                }
                            }
                            )
                    }
                }
            };

            context.PlayerAccounts.AddRange(players);
            context.SaveChanges();
        }
    }
}
