// <copyright file="ActingLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using Microsoft.Extensions.Caching.Memory;
    using MyMoviesFF.Data;
    using MyMoviesFF.Repository;

    /// <summary>
    /// Implements the crud and non-crud methods from IActingLogic interface.
    /// </summary>
    public class ActingLogic : MovieMethods, IActingLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActingLogic"/> class.
        /// </summary>
        /// <param name="movierepo">Repository of movie.</param>
        /// <param name="actorrepo">Repository of actor.</param>
        /// <param name="movieActorRepo">Repository of movieactor.</param>
        public ActingLogic(IMovieRepository movierepo, IActorRepository actorrepo, IMovieActorRepository movieActorRepo)
            : base(movierepo)
        {
            this.ActorRepo = actorrepo;
            this.MovieActorRepo = movieActorRepo;
            this.MovieRepo = movierepo;
        }

        /// <summary>
        /// Gets or sets the Actor Repository.
        /// </summary>
        private IActorRepository ActorRepo { get; set; }

        /// <summary>
        /// Gets or sets the MovieActor Repository.
        /// </summary>
        private IMovieActorRepository MovieActorRepo { get; set; }

        /// <summary>
        /// Gets or sets the Movie Repository.
        /// </summary>
        private IMovieRepository MovieRepo { get; set; }

        /// <summary>
        /// Determine the avarage age among actors.
        /// </summary>
        /// <returns>Returns a double of the avarage age among actors.</returns>
        public double AVGActorAge()
        {
            return this.GetAllActors().Average(i => i.Age);
        }

        /// <summary>
        /// This method changes the age of actor.
        /// </summary>
        /// <param name="id">This is the actors id.</param>
        /// <param name="newage">This is the age, which will be the new age of an actor.</param>
        public void ChangeAge(int id, int newage)
        {
            this.ActorRepo.ChangeAge(id, newage);
        }

        /// <summary>
        /// Changes an Actor.
        /// </summary>
        /// <param name="id">Actor's id.</param>
        /// <param name="name">Actor's name.</param>
        /// <param name="gender">Actor's gender.</param>
        /// <param name="age">Actor's age.</param>
        /// <param name="country">Actor's country.</param>
        /// <returns>Return whether the change was successfull or not.</returns>
        public bool ChangeActor(int id, string name, bool gender, int age, string country)
        {
            return this.ActorRepo.ChangeActor(id, name, gender, age, country);
        }

        /// <summary>
        /// Determine how many actors living per country.
        /// </summary>
        /// <returns>Returns a IList collection of ActorCountPerCountries.</returns>
        public IList<ActorCountPerCountries> GetActorCountPerCountries()
        {
            var q = from item in this.ActorRepo.GetAll()
                    group item by item.Country into g
                    select new ActorCountPerCountries()
                    {
                        Country = g.Key,
                        Count = g.Count(),
                    };
            return q.ToList();
        }

        /// <summary>
        ///  Async version of GetActorCountPerCountries.
        /// </summary>
        /// <returns>Returns an Task IList collection of ActorCountPerCountries.</returns>
        public Task<IList<ActorCountPerCountries>> GetActorCountPerCountriesAsync()
        {
            return Task<IList<ActorCountPerCountries>>.Factory.StartNew(this.GetActorCountPerCountries);
        }

        /// <summary>
        /// Gets all actors from the database.
        /// </summary>
        /// <returns>Returns an IList collection of actors.</returns>
        public IList<Actor> GetAllActors()
        {
            return this.ActorRepo.GetAll().ToList();
        }

        /// <summary>
        /// Gets one actor.
        /// </summary>
        /// <param name="id">Specifies the actor id.</param>
        /// <returns>Returns an actor object.</returns>
        public Actor GetOneActor(int id)
        {
            return this.ActorRepo.GetOne(id);
        }

        /// <summary>
        ///  Insert a new actor to the database.
        /// </summary>
        /// <param name="actorname">Actor's name.</param>
        /// <param name="gender">Actor's gender.</param>
        /// <param name="age">Actor's age.</param>
        /// <param name="moviecount">How many movies had the actor.</param>
        /// <param name="country">Actor's birthplace.</param>
        public void InsertNewActor(string actorname, bool gender, int age, int moviecount, string country)
        {
            Actor actor = new Actor()
            {
                ActorName = actorname,
                Gender = gender,
                Age = age,
                MovieCount = moviecount,
                Country = country,
            };
            this.ActorRepo.Insert(actor);
        }

        /// <summary>
        /// Removes an actor from the database.
        /// </summary>
        /// <param name="entity">Specifies which actor should be removed.</param>
        /// <returns>Returns a bool whether the actor was successfully removed or not from the database.</returns>
        public bool RemoveActor(Actor entity)
        {
            return this.ActorRepo.Remove(entity);
        }

        /// <summary>
        /// Gets the movies and the actors who played in them.
        /// </summary>
        /// <returns>IList collection of ActorsPerMovies.</returns>
        public IList<ActorsPerMovies> GetActorsPerMovies()
        {
            var subquery = from movie in this.MovieRepo.GetAll()
                           join conn in this.MovieActorRepo.GetAll()
                           on movie.MovieId equals conn.MovieId
                           join actor in this.ActorRepo.GetAll()
                           on conn.ActorId equals actor.ActorId
                           select new
                           {
                               movie.Title,
                               actor,
                           };
            var res = from item in subquery.ToList()
                      group item by item.Title into g
                      select new ActorsPerMovies
                      {
                          Title = g.Key,
                          Actors = g.Select(i => i.actor),
                      };

            return res.ToList();
        }

        /// <summary>
        /// Async version of GetActorsPerMovies method.
        /// </summary>
        /// <returns>Returns a Task IList collection of ActorsPerMovies.</returns>
        public Task<IList<ActorsPerMovies>> GetActorsPerMoviesAsync()
        {
            return Task<IList<ActorsPerMovies>>.Factory.StartNew(this.GetActorsPerMovies);
        }
    }
}
