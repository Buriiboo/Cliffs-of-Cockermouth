using System.Runtime;
using System.Runtime.CompilerServices;
using Monsters;
using Mainmenu;

namespace Classes;

public class GameEntity // använd denna till monster och npc etc som base
{
    public string Name {get; set;}
    public int Health {get; set;}
    public int Damage {get; set;}
    public int Level {get; set;}
    public int Experience {get; set;}
    public string Description {get; set;}
    public GameEntity(string name, string description, int health, int damage, int level, int experience)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Level = level;
        Experience = experience;
        Description = description;
    }
     public (int, int, int) GetStats()
    {
        // Return the health, damage, and level as a tuple
        return (Health, Damage, Level);
    }
}

public class Player : GameEntity
{   
    public Player(int health, int level, int experience, int damage, string name, string description) : base(name, description, health, level, damage, experience)
    {

    }
}

public class AvalibleItems
{
    public List<Item> Items { get; set; }
    public List<Ability> Abilities { get; set; }

    public AvalibleItems()
    {
        Items = new List<Item>();
        Abilities = new List<Ability>();
    }
}

public class Item

{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Weight {get; set;}
    public int Healing {get; set;}
    public float Damage {get; set;}
    public int Amount {get; set;}
    
    public Item(int weight, float damage, int healing, string name, string description, int amount)
    {
        Weight = weight;
        Healing = healing;
        Name = name;
        Description = description;
        Damage = damage;
        Amount = amount;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}, Weight: {Weight}, Healing: {Healing}, Damage: {Damage}, Amount: {Amount}";
    }
    
}

public class Ability
{
    public string Name {get; set;}
    public string Description {get; set;}
    public float Damage {get; set;}
    public int Amount {get; set;}
    
    
    public Ability(int damage, int amount, string name, string description)
    {
        Name = name;
        Description = description;
        Damage = damage;
        Amount = amount;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}, Damage: {Damage}, Amount: {Amount}";
    }
}

class Room
{
    public string Name {get; set;}
    public string Description {get; set;}
    public List<string> exits;
    public Room(string name, string description)
    {
        Name = name;
        Description = description;
        exits = new List<string>();
    }
}