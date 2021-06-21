// <copyright file="IDirectorRepository.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the interface, which will be used by DirectorRepository class.
    /// </summary>
    public interface IDirectorRepository : IRepository<Director>
    {
        /// <summary>
        /// This method changes the birth country of the actor.
        /// </summary>
        /// <param name="id">This is the directors id.</param>
        /// <param name="newcountry">This is the birth country, which will be the new birth country of the director.</param>
        void ChangeCountry(int id, string newcountry);
    }
}
