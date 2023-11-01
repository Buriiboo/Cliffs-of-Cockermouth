using Classes;
using Monsters;

class PickItem
{      
    
    Objects o = new Objects();
    
    public void PickItems(Player player)
    {   
        Console.WriteLine("Välj ett föremål. ");
        AvalibleItems items = o.GetAvalibleItems();
        o.ShowaItems();
        int choice = int.Parse(Console.ReadLine());
        
        if(choice == 1)
        {
            Item selectedItem = items.Items[choice-1];
            player.AddInventory(selectedItem);
        }
        else if(choice == 2)
        {
            Item selectedItem = items.Items[choice-1];
            player.AddInventory(selectedItem);
        }
    }
}
class Action
{
    public int Attack(Monster randomMonster, Player playerCharacter)
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
        
        return randomMonster.Health;
    }
}
