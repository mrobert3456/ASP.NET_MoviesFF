// <copyright file="MovieDirectLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
    using MyMoviesFF.Data;
    using MyMoviesFF.Repository;

    /// <summary>
    /// Implements the crud and non-crud methods from IMovieDirectLogic interface.
    /// </summary>
    public class MovieDirectLogic : MovieMethods, IMovieDirectLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieDirectLogic"/> class.
        /// </summary>
        /// <param name="movierepo">Repository of movie.</param>
        /// <param name="directorrepo">Repository of director.</param>
        /// <param name="moviedirrepo">Repository of moviedirector.</param>
        public MovieDirectLogic(IMovieRepository movierepo, IDirectorRepository directorrepo, IMovieDirectorRepository moviedirrepo)
            : base(movierepo)
        {
            this.DirectorRepo = directorrepo;
            this.MovieDirectRepo = moviedirrepo;
            this.MovieRepo = movierepo;
        }

        /// <summary>
        /// Gets or sets the Director Repository.
        /// </summary>
        private IDirectorRepository DirectorRepo { get; set; }

        /// <summary>
        /// Gets or sets the MovieDirectorRepository Repository.
        /// </summary>
        private IMovieDirectorRepository MovieDirectRepo { get; set; }

        /// <summary>
        /// Gets or sets the Movie Repository.
        /// </summary>
        private IMovieRepository MovieRepo { get; set; }

        /// <summary>
        /// Calculate the avarage age of the directors.
        /// </summary>
        /// <returns>Returns a double variable, which will be the avarage age of the directors.</returns>
        public double AVGDirectorAge()
        {
            return this.DirectorRepo.GetAll().Average(i => i.Age);
        }

        /// <summary>
        /// This method changes the birth country of the actor.
        /// </summary>
        /// <param name="id">This is the directors id.</param>
        /// <param name="newcountry">This is the birth country, which will be the new birth country of the director.</param>
        public void ChangeCountry(int id, string newcountry)
        {
            this.DirectorRepo.ChangeCountry(id, newcountry);
        }

        /// <summary>
        /// Gets all directors from the database.
        /// </summary>
        /// <returns>Returns an IList collection of directors.</returns>
        public IList<Director> GetAllDirectors()
        {
            return this.DirectorRepo.GetAll().ToList();
        }

        /// <summary>
        /// Gets how many directors living in every country stored in the database.
        /// </summary>
        /// <returns>Returns an DirectorsCountPerCountries collection of the statistic.</returns>
        public IList<DirectorsCountPerCountries> GetDirectorCountPerCountries()
        {
            List<DirectorsCountPerCountries> list = new List<DirectorsCountPerCountries>();

            var q = from item in this.DirectorRepo.GetAll()
                    group item by item.Country into g
                    select new DirectorsCountPerCountries()
                    {
                        Country = g.Key,
                        Count = g.Count(),
                    };

            foreach (var item in q)
            {
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        ///  Async version of GetDirectorCountPerCountries method.
        /// </summary>
        /// <returns>Returns an Task IList collection of DirectorsCountPerCountries.</returns>
        public Task<IList<DirectorsCountPerCountries>> GetDirectorCountPerCountriesAsync()
        {
            return Task<IList<DirectorsCountPerCountries>>.Factory.StartNew(this.GetDirectorCountPerCountries);
        }

        /// <summary>
        /// Gets one specified director.
        /// </summary>
        /// <param name="id">This is the id, which indicates the director.</param>
        /// <returns> Returns a specified director.</returns>
        public Director GetOneDirector(int id)
        {
            return this.DirectorRepo.GetOne(id);
        }

        /// <summary>
        /// Insert a new director to the database.
        /// </summary>
        /// <param name="directorName">Director name.</param>
        /// <param name="movieCount">How many movies were directed by this director.</param>
        /// <param name="gender">Director's gender.</param>
        /// <param name="country">Director's birthplace.</param>
        /// <param name="age">Director's age.</param>
        public void InsertNewDirector(string directorName, int movieCount, bool gender, string country, int age)
        {
            Director director = new Director()
            {
                DirectorName = directorName,
                MovieCount = movieCount,
                Gender = gender,
                Country = country,
                Age = age,
            };
            this.DirectorRepo.Insert(director);
        }

        /// <summary>
        /// Removes a director from the database.
        /// </summary>
        /// <param name="entity">Specifies which director should be removed.</param>
        /// <returns>Returns a bool whether the actor was successfully removed or not from the database.</returns>
        public bool RemoveDirector(Director entity)
        {
            return this.DirectorRepo.Remove(entity);
        }

        /// <summary>
        /// Gets the directors and his/her movies.
        /// </summary>
        /// <returns>IList collection of MoviesPerDirectors.</returns>
        public IList<MoviesPerDirectors> GetMoviesPerDirectors()
        {
            var subq = from movie in this.MovieRepo.GetAll()
                       join conn in this.MovieDirectRepo.GetAll() on movie.MovieId equals conn.MovieId
                       join dir in this.DirectorRepo.GetAll() on conn.DirectorId equals dir.DirectorId
                       select new { movie, dir.DirectorName };

            var res = from item in subq.ToList()
                      group item by item.DirectorName into g
                      select new MoviesPerDirectors
                      {
                          DirectorName = g.Key,
                          Movies = g.Select(x => x.movie),
                      };
            return res.ToList();
        }

        /// <summary>
        /// Async version of GetMoviesPerDirectors method.
        /// </summary>
        /// <returns>Returns a Task IList collection of MoviesPerDirectors.</returns>
        public Task<IList<MoviesPerDirectors>> GetMoviesPerDirectorsAsync()
        {
            return Task<IList<MoviesPerDirectors>>.Factory.StartNew(this.GetMoviesPerDirectors);
        }
    }
}
