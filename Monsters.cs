using System;
using System.Collections.Generic;
using Classes;
using Mainmenu;


namespace Monsters
{
    public class Monster : Classes.GameEntity
    {
        public string MonsterType { get; set; }
        public List<string> SpecialAbilities { get; set; }
        public List<string> DropItems { get; set; }
        public int ExperiencePoints { get; set; }
        public string LootRarity { get; set; }

        public Monster(string name, string description, int health, int damage, int level)
            : base(name, description, health, damage, level)
        {
            MonsterType = "Beast";
            SpecialAbilities = new List<string> { "Bett", "vänsterkrok" };
            DropItems = new List<string> { "snusdosa", "plånbok" };
            ExperiencePoints = 100;
            LootRarity = "Common";
        }
    }

    public class NPC : GameEntity
    {
        public NPC(string name, string description, int health, int damage, int level)
            : base(name, description, health, damage, level)
        {
            // NPC-specific properties and behavior can be initialized here
        }
    }

    public class MonsterList
    {
        // Define a property to access the list of monsters
        public List<Monster> Monsters { get; }

        public MonsterList()
        {
            // Initialize the list of monsters in the constructor
            Monsters = new List<Monster>
            {
                new Monster("Eld Drake", "Drake med eld", 200, 30, 10)
                {
                    MonsterType = "Dragon",
                    SpecialAbilities = new List<string> { "Eldspott", "krokben" },
                    DropItems = new List<string> { "Drakfjäll", "Drakklo" },
                    ExperiencePoints = 500,
                    LootRarity = "Legendary"
                },
                new Monster("Goblin", "Korta, fula o sitter ofta på spårvagnen mot Angered", 50, 10, 3)
                {
                    MonsterType = "Goblin",
                    SpecialAbilities = new List<string> { "Cutta dig", "Ambush" },
                    DropItems = new List<string> { "Goblin Ear", "Small Potion" },
                    ExperiencePoints = 50,
                    LootRarity = "Common"
                }
            };
        }
    }
}