using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness_BL.Controller
{
    public class DatabaseDataSave : IDataSeve
    {//User ID=YOURUSERNAME;Password=YOURPASSWORD"

        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
        /*
        public T Load<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save(string fileName, object item)
        {
            using (var db = new FitnessContext())
            {
                var type = item.GetType();

                if(type == typeof(User))
                {
                    db.Users.Add(item as User);
                }
                else if (type == typeof(Eating))
                {
                    db.Eatings.Add(item as Eating);
                }
                else if (type == typeof(Exercise))
                {
                    db.Exercises.Add(item as Exercise);
                }
                else if (type == typeof(Food))
                {
                    db.Foods.Add(item as Food);
                }
                else if (type == typeof(Gender))
                {
                    db.Genders.Add(item as Gender);
                }
                else if (type == typeof(Activity))
                {
                    db.Activities.Add(item as Activity);
                }
            }
        }
        */
    }
}
