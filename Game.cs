using System;
using System.Diagnostics;
using System.Collections.Generic;
using Monsters;
using Classes;
using System.Xml.Serialization;

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
            Classes.Action action = new Classes.Action();

            // Randomly select a monster from the list
            int randomIndex = random.Next(0, monsters.Count);
            Monster randomMonster = monsters[randomIndex];
            double playerDamage = playerCharacter.Damage;
            double monsterDamage = randomMonster.Damage;

            Thread.Sleep(2000);
            playerCharacter.AddInventory(new Item(0, playerCharacter.Damage, 0, "Handen", "Du kan slå någon i ansiktet", 100));
            
            pickItem.PickItems(playerCharacter);
            Console.Clear();
            Thread.Sleep(2000);
            Console.WriteLine($"WATCHOUT WATCHOUT WATCHOUT HEEEERE COMES {playerCharacter.Name}!!!");
            
            do
            {
                double attackMultiplier = 1;
                randomMonster.Damage = monsterDamage;
                
                //här vill jag ha kod som gör att man kan välja att slå med item från playerinv eller slå med hand
                Console.WriteLine("Vill du [1]:Attackera eller [2]Försvara dig?");
                int choice = int.Parse(Console.ReadLine());
                if(choice == 1){
                    action.Attack(randomMonster, playerCharacter); 
                    Console.WriteLine($"{playerCharacter.Name} attackerar! De gör {playerCharacter.Damage}!");
                    Console.WriteLine($"{randomMonster.Name} attacks {playerCharacter.Name} for {randomMonster.Damage} damage!");
                    playerCharacter.Damage = playerDamage;
                    Console.WriteLine($"{playerCharacter.Name}'s HP: {playerCharacter.Health}");
                    Console.WriteLine($"{randomMonster.Name}'s HP: {randomMonster.Health}");
                }
                else if(choice == 2){
                    action.Defence(randomMonster, playerCharacter, attackMultiplier);
                    Console.WriteLine($"{randomMonster.Name} attacks {playerCharacter.Name} for {randomMonster.Damage} damage!");
                    Console.WriteLine($"{playerCharacter.Name}'s HP: {playerCharacter.Health}");
                    Console.WriteLine($"{randomMonster.Name}'s HP: {randomMonster.Health}");

                }
                
                //Få välja om man vill attackera eller defence. Sedan så att defence kan ge parry och därmer 2x damage

                
            }while (randomMonster.Health > 0 && playerCharacter.Health > 0);

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

