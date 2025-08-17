using DungeonsAndDragons.Factory;
using DungeonsAndDragons.Models;
using Action = DungeonsAndDragons.Models.Action;

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
                            equipmentId: 1,
                            equipmentItems: new List<Item>
                            {
                                new Weapon()
                                {
                                    Id = 1, Name = "Sword", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 50
                                },
                                new Armor()
                                {
                                    Id = 2, Name = "Chainmail", Type = "Armor", Quantity = 1, Weight = 4, Cost = 100,
                                    ArmorClass = 16, AcBonus = 0, ArmorType = "Medium"
                                },
                                new Armor
                                {
                                    Id = 33, Name = "Shield", Type = "Armor", Quantity = 1, Weight = 5, Cost = 75,
                                    ArmorClass = 2, AcBonus = 2, ArmorType = "Shield"
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
                            },
                            actions: new List<Action>
                            {
                                new Action
                                {
                                    Name = "Melee Attack", Description = "Perform a melee attack with a sword.",
                                    Range = 5, AttackBonus = 5,
                                    Damage = new Damage(1, 8, "slashing")
                                },
                                new Action
                                {
                                    Name = "Dodge", Description = "Avoid incoming attacks.",
                                    Range = 0, AttackBonus = 0,
                                    Damage = new Damage(0, 0, "none")
                                },
                                new Action
                                {
                                    Name = "Dash", Description = "Move quickly to avoid danger.",
                                    Range = 0, AttackBonus = 0,
                                    Damage = new Damage(0, 0, "none")
                                }
                            }
                        ),

                        // Call the factory for Legolas
                        CharacterFactory.Create(
                            id: 2, name: "Legolas", race: Race.Elf, playerClass: PlayerClass.Ranger,
                            background: Background.Soldier, alignment: Alignment.ChaoticGood,
                            subclass: "Archer", level: 4, strength: 12, dexterity: 18, constitution: 12,
                            intelligence: 14, wisdom: 13, charisma: 10, hitPoints: 38, speed: 35,
                            equipmentId: 2,
                            equipmentItems: new List<Item>
                            {
                                new Weapon()
                                {
                                    Id = 5, Name = "Bow", Type = "Weapon", Quantity = 1, Weight = 2, Cost = 100
                                },
                                new Item
                                {
                                    Id = 6, Name = "Quiver", Type = "Ammunition", Quantity = 20, Weight = 1, Cost = 10
                                },
                                new Armor
                                {
                                    Id = 7, Name = "Leather Armor", Type = "Armor", Quantity = 1, Weight = 2,
                                    Cost = 50, ArmorClass = 11, AcBonus = 0, ArmorType = "Light"
                                }
                            },
                            inventoryId: 2,
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 77, Name = "Healing Potion", Type = "Consumable", Quantity = 2, Weight = 1,
                                    Cost = 50
                                },
                                new Armor()
                                {
                                    Id = 8, Name = "Elven Cloak", Type = "Armor", Quantity = 1, Weight = 1, Cost = 150,
                                    ArmorClass = 1, AcBonus = 1, ArmorType = "Light"
                                }
                            },
                            actions: new List<Action>
                            {
                                new Action
                                {
                                    Name = "Ranged Attack", Description = "Perform a ranged attack with a bow.",
                                    Range = 60, AttackBonus = 6,
                                    Damage = new Damage(1, 8, "piercing")
                                },
                                new Action
                                {
                                    Name = "Hide", Description = "Hide from enemies to avoid detection.",
                                    Range = 0, AttackBonus = 0,
                                    Damage = new Damage(0, 0, "none")
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
                            equipmentId: 3,
                            equipmentItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 9, Name = "Axe", Type = "Weapon", Quantity = 1, Weight = 4, Cost = 60
                                },
                                new Armor()
                                {
                                    Id = 10, Name = "Dwarven Plate", Type = "Armor", Quantity = 1, Weight = 8,
                                    Cost = 200, ArmorClass = 18, AcBonus = 0, ArmorType = "Heavy"
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
                            },
                            actions: new List<Action>
                            {
                                new Action
                                {
                                    Name = "Melee Attack", Description = "Perform a melee attack with an axe.",
                                    Range = 5, AttackBonus = 6,
                                    Damage = new Damage(1, 10, "slashing")
                                },
                                new Action
                                {
                                    Name = "Hide", Description = "Hide from enemies to avoid detection.",
                                    Range = 0, AttackBonus = 0,
                                    Damage = new Damage(0, 0, "none")
                                }
                            }
                            ),
                        CharacterFactory.Create(
                            id: 4, name: "Thorin Oakenshield", race: Race.Dwarf, playerClass: PlayerClass.Fighter,
                            background: Background.Noble, alignment: Alignment.TrueNeutral,
                            subclass: "Champion", level: 5, strength: 16, dexterity: 12, constitution: 14,
                            intelligence: 12, wisdom: 12, charisma: 14, hitPoints: 50, speed: 25,
                            equipmentId: 4,
                            equipmentItems: new List<Item>
                            {
                                new Weapon()
                                {
                                    Id = 13, Name = "Battle Axe", Type = "Weapon", Quantity = 1, Weight = 4, Cost = 70
                                },
                                new Armor()
                                {
                                    Id = 14, Name = "Chainmail", Type = "Armor", Quantity = 1, Weight = 5, Cost = 100,
                                    ArmorClass = 16, AcBonus = 0, ArmorType = "Medium"
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
                            },
                            actions: new List<Action>
                            {
                                new Action
                                {
                                    Name = "Melee Attack",Description = "Perform a melee attack with a weapon.",
                                    Range = 5, AttackBonus = 5,
                                    Damage = new Damage(1, 8, "slashing"),
                                },
                                new Action
                                {
                                    Name = "Defend", Description = "Take a defensive stance to reduce damage.",
                                    Range = 0, AttackBonus = 0,
                                    Damage = new Damage(0, 0, "none")
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
                            equipmentId: 5,
                            equipmentItems: new List<Item>
                            {
                                new Weapon()
                                {
                                    Id = 17, Name = "Staff", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 200
                                },
                                new Item
                                {
                                    Id = 18, Name = "Spellbook", Type = "Miscellaneous", Quantity = 1, Weight = 2,
                                    Cost = 300
                                },
                                new Armor()
                                {
                                    Id = 19, Name = "Robes", Type = "Armor", Quantity = 1, Weight = 1, Cost = 150,
                                    ArmorClass = 12, AcBonus = 0, ArmorType = "Light"
                                }
                            },
                            inventoryId: 5,
                            inventoryItems: new List<Item>
                            {
                                new Item
                                {
                                    Id = 190, Name = "Potion of Mana", Type = "Consumable", Quantity = 1, Weight = 1,
                                    Cost = 100
                                },
                                new Item
                                {
                                    Id = 20, Name = "Scroll of Lightning Bolt", Type = "Spell", Quantity = 1, Weight = 0,
                                    Cost = 200
                                }
                            },
                            actions: new List<Action>
                            {
                                new Action()
                                {
                                    Name = "Cast Fireball", Description = "Cast a powerful fireball spell.",
                                    Range = 150, AttackBonus = 8,
                                    Damage = new Damage(8, 6, "fire")
                                },
                                new Action()
                                {
                                    Name = "Cast Shield", Description = "Create a magical shield to protect against attacks.",
                                    Range = 0, AttackBonus = 0,
                                    Damage = new Damage(0, 0, "none")
                                }
                            }
                            ),
                        CharacterFactory.Create(
                            id: 6, name: "Sauraman the white", race: Race.Human, playerClass: PlayerClass.Wizard,
                            background: Background.Sage, alignment: Alignment.ChaoticEvil,
                            subclass: "Necromancer", level: 9, strength: 10, dexterity: 12, constitution: 14,
                            intelligence: 18, wisdom: 16, charisma: 14, hitPoints: 38, speed: 30,
                            equipmentId: 6,
                            equipmentItems: new List<Item>
                            {
                                new Weapon()
                                {
                                    Id = 21, Name = "Staff", Type = "Weapon", Quantity = 1, Weight = 3, Cost = 250
                                },
                                new Armor()
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
                            },
                            actions: new List<Action>
                            {
                                new Action()
                                {
                                    Name = "Cast Lightning Bolt", Description = "Cast a powerful lightning bolt spell.",
                                    Range = 100, AttackBonus = 7,
                                    Damage = new Damage(6, 6, "lightning")
                                },
                                new Action()
                                {
                                    Name = "Summon Undead", Description = "Summon undead minions to fight for you.",
                                    Range = 30, AttackBonus = 0,
                                    Damage = new Damage(0, 0, "none")
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
