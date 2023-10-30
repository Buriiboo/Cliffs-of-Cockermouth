using Classes;

class Objects
{
    AvalibleItems aItems = new AvalibleItems();
    public void Items()
    {
        Item item;
        item = new Item( 2, 12, 0, "bowlingklot", "gör ont att få kastad på sig", 1);
        aItems.Items.Add(item);   
    }
    public void Abilities()
    {
        Ability ability;
        ability = new Ability(14, 2, "eldkast", "låter dig kasta eld");
        aItems.Abilities.Add(ability);
    }

}
class CharacterCreation
{
    public Player Character()
    {
        Console.Clear();
        Console.Write("Choose a name: ");
        string characterName = Console.ReadLine();

        int characterHP, physDamage, magicDamage, exp = 0, lvl = 1;

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
            player = new Player(120, 1, 2, 20, characterName);
            characterHP = 120;
            physDamage = 20;
            magicDamage = 2;
        }
        else if (characterClassChoice == 2)
        {
            // Trolleri-are
            player = new Player(80, 1, 2, 2, characterName);
            characterHP = 80;
            physDamage = 2;
            magicDamage = 20;
        }

        // Create the player character using the Player class
        return player;
    }
}