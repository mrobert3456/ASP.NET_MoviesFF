// <copyright file="ConnRepository.cs" company="WN1M1P">
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
    /// This is the abstract ConnRepository class, which will be used by specified connector Repository classes.
    /// </summary>
    /// <typeparam name="T">Gerner T parameter.</typeparam>
    public abstract class ConnRepository<T> : IConnRepository<T>
        where T : class
    {
        /// <summary>
        /// Dbcontext field, which specifies the entity tables and it's relationships.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">This parameter is the dbcontext class.</param>
        public ConnRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int idone, int idtwo);

        /// <inheritdoc/>
        public abstract void Insert(T entity);

        /// <inheritdoc/>
        public abstract bool Remove(T entity);
    }
}
