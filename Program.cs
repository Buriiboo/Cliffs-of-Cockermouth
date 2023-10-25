using System;

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
                        System.Console.WriteLine("");
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        return;
                }
            }

        }
    }
}