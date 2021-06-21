// <copyright file="ActorFromApi.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Responsible for Api interactions.
    /// </summary>
    public class ActorFromApi
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
        /// Gets or sets a value indicating whether the Actor is a male or a female.
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
    }
}
