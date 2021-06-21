// <copyright file="MovieMakeLogicTests.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using MyMoviesFF.Data;
    using MyMoviesFF.Repository;
    using NUnit.Framework;

    /// <summary>
    /// Contains MovieMakeLogic method's tests.
    /// </summary>
    [TestFixture]
    public class MovieMakeLogicTests
    {
        /// <summary>
        /// Test the GetActorsDirectorPerMovies method in MovieMakeLogic.
        /// </summary>
        [Test]
        public void TestGetActorsDirectorPerMovies()
        {
            Mock<IMovieRepository> mockedmovRepo = new Mock<IMovieRepository>(MockBehavior.Loose);
            Mock<IMovieActorRepository> mockedmovieactorRepo = new Mock<IMovieActorRepository>(MockBehavior.Loose);
            Mock<IMovieDirectorRepository> mockecmovdirRepo = new Mock<IMovieDirectorRepository>(MockBehavior.Loose);

            MovieMakeLogic movieMakeLogic = new MovieMakeLogic(mockedmovRepo.Object, mockedmovieactorRepo.Object, mockecmovdirRepo.Object);

            List<Movie> movies = new List<Movie>()
            {
                new Movie() { Title = "Avengers", MovieId = 1 },
                new Movie() { Title = "Boy", MovieId = 2 },
                new Movie() { Title = "The Elevator", MovieId = 3 },
                new Movie() { Title = "John Wick",  MovieId = 4 },
            };

            List<Actor> actors = new List<Actor>()
            {
            new Actor() { ActorId = 1, ActorName = "Jani" },
            new Actor() { ActorId = 2, ActorName = "Laci" },
            new Actor() { ActorId = 3, ActorName = "Marcsi" },
            new Actor() { ActorId = 4, ActorName = "Balázs" },
            };

            List<Director> directors = new List<Director>()
            {
            new Director() { DirectorId = 1, DirectorName = "#Director1" },
            new Director() { DirectorId = 2, DirectorName = "#Dircetor2" },
            new Director() { DirectorId = 3, DirectorName = "#Director3" },
            new Director() { DirectorId = 4, DirectorName = "#Director4" },
            };

            List<MovieDirector> movieDirect = new List<MovieDirector>()
            {
            new MovieDirector() { MovieId = 1, DirectorId = 1, Movie = movies[0], Director = directors[0] },
            new MovieDirector() { MovieId = 2, DirectorId = 2, Movie = movies[1], Director = directors[1] },
            new MovieDirector() { MovieId = 3, DirectorId = 3, Movie = movies[2], Director = directors[2] },
            new MovieDirector() { MovieId = 4, DirectorId = 1, Movie = movies[3], Director = directors[0] },
            };

            List<MovieActor> movieActors = new List<MovieActor>()
            {
            new MovieActor() { MovieId = 1, ActorId = 1, Movie = movies[0], Actor = actors[0] },
            new MovieActor() { MovieId = 2, ActorId = 2, Movie = movies[1], Actor = actors[1] },
            new MovieActor() { MovieId = 2, ActorId = 3, Movie = movies[1], Actor = actors[2] },
            new MovieActor() { MovieId = 3, Movie = movies[3], Actor = null },
            new MovieActor() { MovieId = 4, ActorId = 4, Movie = movies[3], Actor = actors[3] },
            };

            List<ActorsDirectorsPerMovies> expectedres = new List<ActorsDirectorsPerMovies>()
            {
             new ActorsDirectorsPerMovies()
             {
                 Title = "Avengers",
                 Actors = new List<Actor>() { new Actor() { ActorId = 1, ActorName = "Jani" } },
                 Directors = new List<Director>() { new Director() { DirectorId = 1, DirectorName = "#Director1" } },
             },
             new ActorsDirectorsPerMovies()
             {
                 Title = "Boy",
                 Actors = new List<Actor>() { new Actor() { ActorId = 2, ActorName = "Laci" },  new Actor() { ActorId = 3, ActorName = "Marcsi" } },
                 Directors = new List<Director>() { new Director() { DirectorId = 2, DirectorName = "#Director2" } },
             },
             new ActorsDirectorsPerMovies()
             {
                 Title = "The Elevator",
                 Actors = new List<Actor>(),
                 Directors = new List<Director>() { new Director() { DirectorId = 3, DirectorName = "#Director3" } },
             },
             new ActorsDirectorsPerMovies()
             {
                 Title = "John Wick",
                 Actors = new List<Actor>() { new Actor() { ActorId = 4, ActorName = "Balázs" } },
                 Directors = new List<Director>() { new Director() { DirectorId = 1, DirectorName = "#Director1" } },
             },
            };

            mockedmovRepo.Setup(i => i.GetAll()).Returns(movies.AsQueryable());
            mockedmovieactorRepo.Setup(i => i.GetAll()).Returns(movieActors.AsQueryable());
            mockecmovdirRepo.Setup(i => i.GetAll()).Returns(movieDirect.AsQueryable());

            var result = movieMakeLogic.GetActorsDirectorPerMovies();

            Assert.That(result, Is.EquivalentTo(expectedres));
            mockedmovRepo.Verify(i => i.GetAll(), Times.Exactly(1));
            mockedmovieactorRepo.Verify(i => i.GetAll(), Times.Exactly(1));
            mockecmovdirRepo.Verify(i => i.GetAll(), Times.Exactly(1));
        }
    }
}
