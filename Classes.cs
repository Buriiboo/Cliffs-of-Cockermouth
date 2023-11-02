using System.Runtime;
using System.Runtime.CompilerServices;
using Monsters;
using Mainmenu;

namespace Classes;

public class GameEntity // använd denna till monster och npc etc som base
{
    public string Name {get; set;}
    public double Health {get; set;}
    public double Damage {get; set;}
    public int Level {get; set;}
    public int Experience {get; set;}
    public string Description {get; set;}
    public GameEntity(string name, double health, double damage, int level, int experience, string description)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Level = level;
        Experience = experience;
        Description = description;
    }
     public (double, double, int) GetStats()
    {
        // Return the health, damage, and level as a tuple
        return (Health, Damage, Level);
    }
}

public class Player : GameEntity
{   
    List<Item> itemInv;
    public Player(string name, double health, double damage, int level, int experience, string description) : base( name, health, damage, level, experience, description)
    {
        itemInv = new List<Item>();
    }
    public List<Item> Inventory()
    {
        return itemInv;
    }
    public void ShowInventory()
    {
        for(int i = 0; i < itemInv.Count; i++)
        {
            Console.WriteLine($"{i+1}: {itemInv[i]}");
        }
    }
    public void AddInventory(Item item)
    {
        itemInv.Add(item);
    }
    public void RemoveInventory(Item item)
    {
        itemInv.Remove(item);
    }
    
    public override string ToString()
    {
        return $"Name: {Name}\n Description: {Description}\n Health: {Health}\n Damage: {Damage}\n Level: {Level}";
    }
}

public class AvalibleItems
{
    public List<Item> Items {get; set;}
    public List<Ability> Abilities {get; set;}

    public AvalibleItems()
    {
        Items = new List<Item>();
        Abilities = new List<Ability>();
    }
    public void PlayerInventory()
    {
        
    }
}

public class Item
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Weight {get; set;}
    public double Healing {get; set;}
    public double Damage {get; set;}
    public int Amount {get; set;}
    
    public Item(int weight, double damage, double healing, string name, string description, int amount)
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
    public int Damage {get; set;}
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
public class Action
{
    public (double Health, double Damage) Attack(Monster randomMonster, Player playerCharacter, double attackMultiplier)
    {
        playerCharacter.ShowInventory();
        Console.WriteLine($"Vad vill du använda för att attackera med?");
        int choice = int.Parse(Console.ReadLine()) - 1; // -1 eftersom listor är nollbaserade

        if (choice >= 0 && choice < playerCharacter.Inventory().Count)
        {
            Item selectedItem = playerCharacter.Inventory()[choice];
            Console.WriteLine($"{playerCharacter.Name} använder {selectedItem.Name} för att attackera! De gör {selectedItem.Damage}!");
            randomMonster.Health -= selectedItem.Damage;
            selectedItem.Amount -= 1;
            if(selectedItem.Amount == 0)
                playerCharacter.RemoveInventory(selectedItem);

        }
        playerCharacter.Damage = attackMultiplier;
        return (randomMonster.Health, playerCharacter.Damage);
    }
    public (double Health, double Damage) Defence(Monster randomMonster, Player playerCharacter)
    {
        Random random = new Random();
        int index = random.Next(0, 2);
        if(index == 1)
        {
            playerCharacter.Health -= randomMonster.Damage;
        }
        else if(index == 0)
        {
            playerCharacter.Health -= randomMonster.Damage*0.5;
            playerCharacter.Damage *= 2;
        }

        return (playerCharacter.Health, playerCharacter.Damage);
    }
}

class Room
{
    public string Name {get; set;}
    public string Description {get; set;}
    public string Exit {get; set;}
    public List<Room> rooms;
    public Room(string name, string description, string exit)
    {
        Name = name;
        Description = description;
        Exit = exit;
        rooms = new List<Room>();
    }
    
    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }
}