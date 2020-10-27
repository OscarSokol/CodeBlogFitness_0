using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness_BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness_BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();//random name
            var birthDay = DateTime.Now.AddYears(-18);
            var weight = 70;
            var height = 1.70;
            var gender = "man";
            var userController = new UserController(userName);

            //Act
            userController.SetNewUserData(gender, birthDay, weight, height);
            var userController2 = new UserController(userName);//already exist

            //Assert
            Assert.AreEqual(userName, userController2.CurrentUser.Name);
            Assert.AreEqual(birthDay, userController2.CurrentUser.BirthDay);
            Assert.AreEqual(weight, userController2.CurrentUser.Weight);
            Assert.AreEqual(height, userController2.CurrentUser.Height);
            Assert.AreEqual(gender, userController2.CurrentUser.Gender.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();//random name

            //Act
            var userController = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, userController.CurrentUser.Name);

        }
    }
}