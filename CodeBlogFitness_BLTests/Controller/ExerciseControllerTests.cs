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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();//random name
            var userController = new UserController(userName);

            var actName = Guid.NewGuid().ToString();//random name
            var rnd = new Random();
            var activity = new Activity(actName, rnd.Next(50, 100));
           
            var exerciseController = new ExerciseController(userController.CurrentUser);

            //Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(actName, exerciseController.Activities.First().Name);
        }
    }
}