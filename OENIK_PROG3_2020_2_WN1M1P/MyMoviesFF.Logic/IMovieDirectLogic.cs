// <copyright file="IMovieDirectLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// Describe the logic between movies and directors.
    /// </summary>
    public interface IMovieDirectLogic : IMovieMethods
    {
        /// <summary>
        /// Gets one specified director.
        /// </summary>
        /// <param name="id">This is the id, which indicates the director.</param>
        /// <returns> Returns a specified director.</returns>
        Director GetOneDirector(int id);

        /// <summary>
        /// Gets all directors from the database.
        /// </summary>
        /// <returns>Returns an IList collection of directors.</returns>
        IList<Director> GetAllDirectors();

        /// <summary>
        /// This method changes the birth country of the actor.
        /// </summary>
        /// <param name="id">This is the directors id.</param>
        /// <param name="newcountry">This is the birth country, which will be the new birth country of the director.</param>
        void ChangeCountry(int id, string newcountry);

        /// <summary>
        /// Insert a new director to the database.
        /// </summary>
        /// <param name="directorName">Director name.</param>
        /// <param name="movieCount">How many movies were directed by this director.</param>
        /// <param name="gender">Director's gender.</param>
        /// <param name="country">Director's birthplace.</param>
        /// <param name="age">Director's age.</param>
        void InsertNewDirector(string directorName, int movieCount, bool gender, string country, int age);

        /// <summary>
        /// Removes a director from the database.
        /// </summary>
        /// <param name="entity">Specifies which director should be removed.</param>
        /// <returns>Returns whether the actor was successfully removed or not from the database.</returns>
        bool RemoveDirector(Director entity);

        /// <summary>
        /// Calculate the avarage age of the directors.
        /// </summary>
        /// <returns>Returns a double variable, which will be the avarage age of the directors.</returns>
        double AVGDirectorAge();

        /// <summary>
        /// Gets how many directors living in every country stored in the database.
        /// </summary>
        /// <returns>Return an DirectorsCountPerCountries collection of the statistic.</returns>
        IList<DirectorsCountPerCountries> GetDirectorCountPerCountries();
    }
}
