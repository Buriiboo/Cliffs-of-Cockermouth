using System.Runtime.CompilerServices;

class GameEntity
{
    public string Name {get; set;}
    public string Description {get; set;}
    public GameEntity(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

class CreatePlayer : GameEntity
{
    public int Health {get; set;}
    public int Level {get; set;}
    public int Damage {get; set;}
    public List<Inventory> playerInventory {get; set;}
    public CreatePlayer(int health, int level, int damage, string name, string description) : base(name, description)
    {
        Health = health;
        Level = level;
        Damage = damage;
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
    
    public void AddInventory(List<Item> items, List<Ability> ability)
    {
        
    }
}
class Item : GameEntity
{
    public int Weight {get; set;}
    public int Damage {get; set;}
    public int Healing {get; set;}
    public List<Item> itemList;
    public Item(int weight, int damage, int healing, string name, string description) : base(name, description)
    {
        Weight = weight;
        Damage = damage;
        Healing = healing;
        itemList = new List<Item>();
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
class Ability : GameEntity
{
    public int Damage {get; set;}
    public int Amount {get; set;}
    public List<Ability> abilityList;
    
    public Ability(int damage, int amount, string name, string description) : base(name, description)
    {
        Damage = damage;
        Amount = amount;
        abilityList = new List<Ability>();
    }
    public void AddAbility(Ability ability)
    {
        abilityList.Add(ability);
    }
    

}