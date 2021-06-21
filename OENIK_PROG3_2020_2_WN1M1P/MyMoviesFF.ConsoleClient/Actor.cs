// <copyright file="Actor.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    /// <summary>
    /// Actor class, which will be converted into json.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Gets or sets the Actor's id.
        /// </summary>
        public int ActorId { get; set; }

        /// <summary>
        /// Gets or sets the Actor's name.
        /// </summary>
        public string ActorName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Actor is male or female.
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// Gets or sets the Actor's age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the Actor's country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets how movies has the actor's played.
        /// </summary>
        public int MovieCount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"ID={this.ActorId}\tName={this.ActorName}\tGender={this.Gender}\tAge={this.Age}\tCountry={this.Country}";
        }
    }
}
