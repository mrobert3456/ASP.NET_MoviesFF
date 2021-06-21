// <copyright file="ActorsDirectorsPerMovies.cs" company="WN1M1P">
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
    /// Stores a movie and it's directors, and actors.
    /// </summary>
    public class ActorsDirectorsPerMovies
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
        /// Gets or sets the directors who directed the movie.
        /// </summary>
        public IEnumerable<Director> Directors { get; set; }

        /// <summary>
        /// Movie and it's directors, and actors.
        /// </summary>
        /// <returns>Returns a string of a movie and it's actor's and director's name.</returns>
        public override string ToString()
        {
            string s = $"{this.Title}\n";
            if (this.Actors.Any())
            {
                s += "\tActors:\n";
                foreach (var item in this.Actors)
                {
                    s += "\t\t[" + item.ActorName + "]\n";
                }
            }
            else
            {
                s += "\t\t[Nincs nyilvántartott színész benne.]";
            }

            if (this.Directors.Any())
            {
                s += "\tDirectors:\n";
                foreach (var item in this.Directors)
                {
                    s += "\t\t[" + item.DirectorName + "]\n";
                }
            }
            else
            {
                s += "\t\t[Nincs nyilvántartott rendező ehhez a filmhez.]";
            }

            s += "\n\n-----------------------------------------------\n";
            return s;
        }

        /// <summary>
        /// Determine whether a two ActorsDirectorsPerMovies object is equal or not.
        /// </summary>
        /// <param name="obj">Indicates the ActorsDirectorsPerMovies object, which will be compared to the caller object.</param>
        /// <returns>Returns a bool whether two ActorsDirectorsPerMovies are the same or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ActorsDirectorsPerMovies)
            {
                ActorsDirectorsPerMovies other = obj as ActorsDirectorsPerMovies;
                return this.Title == other.Title;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines the hash code of the ActorsDirectorsPerMovies object.
        /// </summary>
        /// <returns>Returns a hash code of the ActorsDirectorsPerMovies object.</returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode() + this.Title.Length.GetHashCode();
        }
    }
}
