using System.Runtime;
using System.Runtime.CompilerServices;

class GameEntity // använd denna till monster och npc etc som base
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Health {get; set;}
    public int Damage {get; set;}
    public int Level {get; set;}
    public GameEntity(string name, string description, int health, int damage, int level)
    {
        Name = name;
        Description = description;
        Health = health;
        Damage = damage;
        Level = level;
    }
}

class Player : GameEntity
{
    public List<Inventory> playerInventory {get; set;}
    public Player(int health, int level, int damage, string name, string description) : base(name, description, health, level, damage)
    {
        playerInventory = new List<Inventory>();
    }
}
class Inventory
{
    public List<Inventory> inventory;
    public Inventory()
    {   
        inventory = new List<Inventory>();
        //Fler saker som ska hamna i inventory
    }
    
    public void AddPInventory(List<Item> items, List<Ability> ability)
    {
        
    }
}
class Item : Ability
{
    public int Weight {get; set;}
    public int Healing {get; set;}
    public List<Item> itemList;
    public Item(int weight, int damage, int healing, string name, string description, int amount) : base(damage, amount, name, description)
    {
        Weight = weight;
        Healing = healing;
        itemList = new List<Item>();
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
class Ability
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Damage {get; set;}
    public int Amount {get; set;}
    public List<Ability> abilityList;
    
    public Ability(int damage, int amount, string name, string description)
    {
        Name = name;
        Description = description;
        Damage = damage;
        Amount = amount;
        abilityList = new List<Ability>();
    }
    public void AddAbility(Ability ability)
    {
        abilityList.Add(ability);
    }
}