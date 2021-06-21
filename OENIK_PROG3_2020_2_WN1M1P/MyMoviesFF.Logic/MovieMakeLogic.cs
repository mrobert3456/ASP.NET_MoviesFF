// <copyright file="MovieMakeLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Win32.SafeHandles;
    using MyMoviesFF.Data;
    using MyMoviesFF.Repository;

    /// <summary>
    /// Methods associated  with movie making.
    /// </summary>
    public class MovieMakeLogic : IMovieMakeLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieMakeLogic"/> class.
        /// </summary>
        /// <param name="movierepo">Repository of movie.</param>
        /// <param name="movieActor">Repository of movieactor.</param>
        /// <param name="movieDirector">Repository of moviedirector.</param>
        public MovieMakeLogic(IMovieRepository movierepo, IMovieActorRepository movieActor, IMovieDirectorRepository movieDirector)
        {
            this.MovieRepo = movierepo;
            this.MovieActorRepo = movieActor;
            this.MovieDirectorRepo = movieDirector;
        }

        /// <summary>
        /// Gets or sets the Movie Repository.
        /// </summary>
        private IMovieRepository MovieRepo { get; set; }

        /// <summary>
        /// Gets or sets the MovieActor Repository.
        /// </summary>
        private IMovieActorRepository MovieActorRepo { get; set; }

        /// <summary>
        /// Gets or sets the MovieDirector Repository.
        /// </summary>
        private IMovieDirectorRepository MovieDirectorRepo { get; set; }

        /// <inheritdoc/>
        public void AddActor(int movieid, int actorid)
        {
            this.MovieActorRepo.AddActor(movieid, actorid);
        }

        /// <inheritdoc/>
        public void AddDirector(int movieid, int directorid)
        {
            this.MovieDirectorRepo.AddDirector(movieid, directorid);
        }

        /// <summary>
        /// Gets the movies and it's actors, and directors.
        /// </summary>
        /// <returns>Returns an IList collection of ActorsDirectorsPerMovies.</returns>
        public IList<ActorsDirectorsPerMovies> GetActorsDirectorPerMovies()
        {
            var subq = from movact in this.MovieActorRepo.GetAll()
                       join mov in this.MovieRepo.GetAll()
                       on movact.MovieId equals mov.MovieId
                       join movdir in this.MovieDirectorRepo.GetAll()
                       on mov.MovieId equals movdir.MovieId
                       select new
                       {
                           mov.Title,
                           movact.Actor,
                           movdir.Director,
                       };

            var result = from item in subq.ToList()
                         group item by item.Title into g
                         select new ActorsDirectorsPerMovies
                         {
                            Title = g.Key,
                            Actors = g.Select(i => i.Actor).Distinct(),
                            Directors = g.Select(i => i.Director).Distinct(),
                         };
            return result.ToList();
        }

        /// <summary>
        ///  Async version GetActorsDirectorPerMovies method.
        /// </summary>
        /// <returns>Returns a Task IList collection of ActorsDirectorsPerMovies.</returns>
        public Task<IList<ActorsDirectorsPerMovies>> GetActorsDirectorPerMoviesAsync()
        {
            return Task<IList<ActorsDirectorsPerMovies>>.Factory.StartNew(this.GetActorsDirectorPerMovies);
        }

        /// <inheritdoc/>
        public void RemoveActor(int movieid, int actorid)
        {
            this.MovieActorRepo.RemoveActor(movieid, actorid);
        }

        /// <inheritdoc/>
        public void RemoveDirector(int movieid, int directorid)
        {
            this.MovieDirectorRepo.RemoveDirector(movieid, directorid);
        }
    }
}
