// <copyright file="MovieMethods.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using MyMoviesFF.Data;
    using MyMoviesFF.Repository;

    /// <summary>
    /// Implements IMovieMethods interface's methods.
    /// </summary>
    public class MovieMethods : IMovieMethods
    {/// <summary>
     /// Initializes a new instance of the <see cref="MovieMethods"/> class.
     /// </summary>
     /// <param name="movieRepo"> Repository of movie.</param>
        public MovieMethods(IMovieRepository movieRepo)
        {
            this.MovieRepo = movieRepo;
        }

        /// <summary>
        /// Gets or sets the Movie Repository.
        /// </summary>
        private IMovieRepository MovieRepo { get; set; }

        /// <inheritdoc/>
        public void ChangeIMDB(int id, int newimdb)
        {
            this.MovieRepo.ChangeIMDB(id, newimdb);
        }

        /// <inheritdoc/>
        public IList<Movie> GetAllMovies()
        {
            return this.MovieRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Movie GetOneMovie(int id)
        {
            return this.MovieRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public void InsertNewMovie(string title, int year, string genre, double imdb, int agelimit)
        {
            Movie movie = new Movie()
            {
                Title = title,
                Year = year,
                Genre = genre,
                IMDB = imdb,
                AgeLimit = agelimit,
            };
            this.MovieRepo.Insert(movie);
        }

        /// <inheritdoc/>
        public bool RemoveMovie(Movie entity)
        {
            return this.MovieRepo.Remove(entity);
        }
    }
}
