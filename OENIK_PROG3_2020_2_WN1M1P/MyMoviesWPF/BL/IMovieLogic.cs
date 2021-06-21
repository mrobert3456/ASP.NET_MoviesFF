// <copyright file="IMovieLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF.BL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// Describe the logic for Movies table.
    /// </summary>
    public interface IMovieLogic
    {
        /// <summary>
        /// Adds a movie to a list, which will be appear in the UI.
        /// </summary>
        /// <param name="list">IList collection of movies.</param>
        void AddMovie(IList<Movie> list);

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="list">IList collection of movies.</param>
        /// <param name="movie">Movie entity.</param>
        void DelMovie(IList<Movie> list, ref Movie movie);

        /// <summary>
        /// Modifies the selected movie entity.
        /// </summary>
        /// <param name="movie">Movie entity.</param>
        void ModMovie(ref Movie movie);

        /// <summary>
        /// Gets all movies from the database.
        /// </summary>
        /// <returns>Returns an IList collection of movies.</returns>
        IList<Movie> GetAllMovies();

        /// <summary>
        /// Gets all actors from the database.
        /// </summary>
        /// <returns>Returns an IList collection of actors.</returns>
        IList<Actor> GetAllActors();

        /// <summary>
        /// Gets all directors from the database.
        /// </summary>
        /// <returns>Returns an IList collection of directors.</returns>
        IList<Director> GetAllDirectors();

        /// <summary>
        /// Adds an actor to the selected movie.
        /// </summary>
        /// <param name="movie">Selected Movie entity.</param>
        /// <param name="actors">IList collection of actors.</param>
        /// <param name="actor">Actor entity, which will be added to the movie.</param>
        void AddActortoMovie(ref Movie movie, IList<Actor> actors, Actor actor);

        /// <summary>
        /// Deletes an actor from the selected movie.
        /// </summary>
        /// <param name="movie">Selected Movie entity.</param>
        /// <param name="actors">IList collection of actors.</param>
        /// <param name="actor">Actor entity, which will be deleted from the movie.</param>
        void DelActorFromMovie(ref Movie movie, IList<Actor> actors, Actor actor);

        /// <summary>
        /// Adds a director to the selected movie.
        /// </summary>
        /// <param name="movie">Selected Movie entity.</param>
        /// <param name="directors">IList collection of directors.</param>
        /// <param name="dir">Director entity, which will be added to the movie.</param>
        void AddDirectortoMovie(ref Movie movie, IList<Director> directors, Director dir);

        /// <summary>
        /// Deletes a director from the selected movie.
        /// </summary>
        /// <param name="movie">Selected Movie entity.</param>
        /// <param name="directors">IList collection of directors.</param>
        /// <param name="dir">Director entity, which will be deleted from the movie.</param>
        void DelDirectorFromMovie(ref Movie movie, IList<Director> directors, Director dir);
    }
}
