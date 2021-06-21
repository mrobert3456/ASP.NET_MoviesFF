// <copyright file="IMovieRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the interface, which will be used by MovieRepository class.
    /// </summary>
    public interface IMovieRepository : IRepository<Movie>
    {
        /// <summary>
        ///  This method changes the imdb score of a movie.
        /// </summary>
        /// <param name="id">This is the movies id.</param>
        /// <param name="newimdb">This is the imdb score, which will be the new imdb score of a movie.</param>
        void ChangeIMDB(int id, double newimdb);
    }
}
