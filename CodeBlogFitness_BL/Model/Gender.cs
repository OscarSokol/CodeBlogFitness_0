﻿using System;

namespace CodeBlogFitness_BL.Model
{   /// <summary>
    /// Gender.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name of.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create new Gender.
        /// </summary>
        /// <param name="name">Name of gender.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Must have gender", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name;

        }
    }
}
