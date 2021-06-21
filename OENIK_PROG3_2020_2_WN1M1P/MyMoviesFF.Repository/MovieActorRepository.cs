// <copyright file="MovieActorRepository.cs" company="WN1M1P">
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
    /// This is the repository class for the connector entity between Movies and Actors.
    /// </summary>
    public class MovieActorRepository : ConnRepository<MovieActor>, IMovieActorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieActorRepository"/> class.
        /// </summary>
        /// <param name="ctx">This parameter is the dbcontext class, which is passed to the base class.</param>
        /// <param name="actorrepo">Repository of actor.</param>
        /// <param name="movieRepo">Repository of movie.</param>
        public MovieActorRepository(DbContext ctx, IActorRepository actorrepo, IMovieRepository movieRepo)
            : base(ctx)
        {
            this.ActorRepo = actorrepo;
            this.MovieRepo = movieRepo;
        }

        /// <summary>
        /// Gets or sets the Actor Repository.
        /// </summary>
        private IActorRepository ActorRepo { get; set; }

        /// <summary>
        /// Gets or sets the Movie Repository.
        /// </summary>
        private IMovieRepository MovieRepo { get; set; }

        /// <summary>
        /// Gets one specified MovieActor data.
        /// </summary>
        /// <param name="idone">This is the composite id's first part, which indicates the MovieActor.</param>
        /// <param name="idtwo">This is the composite id's second part, which indicates the MovieActor.</param>
        /// <returns>Returns a specified MovieActor data.</returns>
        public override MovieActor GetOne(int idone, int idtwo)
        {
            return this.GetAll().SingleOrDefault(i => i.MovieId == idone && i.ActorId == idtwo);
        }

        /// <summary>
        /// Insert a new MovieActor data to the database.
        /// </summary>
        /// <param name="entity">This is the MovieActor data, which should be added.</param>
        public override void Insert(MovieActor entity)
        {
            (this.ctx as MovieDbContext).MovieActors.Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Removes an MovieActor data from the database.
        /// </summary>
        /// <param name="entity">Specifies which MovieActor should be removed.</param>
        /// <returns>Returns whether the MovieActor was successfully removed or not from the database.</returns>
        public override bool Remove(MovieActor entity)
        {
            if (entity != null && this.GetOne(entity.MovieId, entity.ActorId) != null)
            {
                (this.ctx as MovieDbContext).MovieActors.Remove(entity);
                this.ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public void AddActor(int movieid, int actorid)
        {
            var movie = this.MovieRepo.GetOne(movieid);
            if (movie != null)
            {
                MovieActor movieActor = new MovieActor()
                {
                    Actor = this.ActorRepo.GetOne(actorid),
                    Movie = movie,
                    MovieId = movie.MovieId,
                    ActorId = this.ActorRepo.GetOne(actorid).ActorId,
                };
                (this.ctx as MovieDbContext).MovieActors.Add(movieActor);
                this.ctx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Object not found!");
            }
        }

        /// <inheritdoc/>
        public void RemoveActor(int movieid, int actorid)
        {
            var movie = this.MovieRepo.GetOne(movieid);
            if (movie != null && movie.MovieActors.Where(i => i.ActorId == actorid).Any())
            {
                var newmov = movie.MovieActors.Where(i => i.ActorId == actorid).FirstOrDefault();
                (this.ctx as MovieDbContext).MovieActors.Remove(newmov);
                this.ctx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Object not found!");
            }
        }
    }
}
