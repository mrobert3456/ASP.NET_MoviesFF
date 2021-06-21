// <copyright file="IActingLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// Describe the logic between actors and movies.
    /// </summary>
    public interface IActingLogic : IMovieMethods
    {
        /// <summary>
        /// Gets one actor.
        /// </summary>
        /// <param name="id">Specifies the actor id.</param>
        /// <returns>Returns an actor object.</returns>
        Actor GetOneActor(int id);

        /// <summary>
        /// Gets all actors from the database.
        /// </summary>
        /// <returns>Returns an IList collection of actors.</returns>
        IList<Actor> GetAllActors();

        /// <summary>
        /// Changes the age of a specified actor object.
        /// </summary>
        /// <param name="id">Specifies the actor object.</param>
        /// <param name="newage">This is the age, which will be the new age of an actor.</param>
        void ChangeAge(int id, int newage);

        /// <summary>
        /// Changes an Actor.
        /// </summary>
        /// <param name="id">Actor's id.</param>
        /// <param name="name">Actor's name.</param>
        /// <param name="gender">Actor's gender.</param>
        /// <param name="age">Actor's age.</param>
        /// <param name="country">Actor's country.</param>
        /// <returns>Return whether the change was successfull or not.</returns>
        public bool ChangeActor(int id, string name, bool gender, int age, string country);

        /// <summary>
        ///  Insert a new actor to the database.
        /// </summary>
        /// <param name="actorname">Actor's name.</param>
        /// <param name="gender">Actor's gender.</param>
        /// <param name="age">Actor's age.</param>
        /// <param name="moviecount">How many movies had the actor.</param>
        /// <param name="country">Actor's birthplace.</param>
        void InsertNewActor(string actorname, bool gender, int age, int moviecount, string country);

        /// <summary>
        /// Removes an actor from the database.
        /// </summary>
        /// <param name="entity">Specifies which actor should be removed.</param>
        /// <returns>Returns whether the actor was successfully removed or not from the database.</returns>
        bool RemoveActor(Actor entity);

        /// <summary>
        /// Calculate the avarage age of the actors.
        /// </summary>
        /// <returns>Returns a double variable, which will be the avarage age of the actors.</returns>
        double AVGActorAge();

        /// <summary>
        /// Gets how many actors living in every country stored in the database.
        /// </summary>
        /// <returns>Return an ActorCountPerCountries collection of the statistic.</returns>
        IList<ActorCountPerCountries> GetActorCountPerCountries();
    }
}
