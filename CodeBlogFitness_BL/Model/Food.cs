using System;

namespace CodeBlogFitness_BL.Model
{
    /// <summary>
    /// All properties of product
    /// </summary>
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Proteins
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Fats
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Carbohydrates
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Calories of 100g
        /// </summary>
        public double Calories { get; set; }
        
        public Food() { }

        public Food(string name) : this(name,0,0,0,0)
        {
            //Name = name;
        }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {            
            //TODO: to check name
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
