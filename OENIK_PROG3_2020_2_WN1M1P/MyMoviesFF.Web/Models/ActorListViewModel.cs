// <copyright file="ActorListViewModel.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The ViewModel of the Actors.
    /// </summary>
    public class ActorListViewModel
    {
        /// <summary>
        /// Gets or sets the collection of Actors.
        /// </summary>
        public IList<Actor> ListOfActors { get; set; }

        /// <summary>
        /// Gets or sets the current Actor.
        /// </summary>
        public Actor EditedActor { get; set; }
    }
}
