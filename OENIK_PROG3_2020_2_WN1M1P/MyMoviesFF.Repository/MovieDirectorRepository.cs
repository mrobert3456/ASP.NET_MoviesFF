// <copyright file="MovieDirectorRepository.cs" company="WN1M1P">
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
    /// This is the repository class for the connector entity between Movies and Directors.
    /// </summary>
    public class MovieDirectorRepository : ConnRepository<MovieDirector>, IMovieDirectorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieDirectorRepository"/> class.
        /// </summary>
        /// <param name="ctx">This parameter is the dbcontext class, which is passed to the base class.</param>
        /// <param name="directorRepo">Repository of director.</param>
        /// <param name="movieRepo">Repository of movie.</param>
        public MovieDirectorRepository(DbContext ctx, IDirectorRepository directorRepo, IMovieRepository movieRepo)
            : base(ctx)
        {
            this.DirectorRepo = directorRepo;
            this.MovieRepo = movieRepo;
        }

        /// <summary>
        /// Gets or sets the Director repository.
        /// </summary>
        private IDirectorRepository DirectorRepo { get; set; }

        /// <summary>
        /// Gets or sets the Movie Repository.
        /// </summary>
        private IMovieRepository MovieRepo { get; set; }

        /// <summary>
        /// Gets one specified MovieDirector data.
        /// </summary>
        /// <param name="idone">This is the composite id's first part, which indicates the MovieDirector.</param>
        /// <param name="idtwo">This is the composite id's second part, which indicates the MovieDirector.</param>
        /// <returns>Returns a specified MovieDirector data.</returns>
        public override MovieDirector GetOne(int idone, int idtwo)
        {
            return this.GetAll().SingleOrDefault(i => i.MovieId == idone && i.DirectorId == idtwo);
        }

        /// <summary>
        /// Insert a new MovieDirector data to the database.
        /// </summary>
        /// <param name="entity">This is the MovieDirector data, which should be added.</param>
        public override void Insert(MovieDirector entity)
        {
            (this.ctx as MovieDbContext).MovieDirectors.Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        ///  Removes an MovieDirector data from the database.
        /// </summary>
        /// <param name="entity">Specifies which MovieDirector should be removed.</param>
        /// <returns>Returns whether the MovieDirector was successfully removed or not from the database.</returns>
        public override bool Remove(MovieDirector entity)
        {
            if (entity != null && this.GetOne(entity.MovieId, entity.DirectorId) != null)
            {
                (this.ctx as MovieDbContext).MovieDirectors.Remove(entity);
                this.ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public void AddDirector(int movieid, int directorid)
        {
            var movie = this.MovieRepo.GetOne(movieid);
            if (movie != null)
            {
                MovieDirector movieDirector = new MovieDirector()
                {
                    Director = this.DirectorRepo.GetOne(directorid),
                    Movie = movie,
                    MovieId = movie.MovieId,
                    DirectorId = this.DirectorRepo.GetOne(directorid).DirectorId,
                };
                (this.ctx as MovieDbContext).MovieDirectors.Add(movieDirector);
                this.ctx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Object not found!");
            }
        }

        /// <inheritdoc/>
        public void RemoveDirector(int movieid, int directorid)
        {
            var movie = this.MovieRepo.GetOne(movieid);
            if (movie != null && movie.MovieDirectors.Where(i => i.DirectorId == directorid).Any())
            {
                var newmov = movie.MovieDirectors.Where(i => i.DirectorId == directorid).FirstOrDefault();
                (this.ctx as MovieDbContext).MovieDirectors.Remove(newmov);
                this.ctx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Object not found!");
            }
        }
    }
}
