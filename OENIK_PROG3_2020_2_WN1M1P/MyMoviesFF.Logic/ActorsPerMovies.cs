// <copyright file="ActorsPerMovies.cs" company="WN1M1P">
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
    /// Stores the movies and it's actors.
    /// </summary>
    public class ActorsPerMovies
    {
        /// <summary>
        /// Gets or sets the title of the movie.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the actors who played in the movie.
        /// </summary>
        public IEnumerable<Actor> Actors { get; set; }

        /// <summary>
        /// Movie and actor datas.
        /// </summary>
        /// <returns>Returns a string of a movie and it's actor's name.</returns>
        public override string ToString()
        {
            string s = $"{this.Title}\n";
            if (this.Actors.Any())
            {
                foreach (var item in this.Actors)
                {
                    s += "\t[" + item.ActorName + "]\n";
                }
            }
            else
            {
                s += "\t[Nincs nyilvántartott színész benne.]";
            }

            s += "\n\n-----------------------------------------------\n";
            return s;
        }

        /// <summary>
        /// Determine whether a two ActorsPerMovies object is equal or not.
        /// </summary>
        /// <param name="obj">Indicates the ActorsPerMovies object, which will be compared to the caller object.</param>
        /// <returns>Returns a bool whether two ActorsPerMovies are the same or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ActorsPerMovies)
            {
                ActorsPerMovies other = obj as ActorsPerMovies;
                return this.Title == other.Title;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines the hash code of the ActorsPerMovies object.
        /// </summary>
        /// <returns>Returns a hash code of the ActorsPerMovies object.</returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode() + this.Title.Length.GetHashCode();
        }
    }
}
