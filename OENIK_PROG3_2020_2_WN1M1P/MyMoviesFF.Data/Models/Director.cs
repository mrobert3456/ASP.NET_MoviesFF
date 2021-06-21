// <copyright file="Director.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This is the entity of a director.
    /// </summary>
    public class Director
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Director"/> class.
        /// </summary>
        public Director()
        {
            this.MovieDirectors = new HashSet<MovieDirector>();
        }

        /// <summary>
        /// Gets all datas of the object.
        /// </summary>
        [NotMapped]
        public string AllData => this.Gender == true ? $"{this.DirectorId}, {this.DirectorName}, Male , {this.Country}, Age:{this.Age}, MovieCount:{this.MovieCount}" :
            $"{this.DirectorId}, {this.DirectorName}, Female , {this.Country}, Age:{this.Age}, MovieCount:{this.MovieCount}";

        /// <summary>
        /// Gets or sets the id of the director, which is also the primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the director.
        /// </summary>
        [Required]
        public string DirectorName { get; set; }

        /// <summary>
        /// Gets or sets how many movies were directed by the current director.
        /// </summary>
        [Required]
        public int MovieCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the actor is a man or a woman.
        /// </summary>
        [Required]
        public bool Gender { get; set; }

        /// <summary>
        ///  Gets or sets the connector entity between actors and movies.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets how many movies were with the current actor.
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the connector entity between directors and movies.
        /// </summary>
        [NotMapped]
        public virtual ICollection<MovieDirector> MovieDirectors { get; set; }
    }
}
