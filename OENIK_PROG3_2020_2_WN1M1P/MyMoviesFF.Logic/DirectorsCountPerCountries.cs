// <copyright file="DirectorsCountPerCountries.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///  This DirectorsCountPerCountries class is used for to store the statistics of how many directors living per country.
    /// </summary>
    public class DirectorsCountPerCountries
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets how many director living in a specified country.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns how many directors living in a specified country.
        /// </summary>
        /// <returns>Returns a string of a country and count property.</returns>
        public override string ToString()
        {
            return $"Country: {this.Country}, DirectorCount: {this.Count}";
        }

        /// <summary>
        /// Determine whether two DirectorsCountPerCountries are the same or not.
        /// </summary>
        /// <param name="obj">Indicates the DirectorsCountPerCountries object, which will be compared to the caller object.</param>
        /// <returns>Returns a bool whether two DirectorsCountPerCountries are the same or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is DirectorsCountPerCountries)
            {
                DirectorsCountPerCountries other = obj as DirectorsCountPerCountries;
                return this.Country == other.Country && this.Count == other.Count;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines the hash code of the DirectorsCountPerCountries object.
        /// </summary>
        /// <returns>Returns a hash code of the DirectorsCountPerCountries object.</returns>
        public override int GetHashCode()
        {
            return this.Country.GetHashCode() + (this.Count * 2);
        }
    }
}
