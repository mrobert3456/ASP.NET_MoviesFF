// <copyright file="Actor.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using MyMoviesFF.Data;

    /// <summary>
    /// Contains Actor's attributes, which will be used.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Gets or sets the Actor's id.
        /// </summary>
        [Display(Name = "Actor Id")]
        [Required]
        public int ActorId { get; set; }

        /// <summary>
        /// Gets or sets the Actor's name.
        /// </summary>
        [Display(Name = "Actor Name")]
        [Required]
        public string ActorName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Actor is a male(1) or a female(0).
        /// </summary>
        [Display(Name = "Actor's gender")]
        [Required]
        public bool Gender { get; set; }

        /// <summary>
        /// Gets or sets the Actor's age.
        /// </summary>
        [Display(Name = "Actor's age")]
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets how movies has the actor's played.
        /// </summary>
        [Display(Name = "Movie Count")]
        public int MovieCount { get; set; }

        /// <summary>
        /// Gets or sets the Actor's movies, which is in the database.
        /// </summary>
        [Display(Name = "Movies")]
        public ICollection<MovieActor> MovieActors { get; set; }

        /// <summary>
        /// Gets or sets the Actor's country.
        /// </summary>
        [Display(Name = "Actor's country")]
        [Required]
        public string Country { get; set; }
    }
}
