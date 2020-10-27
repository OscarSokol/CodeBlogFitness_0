using System;

namespace CodeBlogFitness_BL.Model
{/// <summary>
/// User
/// </summary>

    [Serializable]
    public class User
    {
        #region Members
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; set; }//TODO: need to check the input because the set!
        /// <summary>
        /// BirthDay
        /// </summary>
        public DateTime BirthDay { get; set; } //TODO: need to check the input because the set!
        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDay.Year; } }//TODO: 
        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - BirthDay.Year;
        //if(BirthDay.Year > nowDate.AddYears(-age)) age--;
        #endregion

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name">user name</param>
        /// <param name="gender">user gender</param>
        /// <param name="birthDay"> user birth day</param>
        /// <param name="weight">user weight</param>
        /// <param name="height">user height</param>

        public User(string name, Gender gender, DateTime birthDay, double weight, double height)
        {
            #region check the input from the user
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty.", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender can not be empty.", nameof(gender));
            }

            if (birthDay < DateTime.Parse("01.01.1900") || birthDay > DateTime.Now)
            {
                throw new ArgumentException("Birth day is not correct", nameof(birthDay));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight is not correct", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height is not correct", nameof(height));
            }
            #endregion

            //
            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        } 
    }
}
