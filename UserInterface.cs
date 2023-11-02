using Classes;
using Monsters;

class PickItem
{      
    Objects o = new Objects();
    public void PickItems(Player playerCharacter)
    {   
        Console.WriteLine("Välj ett föremål. ");
        AvalibleItems items = o.GetAvalibleItems();
        o.ShowaItems();
        int choice = int.Parse(Console.ReadLine());
        
        if(choice == 1)
        {
            Item selectedItem = items.Items[choice-1];
            playerCharacter.AddInventory(selectedItem);
        }
        else if(choice == 2)
        {
            Item selectedItem = items.Items[choice-1];
            playerCharacter.AddInventory(selectedItem);
        }
    }
}
