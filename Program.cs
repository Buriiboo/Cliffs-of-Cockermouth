﻿using System;

namespace Mainmenu
{
    public class Program
    {
        static void Main(string[] args)
        {   

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
                        Console.Clear();
                        Console.Write("Chose a name: ");
                        string characterName = Console.ReadLine();

                        int characterHP, physDamage, magicDamage, exp = 0, lvl = 1;

                        Console.Clear();
                        int characterClassChoice;
                        do
                        {
                            Console.WriteLine("Välj din klass: ");
                            Console.WriteLine("1) Riddare");
                            Console.WriteLine("2) Trolleri-are");
                        } while (!int.TryParse(Console.ReadLine(), out characterClassChoice) || (characterClassChoice != 1 && characterClassChoice != 2));

                        if (characterClassChoice == 1)
                        {   // Riddare
                            characterHP = 120;
                            physDamage = 20;
                            magicDamage = 2;
                        }
                        else if (characterClassChoice == 2)
                        {   // Trolleri-are
                            characterHP = 80;
                            physDamage = 2;
                            magicDamage = 20;
                        }
                        
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
    }
}