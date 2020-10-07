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

            Console.WriteLine("Enter user gender:");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter user birthDay:");
            var birthDay = DateTime.Parse(Console.ReadLine());//TODO: try parse!

            Console.WriteLine("Enter user weight:");
            var weight = double.Parse(Console.ReadLine());//TODO: try parse!

            Console.WriteLine("Enter user height:");
            var height = double.Parse(Console.ReadLine());//TODO: try parse!

            var userController = new UserController(name, gender, birthDay, weight, height);
            userController.Save();
        }
    }
}
