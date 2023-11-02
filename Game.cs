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
    private Player playerCharacter; 
    private Random random = new Random();
    private Room currentRoom; 
    private RoomList roomList = new RoomList(); 
    


    public Player CharacterCreation()
    {
        Player playerCharacter = cc.Character(); // Create the player's character
        Console.WriteLine($"{playerCharacter}");
        return playerCharacter;
    }
 


    public void Start()
        {
            // Character creation
            playerCharacter = CharacterCreation();
             // Set the initial room
            currentRoom = roomList.Rooms[0]; // You can choose the starting room based on your game's logic
            // Main game loop
            while (true)
            {
                Console.WriteLine(playerCharacter.Name + " stands in " + currentRoom.Description);
                Console.WriteLine("1. Enter the next room");
                Console.WriteLine("2. Engage in a monster battle");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Transition to the next room
                        currentRoom = GetNextRoom(currentRoom, roomList.Rooms);
                        break;
                    case "2":
                        // Engage in a monster battle
                        Monster randomMonster = new Monster(); // Uses the parameterless constructor
                        Battle(playerCharacter, randomMonster);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        public Room GetNextRoom(Room currentRoom, List<Room> roomList)
        {
            Console.WriteLine("Choose the next room:");
            
            // Shuffle the list of rooms (excluding the first room at index 0 ->entrance)
            List<Room> shuffledRooms = roomList.Skip(1).OrderBy(x => Guid.NewGuid()).ToList();

            for (int i = 0; i < Math.Min(shuffledRooms.Count, 2); i++)
            {
                Console.WriteLine($"{i + 1}. {shuffledRooms[i].Name}");
            }
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                // Check if the choice is within valid bounds
                if (choice >= 1 && choice <= Math.Min(shuffledRooms.Count, 2))
                {
                    // Subtract 1 from the choice to match the list index
                    return shuffledRooms[choice - 1];
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number.");
            }

            // Return the current room if the choice is invalid
            return currentRoom;
        }


        public void Battle(Player playerCharacter, Monster monster)
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

            Thread.Sleep(0000);
            playerCharacter.AddInventory(new Item(0, playerCharacter.Damage, 0, "Handen", "Du kan slå någon i ansiktet", 100));
            Thread.Sleep(0000);
            
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

