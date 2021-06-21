// <copyright file="DirectorRepository.cs" company="WN1M1P">
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
    /// This is the Repository class for the directors.
    /// </summary>
    public class DirectorRepository : BaseRepo<Director>, IDirectorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorRepository"/> class.
        /// </summary>
        /// <param name="ctx">This parameter is the dbcontext class, which is passed to the base class.</param>
        public DirectorRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This method changes the birth country of the actor.
        /// </summary>
        /// <param name="id">This is the directors id.</param>
        /// <param name="newcountry">This is the birth country, which will be the new birth country of the director.</param>
        public void ChangeCountry(int id, string newcountry)
        {
            var director = this.GetOne(id);
            if (director != null)
            {
                director.Country = newcountry;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Object not found!");
            }
        }

        /// <summary>
        /// Gets one specified director.
        /// </summary>
        /// <param name="id">This is the id, which indicates the director.</param>
        /// <returns> Returns a specified director.</returns>
        public override Director GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(i => i.DirectorId == id);
        }

        /// <summary>
        ///  Insert a new director to the database.
        /// </summary>
        /// <param name="entity">This is the director, which should be added.</param>
        public override void Insert(Director entity)
        {
            (this.ctx as MovieDbContext).Directors.Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Removes a director from the database.
        /// </summary>
        /// <param name="entity">Specifies which director should be removed.</param>
        /// <returns>Returns whether the actor was successfully removed or not from the database.</returns>
        public override bool Remove(Director entity)
        {
            if (entity != null && this.GetOne(entity.DirectorId) != null)
            {
                (this.ctx as MovieDbContext).Directors.Remove(entity);
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
