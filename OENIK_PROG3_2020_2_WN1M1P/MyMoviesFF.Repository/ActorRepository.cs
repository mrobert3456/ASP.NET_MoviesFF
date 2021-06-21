// <copyright file="ActorRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the Repository class for Actor entity.
    /// </summary>
    public class ActorRepository : BaseRepo<Actor>, IActorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActorRepository"/> class.
        /// </summary>
        /// <param name="ctx">This parameter is the dbcontext class, which is passed to the base class.</param>
        public ActorRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This method changes the age of actor.
        /// </summary>
        /// <param name="id">This is the actors id.</param>
        /// <param name="newage">This is the age, which will be the new age of an actor.</param>
        public void ChangeAge(int id, int newage)
        {
            var actor = this.GetOne(id);
            if (actor != null)
            {
                actor.Age = newage;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Object not found!");
            }
        }

        /// <inheritdoc/>
        public bool ChangeActor(int id, string name, bool gender, int age, string country)
        {
            var actor = this.GetOne(id);
            if (actor != null)
            {
                actor.ActorName = name;
                actor.Gender = gender;
                actor.Age = age;
                actor.Country = country;
                this.ctx.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets one specified Actor.
        /// </summary>
        /// <param name="id">This is the id, which indicates the actor.</param>
        /// <returns> Returns a specified actor.</returns>
        public override Actor GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(i => i.ActorId == id);
        }

        /// <summary>
        /// Insert a new actor to the database.
        /// </summary>
        /// <param name="entity">This is the actor, which should be added.</param>
        public override void Insert(Actor entity)
        {
            (this.ctx as MovieDbContext).Actors.Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Removes an actor from the database.
        /// </summary>
        /// <param name="entity">Specifies which actor should be removed.</param>
        /// <returns>Returns whether the actor was successfully removed or not from the database.</returns>
        public override bool Remove(Actor entity)
        {
            if (entity != null && this.GetOne(entity.ActorId) != null)
            {
                (this.ctx as MovieDbContext).Actors.Remove(entity);
                this.ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
