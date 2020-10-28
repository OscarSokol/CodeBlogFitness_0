using CodeBlogFitness_BL.Controller;
using CodeBlogFitness_BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("he");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Message", typeof(Program).Assembly);

            Console.WriteLine(Languages.Message_en.Hello);//resourceManager.GetString("Hello",culture)

            Console.WriteLine(Languages.Message_en.UserName);//resourceManager.GetString("UserName",culture)
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine(Languages.Message_en.UserGender);
                var gender = Console.ReadLine();
                var weight = ParseDouble(Languages.Message_en.Weight);//weight
                var height = ParseDouble(Languages.Message_en.Height);//height
                var birthDay = ParseDataTime();

                userController.SetNewUserData(gender, birthDay, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine(Languages.Message_en.UserChose);
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
            Console.WriteLine(Languages.Message_en.ProductName);
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
                Console.WriteLine(Languages.Message_en.BirhDay);
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Languages.Message_en.BirhDay_cerrect_form);
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
