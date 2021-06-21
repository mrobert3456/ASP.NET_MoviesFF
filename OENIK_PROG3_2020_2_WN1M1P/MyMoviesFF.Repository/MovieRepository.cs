// <copyright file="MovieRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the Repository class for the movies.
    /// </summary>
    public class MovieRepository : BaseRepo<Movie>, IMovieRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieRepository"/> class.
        /// </summary>
        /// <param name="ctx">This parameter is the dbcontext class, which is passed to the base class.</param>
        /// <param name="actorRepository">Repository of actor.</param>
        /// <param name="directorRepository">Repository of director.</param>
        public MovieRepository(DbContext ctx, IActorRepository actorRepository, IDirectorRepository directorRepository)
            : base(ctx)
        {
            this.ActorRepo = actorRepository;
            this.DirectorRepo = directorRepository;
        }

        /// <summary>
        /// Gets or sets the Actor repository.
        /// </summary>
        private IActorRepository ActorRepo { get; set; }

        /// <summary>
        /// Gets or sets the Director repository.
        /// </summary>
        private IDirectorRepository DirectorRepo { get; set; }

        /// <summary>
        /// This method changes the imdb score of a movie.
        /// </summary>
        /// <param name="id">This is the movies id.</param>
        /// <param name="newimdb">This is the imdb score, which will be the new imdb score of a movie.</param>
        public void ChangeIMDB(int id, double newimdb)
        {
            var movie = this.GetOne(id);
            if (movie != null)
            {
                movie.IMDB = newimdb;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Object not found!");
            }
        }

        /// <summary>
        /// Gets one specified movie.
        /// </summary>
        /// <param name="id">This is the id, which indicates the movie.</param>
        /// <returns>Returns a specified movie.</returns>
        public override Movie GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(i => i.MovieId == id);
        }

        /// <summary>
        ///  Insert a new movie to the database.
        /// </summary>
        /// <param name="entity">This is the movie, which should be added.</param>
        public override void Insert(Movie entity)
        {
            (this.ctx as MovieDbContext).Movies.Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Removes a movie from the database.
        /// </summary>
        /// <param name="entity">Specifies which movie should be removed.</param>
        /// <returns>Returns whether the movie was successfully removed or not from the database.</returns>
        public override bool Remove(Movie entity)
        {
            if (entity != null && this.GetOne(entity.MovieId) != null)
            {
                (this.ctx as MovieDbContext).Movies.Remove(entity);
                this.ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
