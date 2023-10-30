using Classes;

class PickItem
{      
    Objects o = new Objects();
    Player player;
    public void PickItems()
    {
        AvalibleItems items = o.GetAvalibleItems();
        o.Items();
        o.ShowaItems();
        int choice = int.Parse(Console.ReadLine());
        
        if(choice == 1)
        {
            Item selectedItem = items.Items[choice-1];
            player.AddInventory(selectedItem);
        }
    }
}