// <copyright file="IMovieActorRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the interface, which will be used by MovieActorRepository class.
    /// </summary>
    public interface IMovieActorRepository : IConnRepository<MovieActor>
    {
        /// <summary>
        /// Add an actor to a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="actorid">This is the actor's id.</param>
        void AddActor(int movieid, int actorid);

        /// <summary>
        /// Removes an actor from a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="actorid">This is the actor's id.</param>
        void RemoveActor(int movieid, int actorid);
    }
}
