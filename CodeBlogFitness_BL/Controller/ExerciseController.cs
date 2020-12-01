using CodeBlogFitness_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness_BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "exercises.dat";
        private readonly User user;

        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user) 
        {
            this.user = user ?? throw new ArgumentNullException("User name can't be empty", nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.SingleOrDefault( a => a.Name == activity.Name);
            if (act == null)
            {//new activity
                Activities.Add(activity);
                var exercises = new Exercise(start, finish, activity, user);
                Exercises.Add(exercises);
            }
            else
            {
                var exercises = new Exercise(start, finish, act, user);
                Exercises.Add(exercises);
            }
            Save();
        }

        private List<Activity> GetAllActivities()
        {
            //return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
            return Load<Activity>() ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            //return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
            //Save(EXERCISES_FILE_NAME, Exercises);
            //Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
