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
