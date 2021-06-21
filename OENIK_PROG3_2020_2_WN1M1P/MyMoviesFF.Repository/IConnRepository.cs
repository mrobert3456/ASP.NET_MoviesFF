// <copyright file="IConnRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This is the generic interface which will be used by specified connector IRepository interfaces.
    /// </summary>
    /// <typeparam name="T">Generic T parameter.</typeparam>
    public interface IConnRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets one T type object.
        /// </summary>
        /// <param name="idone">This is the composite id's first part.</param>
        /// <param name="idtwo">This is the composite id's second part.</param>
        /// <returns>Returns a specified object.</returns>
        T GetOne(int idone, int idtwo);

        /// <summary>
        /// Gets all T type objects from an IQueryable collection.
        /// </summary>
        /// <returns>Return an IQueryable collection.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Inserts a T type object to a collection.
        /// </summary>
        /// <param name="entity">The specified object, which should be inserted. </param>
        void Insert(T entity);

        /// <summary>
        /// Removes a T type object from a collection.
        /// </summary>
        /// <param name="entity">The specified object, which will be removed from a collection.</param>
        /// <returns>Returns whether the deletion was successfull or not. </returns>
        bool Remove(T entity);
    }
}
