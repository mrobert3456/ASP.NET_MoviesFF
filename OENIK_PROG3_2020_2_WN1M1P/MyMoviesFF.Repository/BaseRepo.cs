// <copyright file="BaseRepo.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the abstract Repository class, which will be used by specified Repository classes.
    /// </summary>
    /// <typeparam name="T">Gerner T parameter.</typeparam>
    public abstract class BaseRepo<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Dbcontext field, which specifies the entity tables and it's relationships.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepo{T}"/> class.
        /// </summary>
        /// <param name="ctx">This parameter is the dbcontext class.</param>
        public BaseRepo(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        ///  Gets all T type objects from an IQueryable collection.
        /// </summary>
        /// <returns>Returns an IQueryable collection.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Gets one T type object.
        /// </summary>
        /// <param name="id">This is the objects id.</param>
        /// <returns>Returns a specified object.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// Inserts a T type object to a collection.
        /// </summary>
        /// <param name="entity">The specified object, which should be inserted. </param>
        public abstract void Insert(T entity);

        /// <summary>
        /// Removes a T type object from a collection.
        /// </summary>
        /// <param name="entity">The specified object, which will be removed from a collection.</param>
        /// <returns>Returns whether the deletion was successfull or not. </returns>
        public abstract bool Remove(T entity);
    }
}
