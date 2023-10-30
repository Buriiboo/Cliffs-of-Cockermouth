using Classes;

public class Objects
{
    AvalibleItems aItems = new AvalibleItems();
    public AvalibleItems GetAvalibleItems()
    {
        Item item;
        item = new Item( 2, 12, 0, "bowlingklot", "gör ont att få kastad på sig", 1);
        aItems.Items.Add(item);   
        item = new Item( 1, 14, 0, "pinne", "gör ont att få kastad på sig", 1);
        aItems.Items.Add(item);   
        return aItems;
    }
    

    public void Abilities()
    {
        Ability ability;
        ability = new Ability(14, 2, "eldkast", "låter dig kasta eld");
        aItems.Abilities.Add(ability);
    }
    public void ShowaItems()
    {
        
        for(int i = 0; i < aItems.Items.Count; i++)
        {
            Console.WriteLine($"{i+1}: {aItems.Items[i]}");
        }
        
    }

}
class CharacterCreation
{
    public Player Character()
    {
        Console.Clear();
        Console.Write("Choose a name: ");
        string characterName = Console.ReadLine();


        int characterClassChoice;
        Player player = null;
        do
        {
            Console.WriteLine("Choose your class: ");
            Console.WriteLine("1) Riddare");
            Console.WriteLine("2) Trolleri-are");
        } while (!int.TryParse(Console.ReadLine(), out characterClassChoice) || (characterClassChoice != 1 && characterClassChoice != 2));

        if (characterClassChoice == 1)
        {
            // Riddare
            player = new Player(characterName, 150, 25, 30, 0, "description of riddare");
        }
        else if (characterClassChoice == 2)
        {
            // Trolleri-are
            player = new Player(characterName, 90, 30, 15, 0, "description of trolleriare");
        }

        // Create the player character using the Player class
        return player;
    }
}
class CreateRoom
{
    public void AddRoom(string name, string description)
    {

    }
}