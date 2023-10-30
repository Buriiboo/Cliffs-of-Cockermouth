using Classes;

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
