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
        

        public Monster(string name, string description, int health, int damage, int level, int experience) : base(name, health, damage, level, experience, description)
        {
            MonsterType = "Beast";
            SpecialAbilities = new List<string> { "Bett", "vänsterkrok" };
            DropItems = new List<string> { "snusdosa", "plånbok" };
            ExperiencePoints = 100;
            LootRarity = "Common";
        }
        
        /*
        public NPC(string name, string description, int health, int damage, int level) : base(name, description, health, damage, level, 0)
        {
          
        } */
    }


    public class MonsterList
    {
        // Define a property to access the list of monsters
        public List<Monster> Monsters { get; }

        public MonsterList()
        {
            Monsters = new List<Monster>
            {
                new Monster("Eld Drake", "Drake med eld", 200, 30, 10, 50)
                {
                    MonsterType = "Dragon",
                    SpecialAbilities = new List<string> { "Eldspott", "krokben" },
                    DropItems = new List<string> { "Drakfjäll", "Drakklo" },
                    ExperiencePoints = 500,
                    LootRarity = "Legendary"
                },
                new Monster("Goblin", "Korta, fula o sitter ofta på spårvagnen mot Angered", 50, 10, 3, 40)
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