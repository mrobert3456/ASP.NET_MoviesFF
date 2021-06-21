// <copyright file="IMovieMethods.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// Includes the crud and non-crud method definitions, which will be used by IActingLogic, and IMovieDirectLogic.
    /// </summary>
    public interface IMovieMethods
    {
        /// <summary>
        /// Gets one movie.
        /// </summary>
        /// <param name="id">Specifies the movie id.</param>
        /// <returns>Returns a movie object.</returns>
        Movie GetOneMovie(int id);

        /// <summary>
        /// Gets all movies from the database.
        /// </summary>
        /// <returns>Returns an IList collection of movies.</returns>
        IList<Movie> GetAllMovies();

        /// <summary>
        /// Changes the imdb score of a specified movie object.
        /// </summary>
        /// <param name="id">Specifies the movie object.</param>
        /// <param name="newimdb">This is the imdb score, which will be the new imdb score of a movie.</param>
        void ChangeIMDB(int id, int newimdb);

        /// <summary>
        /// Insert a new movie to the database.
        /// </summary>
        /// <param name="title">Movie title.</param>
        /// <param name="year">Release year of the movie.</param>
        /// <param name="genre">Movie's genre.</param>
        /// <param name="imdb">Movie's imdb score.</param>
        /// <param name="agelimit">Movie's age limit.</param>
        void InsertNewMovie(string title, int year, string genre, double imdb, int agelimit);

        /// <summary>
        /// Removes a movie from the database.
        /// </summary>
        /// <param name="entity">Specifies which movie should be removed.</param>
        /// <returns>Returns whether the movie was successfully removed or not from the database.</returns>
        bool RemoveMovie(Movie entity);
    }
}
