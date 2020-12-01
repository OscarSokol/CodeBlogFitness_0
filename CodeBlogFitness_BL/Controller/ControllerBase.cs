
using System.Collections.Generic;


namespace CodeBlogFitness_BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSeve menager = new SerializeDataSeve();
        protected void Save<T>(List<T> item) where T : class
        {
            menager.Save( item);
        }

        protected List<T> Load<T>() where T : class
        {
            return menager.Load<T>();
        }


    }
}
