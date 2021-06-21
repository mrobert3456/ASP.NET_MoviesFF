// <copyright file="IActorRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the interface, which will be used by ActorRepository class.
    /// </summary>
    public interface IActorRepository : IRepository<Actor>
    {
        /// <summary>
        /// This method changes the age of actor.
        /// </summary>
        /// <param name="id">This is the actors id.</param>
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
    }
}
