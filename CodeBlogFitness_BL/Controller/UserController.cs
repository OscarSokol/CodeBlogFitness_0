using CodeBlogFitness_BL.Model;
using System;
using System.IO;
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
        public User User { get; }

        /// <summary>
        /// Creation new controller of user
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: check
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
            
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
                    formatter.Serialize(fs, User);
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
        /// <summary>
        /// Load user parameter
        /// </summary>
        /// <returns>User of app</returns>
        public User Load()
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.Open))
            {
                User user;
                try
                {
                    // Deserialize the hashtable from the file and
                    // assign the reference to the local variable.
                    /*
                    if (formatter.Deserialize(fs) is User user)
                    {//FOR one user!
                        return user;
                    }
                    */

                    user = (User)formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to Deserialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                    
                }
                return user;
            }
        }


    }
}
