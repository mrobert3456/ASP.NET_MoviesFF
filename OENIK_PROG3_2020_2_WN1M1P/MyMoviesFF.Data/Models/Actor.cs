// <copyright file="Actor.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    /// <summary>
    /// This is the entity of a actor.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Actor"/> class.
        /// </summary>
        public Actor()
        {
            this.MovieActors = new HashSet<MovieActor>();
        }

        /// <summary>
        /// Gets or sets the id of the actor, which also the primariry key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }

        /// <summary>
        /// Gets all datas of the object.
        /// </summary>
        [NotMapped]
        public string AllData => this.Gender == true ? $"{this.ActorId}, {this.ActorName}, Male, {this.Country}, Age:{this.Age}, MovieCount:{this.MovieCount}" :
            $"{this.ActorId}, {this.ActorName}, Female, {this.Country}, Age:{this.Age}, MovieCount:{this.MovieCount}";

        /// <summary>
        /// Gets or sets the name of the actor.
        /// </summary>
        [Required]
        public string ActorName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the actor is a man or a woman.
        /// </summary>
        [Required]
        public bool Gender { get; set; }

        /// <summary>
        /// Gets or sets the age of the actor.
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets how many movies were with the current actor.
        /// </summary>
        [Required]
        public int MovieCount { get; set; }

        /// <summary>
        /// Gets or sets the country in which the current actors was born.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the connector entity between actors and movies.
        /// </summary>
        [NotMapped]
        public virtual ICollection<MovieActor> MovieActors { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            Actor other = obj as Actor;
            if (other != null && other.ActorId == this.ActorId)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.ActorId.GetHashCode() + this.ActorName.GetHashCode();
        }
    }
}
