// <copyright file="IMovieDirectorRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the interface, which will be used by MovieDirectorRepository class.
    /// </summary>
    public interface IMovieDirectorRepository : IConnRepository<MovieDirector>
    {
        /// <summary>
        /// Add a director to a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="directorid">This is the director's id.</param>
        void AddDirector(int movieid, int directorid);

        /// <summary>
        /// Removes a director from a movie.
        /// </summary>
        /// <param name="movieid">This is the movie's id.</param>
        /// <param name="directorid">This is the director's id.</param>
        void RemoveDirector(int movieid, int directorid);
    }
}
