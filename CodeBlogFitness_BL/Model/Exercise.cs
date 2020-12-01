using System;

namespace CodeBlogFitness_BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }//for entityfreamwork

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }//for entityfreamwork

        public User User { get; }
            
        public Exercise() { }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user )
        {
            //Todo: check
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;

        }
    }
}
