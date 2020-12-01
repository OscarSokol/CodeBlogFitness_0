using CodeBlogFitness_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness_BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User user;

        

        /// <summary>
        /// Foods this is a list of products
        /// </summary>
        public List<Food> Foods { get; }
        /// <summary>
        /// The meal
        /// </summary>
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User name can't be empty", nameof(user));

            Foods = GetAllFoods();

            Eating = GetEating();
        }

        /// <summary>
        /// Add to meal and to product and all new of what use eat then save.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);//because we return default(T);
            if (product == null)
            {//new product
                Foods.Add(food);
                Eating.Add(food, weight);
            }
            else
            {
                Eating.Add(product, weight);
            }
            Save();
        }

        /// <summary>
        /// Get all user meal from file
        /// </summary>
        /// <returns></returns>
        private Eating GetEating()
        {
            //return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);//because we return default(T);
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        /// <summary>
        /// GetAllFoods = get all product from file 
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            //return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();//because we return default(T);
            return Load<Food>() ?? new List<Food>();
        }

        /// <summary>
        /// Save product and all user meal to the file
        /// </summary>
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
            /*
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
            */
        }
    }
}
