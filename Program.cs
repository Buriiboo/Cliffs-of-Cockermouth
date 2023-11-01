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
                    game.CharacterCreation();
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
