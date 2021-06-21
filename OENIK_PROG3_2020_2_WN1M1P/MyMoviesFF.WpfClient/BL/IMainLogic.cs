// <copyright file="IMainLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MyMoviesFF.WpfClient.VM;

    /// <summary>
    /// Contains the main logic's methods sytaxs.
    /// </summary>
    public interface IMainLogic
    {
        /// <summary>
        /// Sends the operation result.
        /// </summary>
        /// <param name="success">Determines whether the operation was successfull or not.</param>
        void SendMessage(bool success);

        /// <summary>
        /// Gets the Actors from the Api.
        /// </summary>
        /// <returns>Returns a List of ActorVM.</returns>
        IList<ActorVM> ApiGetActors();

        /// <summary>
        /// Deletes an Actor.
        /// </summary>
        /// <param name="actor">Actor which will be deleted.</param>
        void ApiDelActor(ActorVM actor);

        /// <summary>
        /// Edits an Actor.
        /// </summary>
        /// <param name="actor">ActorVM which will be edited.</param>
        /// <param name="isEditing">Determines whether the actor is being edited or not.</param>
        /// <returns>Returns a bool whether the edit was successfull or not.</returns>
        bool ApiEditActor(ActorVM actor, bool isEditing);

        /// <summary>
        /// Edits an Actor.
        /// </summary>
        /// <param name="actor">Actor which will be edited.</param>
        /// <param name="editor">Function which edits the actor.</param>
        void EditActor(ActorVM actor, Func<ActorVM, bool> editor);
    }
}
