using System;
using System.Diagnostics;
using System.Collections.Generic;
using Monsters;
using Classes;


namespace Mainmenu;

public class Program
{
    static void Main(string[] args)
    {   
        AvalibleItems u = new AvalibleItems();
        Item e;
        e = new Item( 2, 12, 0, "bowlingklot", "gör ont att få kastad på sig", 1);
        u.Items.Add(e);
        Ability a;
        a = new Ability(14, 2, "eldkast", "låter dig kasta eld");
        u.Abilities.Add(a);
        foreach(Ability i in u.Abilities)
        {
            Console.WriteLine(i);
        }
        foreach(Item i in u.Items)
        {
            Console.WriteLine(i);
        }

        Game game = new Game();

        bool runMain = true;
        while (runMain)
        {
            
            
            Console.WriteLine("|| ===================== ||");
            Console.WriteLine("|| CLIFFS OF COCKERMOUTH ||");
            Console.WriteLine("|| ======================||");
            Console.WriteLine("|| 1) New game           ||");
            Console.WriteLine("|| 2) Load game          ||");     
            Console.WriteLine("|| 3) ?????????          ||");
            Console.WriteLine("|| 4) Exit               || ");
            Console.WriteLine("|| ===================== ||");
            string choice = Console.ReadLine();
            
            switch(choice)
            {
                case "1":
                    //character creator -> name, class, 
                    game.Start();

                    break;
                case "2":
                    //Load game. json?
                    break;
                case "3":
                    //????
                    break;
                case "4":
                    return;
            }
        }

    }

public class Game
{
    private Player playerCharacter; // Declare playerCharacter as a field

    public void Start()
    {
        playerCharacter = CharacterCreation(); // Create the player's character
        StartGameplay(); // Start the game after character creation
    }

    private Player CharacterCreation()
    {
        Console.Clear();
        Console.Write("Choose a name: ");
        string characterName = Console.ReadLine();

        int characterHP, physDamage, magicDamage, exp = 0, lvl = 1;

        Console.Clear();
        int characterClassChoice;

        do
        {
            Console.WriteLine("Choose your class: ");
            Console.WriteLine("1) Riddare");
            Console.WriteLine("2) Trolleri-are");
        } while (!int.TryParse(Console.ReadLine(), out characterClassChoice) || (characterClassChoice != 1 && characterClassChoice != 2));

        if (characterClassChoice == 1)
        {
            // Riddare
            characterHP = 120;
            physDamage = 20;
            magicDamage = 2;
        }
        else if (characterClassChoice == 2)
        {
            // Trolleri-are
            characterHP = 80;
            physDamage = 2;
            magicDamage = 20;
        }

        // Create the player character using the Player class
        return new Player(characterHP, lvl, physDamage, characterName, "Description of the player character");
    }

    private void StartGameplay()
    {
        Console.Clear();
        Console.WriteLine($"WATCHOUT WATCHOUT WATCHOUT HEEEERE COMES {playerCharacter.Name}!!!");

        // Behöver fixa "Experience" egenskaper på GameEntity. Phys Dmg och magic dmg? eller bara dmg? (simplare?)

        while (playerCharacter.Health > 0 && randomMonster.HP > 0)
        {
            Console.WriteLine($"{playerCharacter.Name} attacks {randomMonster.Name} for {playerCharacter.Damage} damage!");
            randomMonster.HP -= playerCharacter.Damage;

            Console.WriteLine($"{randomMonster.Name} attacks {playerCharacter.Name} for {randomMonster.Damage} damage!");
            playerCharacter.Health -= randomMonster.Damage;

            Console.WriteLine($"{playerCharacter.Name}'s HP: {playerCharacter.Health}");
            Console.WriteLine($"{randomMonster.Name}'s HP: {randomMonster.HP}");
            Console.ReadLine();
        }

        if (playerCharacter.Health <= 0)
        {
            Console.WriteLine($"Game over! {randomMonster.Name} defeated {playerCharacter.Name}.");
            Console.ReadLine();
        }
        else if (randomMonster.HP <= 0)
        {
            Console.WriteLine($"Congratulations! {playerCharacter.Name} defeated {randomMonster.Name}.");
            playerCharacter.Experience += 150;
            Console.WriteLine($"You gained {playerCharacter.Experience} exp!");

            if (playerCharacter.Experience >= 100)
            {
                playerCharacter.Level++;
                Console.WriteLine("Level up!!");
                Console.WriteLine($"{playerCharacter.Name}'s level increased to {playerCharacter.Level}");
            }

            Console.ReadLine();
        }
    }
    
}
}