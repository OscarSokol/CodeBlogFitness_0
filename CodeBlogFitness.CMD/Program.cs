using CodeBlogFitness_BL.Controller;
using CodeBlogFitness_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from app");//new commit
            
            Console.WriteLine("Enter user name:");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter gender your:");
                var gender = Console.ReadLine();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                var birthDay = ParseDataTime();

                userController.SetNewUserData(gender, birthDay, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

            /*
             Console.WriteLine("Enter user gender:");
             var gender = Console.ReadLine();


             Console.WriteLine("Enter user birthDay:");
             var birthDay = DateTime.Parse(Console.ReadLine());//TODO: try parse!

             Console.WriteLine("Enter user weight:");
             var weight = double.Parse(Console.ReadLine());//TODO: try parse!

             Console.WriteLine("Enter user height:");
             var height = double.Parse(Console.ReadLine());//TODO: try parse!
   
            userController.Save();
            */
        }

        private static DateTime ParseDataTime()
        {
            DateTime birthDay;
            while (true)
            {//1:08:15
                Console.WriteLine("Enter your birth day (dd.mm.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter your birth day in correct format (dd.mm.yyyy)");
                }

            }

            return birthDay;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter your {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
 
                }
                else
                {
                    Console.WriteLine($"Enter correct {name} format");
                }

            }

        }
    }
}
