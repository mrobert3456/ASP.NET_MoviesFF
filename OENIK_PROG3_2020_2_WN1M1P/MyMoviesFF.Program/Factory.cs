// <copyright file="Factory.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;
    using MyMoviesFF.Logic;
    using MyMoviesFF.Repository;

    /// <summary>
    /// Instanciates new classes.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Instanciate new MovieDbContext.
        /// </summary>
        /// <returns>Returns new MovieDbContext.</returns>
        public static MovieDbContext CreateMovieDbContext()
        {
            return new MovieDbContext();
        }

        /// <summary>
        ///  Instanciate new MovieRepository.
        /// </summary>
        /// <param name="ctx">This parameter is the MovieDbContext class, which will be used by MovieRepository object.</param>
        /// <param name="actorRepository">Repository of actor.</param>
        /// <param name="directorRepository">Repository of director.</param>
        /// <returns>Returns new MovieRepository.</returns>
        public static MovieRepository CreateMovieRepository(MovieDbContext ctx, ActorRepository actorRepository, DirectorRepository directorRepository)
        {
            return new MovieRepository(ctx, actorRepository, directorRepository);
        }

        /// <summary>
        ///  Instanciate new ActorRepository.
        /// </summary>
        /// <param name="ctx">This parameter is the MovieDbContext class, which will be used by ActorRepository object.</param>
        /// <returns>Returns new ActorRepository.</returns>
        public static ActorRepository CreateActorRepository(MovieDbContext ctx)
        {
            return new ActorRepository(ctx);
        }

        /// <summary>
        ///  Instanciate new DirectorRepository.
        /// </summary>
        /// <param name="ctx">This parameter is the MovieDbContext class, which will be used by DirectorRepository object.</param>
        /// <returns>Returns new DirectorRepository.</returns>
        public static DirectorRepository CreateDirectorRepository(MovieDbContext ctx)
        {
            return new DirectorRepository(ctx);
        }

        /// <summary>
        ///  Instanciate new ActingLogic.
        /// </summary>
        /// <param name="movierepo">Repository of movie.</param>
        /// <param name="actorrepo">Repository of actor.</param>
        /// <param name="movieActorRepo">Repository of movieactor.</param>
        /// <returns>Returns new ActingLogic.</returns>
        public static ActingLogic CreateActingLogic(MovieRepository movierepo, ActorRepository actorrepo, MovieActorRepository movieActorRepo)
        {
            return new ActingLogic(movierepo, actorrepo, movieActorRepo);
        }

        /// <summary>
        /// Instanciate new MovieDirectLogic.
        /// </summary>
        /// <param name="movierepo">Repository of movie.</param>
        /// <param name="directorrepo">Repository of director.</param>
        /// <param name="moviedirrepo">Repository of moviedirector.</param>
        /// <returns>Returns new MovieDirectLogic.</returns>
        public static MovieDirectLogic CreateMovieDirectLogic(MovieRepository movierepo, DirectorRepository directorrepo, MovieDirectorRepository moviedirrepo)
        {
            return new MovieDirectLogic(movierepo, directorrepo, moviedirrepo);
        }

        /// <summary>
        /// Instanciate new MovieMakeLogic.
        /// </summary>
        /// <param name="movierepo">Repository of movie.</param>
        /// <param name="movieActor">Repository of movieactor.</param>
        /// <param name="movieDirector">Repository of moviedirector.</param>
        /// <returns>Returns new MovieMakeLogic.</returns>
        public static MovieMakeLogic CreateMovieMakeLogic(MovieRepository movierepo, MovieActorRepository movieActor, MovieDirectorRepository movieDirector)
        {
            return new MovieMakeLogic(movierepo, movieActor, movieDirector);
        }

        /// <summary>
        /// Instanciate new MovieActorRepository.
        /// </summary>
        /// <param name="ctx">This parameter is the MovieDbContext class, which will be used by MovieActorRepository object.</param>
        /// <param name="actorrepo">Repository of actor.</param>
        /// <param name="movierepo">Repository of movie.</param>
        /// <returns>Returns new MovieActorRepository.</returns>
        public static MovieActorRepository CreateMovieActorRepository(MovieDbContext ctx, ActorRepository actorrepo, MovieRepository movierepo)
        {
            return new MovieActorRepository(ctx, actorrepo, movierepo);
        }

        /// <summary>
        /// Instanciate new MovieDirectorRepository.
        /// </summary>
        /// <param name="ctx">This parameter is the MovieDbContext class, which will be used by MovieDirectorRepository object.</param>
        /// <param name="directorRepo">Repository of director.</param>
        /// <param name="movierepo">Repository of movie.</param>
        /// <returns>Returns new MovieDirectorRepository.</returns>
        public static MovieDirectorRepository CreateMovieDirectorRepository(MovieDbContext ctx, DirectorRepository directorRepo, MovieRepository movierepo)
        {
            return new MovieDirectorRepository(ctx, directorRepo, movierepo);
        }
    }
}
