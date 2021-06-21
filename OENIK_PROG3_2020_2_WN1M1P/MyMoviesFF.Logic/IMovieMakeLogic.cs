// <copyright file="IMovieMakeLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describe the important elements in making a movie.
    /// </summary>
    public interface IMovieMakeLogic
    {
        /// <summary>
        /// Add an actor to a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="actorid">This is the actor's id.</param>
        void AddActor(int movieid, int actorid);

        /// <summary>
        /// Add a director to a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="directorid">This is the director's id.</param>
        void AddDirector(int movieid, int directorid);

        /// <summary>
        /// Removes an actor from a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="actorid">This is the actor's id.</param>
        void RemoveActor(int movieid, int actorid);

        /// <summary>
        /// Removes a director from a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="directorid">This is the director's id.</param>
        void RemoveDirector(int movieid, int directorid);
    }
}
