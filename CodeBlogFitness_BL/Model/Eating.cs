using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness_BL.Model
{
    /// <summary>
    /// Eating the meal=food
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime MomentOfEating { get; set; }

        //public List<Food> Foods { get; }
        public Dictionary<Food,double> Foods { get; set; }//Dic is Not so effective in big production because
        //Food is a key and double is a volume  

        public int UserId { get; set; }//for entityfreamwork
        public virtual User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Eating() { }

        /// <summary>
        /// Constructor of eating process of user
        /// </summary>
        /// <param name="user"></param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("The user name can't be empty", nameof(user));
            MomentOfEating = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Add product and weight in over moment Of Eating
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            //check if we have his food product
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
