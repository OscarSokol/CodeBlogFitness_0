using System;
using System.Collections.Generic;

namespace CodeBlogFitness_BL.Controller
{
    public interface IDataSeve
    {
        void Save<T>(List<T> item) where T : class;

        List<T> Load<T>() where T: class;

    }
}
