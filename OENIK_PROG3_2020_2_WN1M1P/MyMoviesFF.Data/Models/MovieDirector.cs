// <copyright file="MovieDirector.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This is the connector entity between movies and directors.
    /// </summary>
    public class MovieDirector
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
        /// Gets or sets the director foreign key.
        /// </summary>
        public int DirectorId { get; set; }

        /// <summary>
        /// Gets or sets the director navigation property.
        /// </summary>
        [NotMapped]
        public virtual Director Director { get; set; }
    }
}
