// <copyright file="ActorsController.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyMoviesFF.Logic;
    using MyMoviesFF.Web.Models;

    /// <summary>
    /// Controls the Actor related features.
    /// </summary>
    public class ActorsController : Controller
    {
        private IActingLogic actingLogic;
        private IMapper mapper;
        private ActorListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActorsController"/> class.
        /// </summary>
        /// <param name="actingLogic">IActtingLogic implementation.</param>
        /// <param name="mapper">IMapper implementation.</param>
        public ActorsController(IActingLogic actingLogic, IMapper mapper)
        {
            this.actingLogic = actingLogic;
            this.mapper = mapper;
            this.vm = new ActorListViewModel();
            this.vm.EditedActor = new Actor();
            var actors = actingLogic?.GetAllActors();
            this.vm.ListOfActors = mapper?.Map<IList<MyMoviesFF.Data.Actor>, List<Actor>>(actors);
        }

        /// <summary>
        /// Shows the Index.
        /// </summary>
        /// <returns>Returns an IActionResult.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew"; // actorseditnek kell egy  editaction
            return this.View("ActorsIndex", this.vm);
        }

        /// <summary>
        /// Shows one Actor's details.
        /// </summary>
        /// <param name="id">Actor's id.</param>
        /// <returns>Returns an ActorsDetails IActionResult.</returns>
        public IActionResult Details(int id)
        {
            // GET: Actors/Details/5  //5=id
            return this.View("ActorsDetails", this.GetActorModel(id));
        }

        /// <summary>
        /// Removes one Actor.
        /// </summary>
        /// <param name="id">Actor's id.</param>
        /// <returns>Returns an EditResult IActionResult.</returns>
        public IActionResult Remove(int id)
        {
            // GET: Actors/Remove/5  //5=id
            this.TempData["editResult"] = "DELETE FAIL";
            if (this.actingLogic.RemoveActor(this.actingLogic.GetOneActor(id)))
            {
                this.TempData["editResult"] = "DELETE OK";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Edits one Actor.
        /// </summary>
        /// <param name="id">Actor's id.</param>
        /// <returns>Returns an EditAction IActionResult.</returns>
        public IActionResult Edit(int id)
        {
            // GET: Actors/Edit/5  //5=id
            this.ViewData["editAction"] = "Edit"; // actorseditnek kell egy  editaction
            this.vm.EditedActor = this.GetActorModel(id);
            return this.View("ActorsIndex", this.vm);
        }

        /// <summary>
        /// Edits or Adds an Actor.
        /// </summary>
        /// <param name="actor">Actor entity.</param>
        /// <param name="editAction">Action string(AddNew or Edit).</param>
        /// <returns>Returns an EditAction IActionResult.</returns>
        [HttpPost]
        public IActionResult Edit(Actor actor, string editAction)
        {
            // Post: Actors/Edit + 1 actor + editAction
            if (this.ModelState.IsValid && actor != null)
            {
                this.TempData["editResult"] = "EDIT OK";
                if (editAction == "AddNew")
                {
                    this.actingLogic.InsertNewActor(actor.ActorName, actor.Gender, actor.Age, 0, actor.Country);
                }
                else
                {
                    if (!this.actingLogic.ChangeActor(actor.ActorId, actor.ActorName, actor.Gender, actor.Age, actor.Country))
                    {
                        this.TempData["editResult"] = "EDIT FAIL";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit"; // actorseditnek kell egy  editaction
                this.vm.EditedActor = actor;
                return this.View("ActorsIndex", this.vm);
            }
        }

        /// <summary>
        /// Converts MyMoviesFF.Data.Actor to MyMoviesFF.Web.Model.Actor.
        /// </summary>
        /// <param name="id">Actor's id.</param>
        /// <returns>Returns a Model.Actor.</returns>
        private Models.Actor GetActorModel(int id)
        {
            MyMoviesFF.Data.Actor oneactor = this.actingLogic.GetOneActor(id);
            return this.mapper.Map<MyMoviesFF.Data.Actor, Actor>(oneactor);
        }
    }
}
