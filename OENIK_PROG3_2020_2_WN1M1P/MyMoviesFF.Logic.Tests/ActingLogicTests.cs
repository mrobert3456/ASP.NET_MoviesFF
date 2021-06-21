// <copyright file="ActingLogicTests.cs" company="WN1M1P">
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
    /// Contains the ActingLogic method' tests.
    /// </summary>
    [TestFixture]
    public class ActingLogicTests
    {
        /// <summary>
        /// Test the GetOneActor method from ActingLogic.
        /// </summary>
        [Test]
        public void TestAddActor()
        {
            Mock<IActorRepository> mockedActorRepo = new Mock<IActorRepository>(MockBehavior.Loose);
            Mock<IMovieActorRepository> mockedmovieactorRepo = new Mock<IMovieActorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            Actor actor = new Actor()
            {
                ActorName = "Charles",
                Gender = true,
                MovieCount = 10,
                Age = 40,
                Country = "USA",
            };

            ActingLogic actingLogic = new ActingLogic(mockedmovieRepo.Object, mockedActorRepo.Object, mockedmovieactorRepo.Object);
            mockedActorRepo.Setup(i => i.Insert(It.IsAny<Actor>()));

            actingLogic.InsertNewActor(actor.ActorName, actor.Gender, actor.Age, actor.MovieCount, actor.Country);

            mockedActorRepo.Verify(i => i.Insert(It.IsAny<Actor>()), Times.Once);
            mockedActorRepo.Verify(i => i.Insert(actor), Times.Once);
        }

        /// <summary>
        /// Test the GetAllMovies method from ActingLogic.
        /// </summary>
        [Test]
        public void TestGetAllMovies()
        {
            Mock<IActorRepository> mockedActorRepo = new Mock<IActorRepository>(MockBehavior.Loose);
            Mock<IMovieActorRepository> mockedmovieactorRepo = new Mock<IMovieActorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            ActingLogic actingLogic = new ActingLogic(mockedmovieRepo.Object, mockedActorRepo.Object, mockedmovieactorRepo.Object);

            List<Movie> movies = new List<Movie>()
            {
                new Movie() { Title = "Avengers", Year = 2018 },
                new Movie() { Title = "Boy", Year = 2017 },
                new Movie() { Title = "The Elevator", Year = 2015 },
                new Movie() { Title = "John Wick", Year = 2014 },
            };

            mockedmovieRepo.Setup(i => i.GetAll()).Returns(movies.AsQueryable());
            var result = actingLogic.GetAllMovies();

            mockedmovieRepo.Verify(i => i.GetAll(), Times.Once);
            mockedmovieactorRepo.Verify(i => i.GetAll(), Times.Never);
            mockedActorRepo.Verify(i => i.GetAll(), Times.Never);
        }

        /// <summary>
        ///  Test the AVGActorAge method from ActingLogic.
        /// </summary>
        [Test]
        public void TestAVGActorAge()
        {
            Mock<IActorRepository> mockedActorRepo = new Mock<IActorRepository>(MockBehavior.Loose);
            Mock<IMovieActorRepository> mockedmovieactorRepo = new Mock<IMovieActorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            ActingLogic actingLogic = new ActingLogic(mockedmovieRepo.Object, mockedActorRepo.Object, mockedmovieactorRepo.Object);

            List<Actor> actors = new List<Actor>()
            {
            new Actor() { ActorId = 1, Age = 20 },
            new Actor() { ActorId = 2, Age = 30 },
            new Actor() { ActorId = 3, Age = 40 },
            new Actor() { ActorId = 4, Age = 50 },
            };

            mockedActorRepo.Setup(i => i.GetAll()).Returns(actors.AsQueryable());
            List<Actor> expectedActors = new List<Actor>() { actors[0], actors[1], actors[2], actors[3], };

            double expectedAVG = actingLogic.AVGActorAge();
            var result = actingLogic.GetAllActors();

            Assert.That(result, Is.EquivalentTo(expectedActors));
            Assert.That(expectedAVG, Is.EqualTo(35));

            mockedActorRepo.Verify(i => i.GetAll(), Times.Exactly(2));
            mockedmovieactorRepo.Verify(i => i.GetAll(), Times.Never);
            mockedmovieRepo.Verify(i => i.GetAll(), Times.Never);
        }

        /// <summary>
        /// Test the GetActorCountPerCountries method from ActingLogic.
        /// </summary>
        [Test]
        public void TestGetActorCountPerCountries()
        {
            Mock<IActorRepository> mockedActorRepo = new Mock<IActorRepository>(MockBehavior.Loose);
            Mock<IMovieActorRepository> mockedmovieactorRepo = new Mock<IMovieActorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            ActingLogic actingLogic = new ActingLogic(mockedmovieRepo.Object, mockedActorRepo.Object, mockedmovieactorRepo.Object);

            List<Actor> actors = new List<Actor>()
            {
            new Actor() { ActorId = 1, Country = "USA" },
            new Actor() { ActorId = 2, Country = "MO" },
            new Actor() { ActorId = 3, Country = "RO" },
            new Actor() { ActorId = 4, Country = "USA" },
            };
            List<ActorCountPerCountries> expectedres = new List<ActorCountPerCountries>()
            {
            new ActorCountPerCountries() { Country = "USA", Count = 2 },
            new ActorCountPerCountries() { Country = "MO", Count = 1 },
            new ActorCountPerCountries() { Country = "RO", Count = 1 },
            };

            mockedActorRepo.Setup(i => i.GetAll()).Returns(actors.AsQueryable());

            var result = actingLogic.GetActorCountPerCountries();

            Assert.That(result, Is.EquivalentTo(expectedres));
            mockedActorRepo.Verify(i => i.GetAll(), Times.Once);
            mockedmovieactorRepo.Verify(i => i.GetAll(), Times.Never);
            mockedmovieRepo.Verify(i => i.GetAll(), Times.Never);
        }

        /// <summary>
        /// Test the GetActorsPerMovies method from ActingLogic.
        /// </summary>
        [Test]
        public void TestGetActorsPerMovies()
        {
            Mock<IActorRepository> mockedActorRepo = new Mock<IActorRepository>(MockBehavior.Loose);
            Mock<IMovieActorRepository> mockedmovieactorRepo = new Mock<IMovieActorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            ActingLogic actingLogic = new ActingLogic(mockedmovieRepo.Object, mockedActorRepo.Object, mockedmovieactorRepo.Object);

            List<MovieActor> movieActors = new List<MovieActor>()
            {
            new MovieActor() { MovieId = 1, ActorId = 1 },
            new MovieActor() { MovieId = 2, ActorId = 2 },
            new MovieActor() { MovieId = 2, ActorId = 3 },
            new MovieActor() { MovieId = 4, ActorId = 4 },
            };

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
            List<ActorsPerMovies> expectedres = new List<ActorsPerMovies>()
            {
             new ActorsPerMovies()
            {
                Title = "Boy", Actors = new List<Actor>()
             {
               new Actor() { ActorId = 2, ActorName = "Laci" },
               new Actor() { ActorId = 3, ActorName = "Marcsi" },
             },
            },
             new ActorsPerMovies()
            {
                Title = "Avengers", Actors = new List<Actor>()
             {
                 new Actor() { ActorId = 1, ActorName = "Jani" },
             },
            },
             new ActorsPerMovies()
            {
                Title = "John Wick", Actors = new List<Actor>()
             {
                new Actor() { ActorId = 4, ActorName = "Balázs" },
             },
            },
            };

            mockedmovieRepo.Setup(i => i.GetAll()).Returns(movies.AsQueryable());
            mockedmovieactorRepo.Setup(i => i.GetAll()).Returns(movieActors.AsQueryable());
            mockedActorRepo.Setup(i => i.GetAll()).Returns(actors.AsQueryable());
            var result = actingLogic.GetActorsPerMovies();
            Assert.That(result, Is.EquivalentTo(expectedres));
            mockedmovieRepo.Verify(i => i.GetAll(), Times.Exactly(1));
            mockedmovieactorRepo.Verify(i => i.GetAll(), Times.Exactly(1));
            mockedActorRepo.Verify(i => i.GetAll(), Times.Exactly(1));
        }
    }
}
