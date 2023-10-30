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
                    game.StartGameplay();
                    break;
                case "2":
                    //Load game. json?
                    break;
                case "3":
                    //????
                    MonsterList monsterList = new MonsterList();
                    List<Monster> monsters = monsterList.Monsters;

                    foreach (Monster monster in monsters)
                    {
                        Console.WriteLine($"Name: {monster.Name}");
                        Console.WriteLine($"Description: {monster.Description}");
                        Console.WriteLine($"Health: {monster.Health}");
                        Console.WriteLine($"Damage: {monster.Damage}");
                        Console.WriteLine($"Level: {monster.Level}");
                        Console.WriteLine($"Monster Type: {monster.MonsterType}");
                        // Output other monster properties as needed
                    }

                    break;
                case "4":
                    return;
            }
        }

    }
}
public class Game
{
    CharacterCreation cc = new CharacterCreation();
    private Player playerCharacter; // Declare playerCharacter as a field
    private Random random = new Random();

    public void Start()
    {
        playerCharacter = cc.Character(); // Create the player's character
        Console.WriteLine($"{playerCharacter}");
        //StartGameplay(); // Start the game after character creation
    }

    public void StartGameplay()
    {
        
        // Create a list of predefined monsters
        MonsterList monsterList = new MonsterList();
        List<Monster> monsters = monsterList.Monsters;
        PickItem pickItem = new PickItem();

        // Randomly select a monster from the list
        int randomIndex = random.Next(0, monsters.Count);
        Monster randomMonster = monsters[randomIndex];

        Thread.Sleep(2000);
        pickItem.PickItems();
        Console.WriteLine($"WATCHOUT WATCHOUT WATCHOUT HEEEERE COMES {playerCharacter.Name}!!!");

        while (playerCharacter.Health > 0 && randomMonster.Health > 0)
        {
            
            Console.WriteLine($"{playerCharacter.Name} attacks {randomMonster.Name} for {playerCharacter.Damage} damage!");
            randomMonster.Health -= playerCharacter.Damage;

            Console.WriteLine($"{randomMonster.Name} attacks {playerCharacter.Name} for {randomMonster.Damage} damage!");
            playerCharacter.Health -= randomMonster.Damage;

            Console.WriteLine($"{playerCharacter.Name}'s HP: {playerCharacter.Health}");
            Console.WriteLine($"{randomMonster.Name}'s HP: {randomMonster.Health}");
            Console.ReadLine();
        }


        if (playerCharacter.Health <= 0)
        {
            Console.WriteLine($"Game over! {randomMonster.Name} defeated {playerCharacter.Name}.");
            Console.ReadLine();
        }
        else if (randomMonster.Health <= 0)
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

