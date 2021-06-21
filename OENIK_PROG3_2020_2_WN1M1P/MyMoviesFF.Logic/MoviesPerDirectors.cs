// <copyright file="MoviesPerDirectors.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    ///  Stores the directors and their movies.
    /// </summary>
    public class MoviesPerDirectors
    {
        /// <summary>
        /// Gets or sets the name of the director.
        /// </summary>
        public string DirectorName { get; set; }

        /// <summary>
        /// Gets or sets the movies wich were directed by the current director.
        /// </summary>
        public IEnumerable<Movie> Movies { get; set; }

        /// <summary>
        /// Director and movie datas.
        /// </summary>
        /// <returns>Returns a string of a director and his/her movies.</returns>
        public override string ToString()
        {
            string s = $"{this.DirectorName}\n";
            if (this.Movies.Any())
            {
                foreach (var item in this.Movies)
                {
                    s += "\t[" + item.Title + "]\n";
                }
            }
            else
            {
                s += "\t[Nincs nyilvántartott filmje.]";
            }

            s += "\n\n-----------------------------------------------\n";
            return s;
        }

        /// <summary>
        /// Determine whether a two MoviesPerDirectors object is equal or not.
        /// </summary>
        /// <param name="obj">Indicates the MoviesPerDirectors object, which will be compared to the caller object.</param>
        /// <returns>Returns a bool whether two MoviesPerDirectors are the same or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is MoviesPerDirectors)
            {
                MoviesPerDirectors other = obj as MoviesPerDirectors;
                return this.DirectorName == other.DirectorName;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines the hash code of the MoviesPerDirectors object.
        /// </summary>
        /// <returns>Returns a hash code of the MoviesPerDirectors object.</returns>
        public override int GetHashCode()
        {
            return this.DirectorName.GetHashCode() + this.DirectorName.Length.GetHashCode();
        }
    }
}
