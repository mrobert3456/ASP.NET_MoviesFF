// <copyright file="MovieActor.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This is the connector entity between movies and actors.
    /// </summary>
    public class MovieActor
    {
        /// <summary>
        /// Gets or sets the movie foreign key.
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movie navigation property.
        /// </summary>
        [NotMapped]
        public virtual Movie Movie { get; set; }

        /// <summary>
        /// Gets or sets the actor foreign key.
        /// </summary>
        public int ActorId { get; set; }

        /// <summary>
        /// Gets or sets the actor navigation property.
        /// </summary>
        [NotMapped]
        public virtual Actor Actor { get; set; }
    }
}
