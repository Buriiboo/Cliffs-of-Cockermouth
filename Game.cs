using System;
using System.Diagnostics;
using System.Collections.Generic;
using Monsters;
using Classes;

namespace Mainmenu;
    public class Game
    {
        CharacterCreation cc = new CharacterCreation();
        private Player playerCharacter; // Declare playerCharacter as a field
        private Random random = new Random();

        public void CharacterCreation()
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
            Action action = new Action();

            // Randomly select a monster from the list
            int randomIndex = random.Next(0, monsters.Count);
            Monster randomMonster = monsters[randomIndex];

            Thread.Sleep(2000);
            playerCharacter.AddInventory(new Item(0, playerCharacter.Damage, 0, "Handen", "Du kan slå någon i ansiktet", 100));
            Thread.Sleep(2000);
            
            Console.WriteLine($"WATCHOUT WATCHOUT WATCHOUT HEEEERE COMES {playerCharacter.Name}!!!");

            while (playerCharacter.Health > 0 && randomMonster.Health > 0)
            {
                //här vill jag ha kod som gör att man kan välja att slå med item från playerinv eller slå med hand
                Console.Clear();
                pickItem.PickItems(playerCharacter);
                action.Attack(randomMonster, playerCharacter); 
                //Få välja om man vill attackera eller defence. Sedan så att defence kan ge parry och därmer 2x damage
                
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

