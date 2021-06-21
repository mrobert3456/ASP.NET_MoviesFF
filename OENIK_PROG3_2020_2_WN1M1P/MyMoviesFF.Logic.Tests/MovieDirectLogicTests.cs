// <copyright file="MovieDirectLogicTests.cs" company="WN1M1P">
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
    /// Contains MovieDirectLogic method's tests.
    /// </summary>
    [TestFixture]
    public class MovieDirectLogicTests
    {
        /// <summary>
        /// Test the ChangeIMDB method from MovieDirectLogic.
        /// </summary>
        [Test]
        public void TestChangeIMDB()
        {
            Mock<IDirectorRepository> mockedDirRepo = new Mock<IDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieDirectorRepository> mockedmoviedirRepo = new Mock<IMovieDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            MovieDirectLogic movieDirectLogic = new MovieDirectLogic(mockedmovieRepo.Object, mockedDirRepo.Object, mockedmoviedirRepo.Object);

            mockedmovieRepo.Setup(i => i.ChangeIMDB(1, 8));
            movieDirectLogic.ChangeIMDB(1, 8);
            mockedmovieRepo.Verify(i => i.ChangeIMDB(1, 8), Times.Once);
        }

        /// <summary>
        /// Test the RemoveDirector method from MovieDirectLogic.
        /// </summary>
        [Test]
        public void TestRemoveDirector()
        {
            Mock<IDirectorRepository> mockedDirRepo = new Mock<IDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieDirectorRepository> mockedmoviedirRepo = new Mock<IMovieDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            MovieDirectLogic movieDirectLogic = new MovieDirectLogic(mockedmovieRepo.Object, mockedDirRepo.Object, mockedmoviedirRepo.Object);

            Director director = new Director()
            {
                DirectorId = 1,
            };

            mockedDirRepo.Setup(i => i.Remove(director)).Returns(It.IsAny<bool>());
            movieDirectLogic.RemoveDirector(director);
            mockedDirRepo.Verify(i => i.Remove(director), Times.Once);
        }

        /// <summary>
        /// Test the GetOneDirector method from MovieDirectLogic.
        /// </summary>
        [Test]
        public void TestGetOneDirector()
        {
            Mock<IDirectorRepository> mockedDirRepo = new Mock<IDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieDirectorRepository> mockedmoviedirRepo = new Mock<IMovieDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            MovieDirectLogic movieDirectLogic = new MovieDirectLogic(mockedmovieRepo.Object, mockedDirRepo.Object, mockedmoviedirRepo.Object);

            Director director = new Director()
            {
                DirectorId = 1,
            };

            mockedDirRepo.Setup(i => i.GetOne(1)).Returns(director);
            movieDirectLogic.GetOneDirector(1);
            mockedDirRepo.Verify(i => i.GetOne(1), Times.Once);
        }

        /// <summary>
        ///  Test the AVGDirectorAge method from MovieDirectLogic.
        /// </summary>
        [Test]
        public void TestAVGDirectorAge()
        {
            Mock<IDirectorRepository> mockedDirRepo = new Mock<IDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieDirectorRepository> mockedmoviedirRepo = new Mock<IMovieDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            MovieDirectLogic movieDirectLogic = new MovieDirectLogic(mockedmovieRepo.Object, mockedDirRepo.Object, mockedmoviedirRepo.Object);

            List<Director> dirs = new List<Director>()
            {
            new Director() { DirectorId = 1, Age = 25 },
            new Director() { DirectorId = 2, Age = 35 },
            new Director() { DirectorId = 3, Age = 45 },
            new Director() { DirectorId = 4, Age = 55 },
            };

            mockedDirRepo.Setup(i => i.GetAll()).Returns(dirs.AsQueryable());
            List<Director> expectedActors = new List<Director>() { dirs[0], dirs[1], dirs[2], dirs[3], };

            double expectedAVG = movieDirectLogic.AVGDirectorAge();
            var result = movieDirectLogic.GetAllDirectors();

            Assert.That(result, Is.EquivalentTo(expectedActors));
            Assert.That(expectedAVG, Is.EqualTo(40));

            mockedDirRepo.Verify(i => i.GetAll(), Times.Exactly(2));
            mockedmovieRepo.Verify(i => i.GetAll(), Times.Never);
            mockedmoviedirRepo.Verify(i => i.GetAll(), Times.Never);
        }

        /// <summary>
        /// Test the GetDirectorCountPerCountries method from MovieDirectLogic.
        /// </summary>
        [Test]
        public void TestGetDirectorCountPerCountries()
        {
            Mock<IDirectorRepository> mockedDirRepo = new Mock<IDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieDirectorRepository> mockedmoviedirRepo = new Mock<IMovieDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            MovieDirectLogic movieDirectLogic = new MovieDirectLogic(mockedmovieRepo.Object, mockedDirRepo.Object, mockedmoviedirRepo.Object);

            List<Director> dirs = new List<Director>()
            {
            new Director() { DirectorId = 1, Country = "MO" },
            new Director() { DirectorId = 2, Country = "HO" },
            new Director() { DirectorId = 3, Country = "HO" },
            new Director() { DirectorId = 4, Country = "MO" },
            };

            List<DirectorsCountPerCountries> expectedres = new List<DirectorsCountPerCountries>()
            {
            new DirectorsCountPerCountries() { Country = "HO", Count = 2 },
            new DirectorsCountPerCountries() { Country = "MO", Count = 2 },
            };

            mockedDirRepo.Setup(i => i.GetAll()).Returns(dirs.AsQueryable());

            var result = movieDirectLogic.GetDirectorCountPerCountries();

            Assert.That(result, Is.EquivalentTo(expectedres));
            mockedDirRepo.Verify(i => i.GetAll(), Times.Once);
            mockedmovieRepo.Verify(i => i.GetAll(), Times.Never);
            mockedmoviedirRepo.Verify(i => i.GetAll(), Times.Never);
        }

        /// <summary>
        /// Test the GetActorsPerMovies method from ActingLogic.
        /// </summary>
        [Test]
        public void TestGetMoviesPerDirectors()
        {
            Mock<IDirectorRepository> mockedDirRepo = new Mock<IDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieDirectorRepository> mockedmoviedirRepo = new Mock<IMovieDirectorRepository>(MockBehavior.Loose);
            Mock<IMovieRepository> mockedmovieRepo = new Mock<IMovieRepository>(MockBehavior.Loose);

            MovieDirectLogic movieDirectLogic = new MovieDirectLogic(mockedmovieRepo.Object, mockedDirRepo.Object, mockedmoviedirRepo.Object);

            List<MovieDirector> movieDirect = new List<MovieDirector>()
            {
            new MovieDirector() { MovieId = 1, DirectorId = 1 },
            new MovieDirector() { MovieId = 2, DirectorId = 2 },
            new MovieDirector() { MovieId = 3, DirectorId = 3 },
            new MovieDirector() { MovieId = 4, DirectorId = 1 },
            };

            List<Movie> movies = new List<Movie>()
            {
                new Movie() { Title = "Avengers", MovieId = 1 },
                new Movie() { Title = "Boy", MovieId = 2 },
                new Movie() { Title = "The Elevator", MovieId = 3 },
                new Movie() { Title = "John Wick",  MovieId = 4 },
            };

            List<Director> directors = new List<Director>()
            {
            new Director() { DirectorId = 1, DirectorName = "Jani" },
            new Director() { DirectorId = 2, DirectorName = "Laci" },
            new Director() { DirectorId = 3, DirectorName = "Marcsi" },
            new Director() { DirectorId = 4, DirectorName = "Balázs" },
            };
            List<MoviesPerDirectors> expectedres = new List<MoviesPerDirectors>()
            {
             new MoviesPerDirectors()
            {
                DirectorName = "Jani", Movies = new List<Movie>()
             {
               new Movie() { Title = "Avengers", MovieId = 1 },
               new Movie() { Title = "John Wick",  MovieId = 4 },
             },
            },
             new MoviesPerDirectors()
            {
                DirectorName = "Laci", Movies = new List<Movie>()
             {
                   new Movie() { Title = "Boy", MovieId = 2 },
             },
            },
             new MoviesPerDirectors()
            {
                DirectorName = "Marcsi", Movies = new List<Movie>()
             {
                new Movie() { Title = "The Elevator", MovieId = 3 },
             },
            },
            };

            mockedmovieRepo.Setup(i => i.GetAll()).Returns(movies.AsQueryable());
            mockedDirRepo.Setup(i => i.GetAll()).Returns(directors.AsQueryable());
            mockedmoviedirRepo.Setup(i => i.GetAll()).Returns(movieDirect.AsQueryable());

            var result = movieDirectLogic.GetMoviesPerDirectors();
            Assert.That(result, Is.EquivalentTo(expectedres));
            mockedmovieRepo.Verify(i => i.GetAll(), Times.Exactly(1));
            mockedmoviedirRepo.Verify(i => i.GetAll(), Times.Exactly(1));
            mockedDirRepo.Verify(i => i.GetAll(), Times.Exactly(1));
        }
    }
}
