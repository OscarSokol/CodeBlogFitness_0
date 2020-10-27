using CodeBlogFitness_BL.Controller;
using CodeBlogFitness_BL.Model;
using System;


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
            var eatingController = new EatingController(userController.CurrentUser);

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

            Console.WriteLine("Make your chose:");
            Console.WriteLine("E  - Eating");

            var key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();

        }

        private static (Food Food, double Weight) EnterEating()
        {// we added nuGet System.ValueTuple
            Console.WriteLine("Enter name of product:");
            var food = Console.ReadLine();

            var proteins = ParseDouble("proteins");

            var fats = ParseDouble("fats");

            var carbohydrates = ParseDouble("carbohydrates");

            var calories = ParseDouble("calories");

            var weight = ParseDouble("weight of all meal");//weight

            var product = new Food(food, proteins, fats, carbohydrates, calories);

            //return Key value
            return (Food: product, Weight: weight);//New for me: Food: product, Weight: weight
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
                Console.WriteLine($"Please enter {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
 
                }
                else
                {
                    Console.WriteLine($"Please enter correct format of {name} ");
                }

            }

        }
    }
}
