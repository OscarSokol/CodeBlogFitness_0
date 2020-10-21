using CodeBlogFitness_BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace CodeBlogFitness_BL.Controller
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User app
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// CurrentUser from file. if not exist we created one.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// IsNewUser = flag - user is not existed and we created one
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Creation new controller of user
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name can not be empty", nameof(userName));
            }

            Users = GetUsersDate();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);//return user if exist else return null

            if (CurrentUser == null)
            {//if the user isn't exist we will create him
                CurrentUser = new User(userName);//default constructor only with name
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            //TODO: check the input

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();//will saved with anther users
        }

        /// <summary>
        /// Get saved list of users
        /// </summary>
        /// <returns>User of app</returns>
        private List<User> GetUsersDate()
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {//FOR one user!
                    return users;
                }
                else
                {
                    return new List<User>();
                }
                /*
                try
                {
                    // Deserialize
                    if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                    {//FOR one user!
                        return users;
                    }
                    //user = (List<User> users)formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to Deserialize - load user. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }

                return new List<User>();
                */
            }
        }


        /// <summary>
        /// Save user parameter
        /// </summary>
        public void Save()
        {
            //Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();

            // To serialize the users,
            // you must first open a stream for writing.
            // In this case, use a file stream.
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                try
                {//is used whenever data pertaining to objects have to be sent from one application to another
                    formatter.Serialize(fs, Users);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

    }
}
