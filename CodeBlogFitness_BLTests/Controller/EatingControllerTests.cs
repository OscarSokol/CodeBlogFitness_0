using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness_BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness_BL.Model;

namespace CodeBlogFitness_BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();//random name
            var foodName = Guid.NewGuid().ToString();//random name
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50,100), rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100));

            //Act
            eatingController.Add(food, 40);

            //Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);

        }
    }
}