// <copyright file="ActorsApiController.cs" company="WN1M1P">
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

    /// <summary>
    /// Api controller for Actors.
    /// </summary>
    public class ActorsApiController : Controller
    {
        private IActingLogic actingLogic;
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActorsApiController"/> class.
        /// </summary>
        /// <param name="actingLogic">IActtingLogic implementation.</param>
        /// <param name="mapper">IMapper implementation.</param>
        public ActorsApiController(IActingLogic actingLogic, IMapper mapper)
        {
            this.actingLogic = actingLogic;
            this.mapper = mapper;
        }

        // GET ActorsApi/all

        /// <summary>
        /// Gets all the actors.
        /// </summary>
        /// <returns>Returns an IEnumerable collection of actors.</returns>
        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Models.Actor> GetAll()
        {
            var actors = this.actingLogic.GetAllActors();
            return this.mapper.Map<IList<Data.Actor>, List<Models.Actor>>(actors);
        }

        // GET ActorsApi/del/5

        /// <summary>
        /// Deletes one Actor.
        /// </summary>
        /// <param name="id">Actor's id.</param>
        /// <returns>Returns an ApiResult.</returns>
        [HttpGet]
        [ActionName("del")]
        public ApiResult DelOneActor(int id)
        {
            return new ApiResult() { OperationResult = this.actingLogic.RemoveActor(this.actingLogic.GetOneActor(id)) };
        }

        // POST ActorsApi/add+ POST 1 actor

        /// <summary>
        /// Adds one Actor.
        /// </summary>
        /// <param name="actor">Model.Actor.</param>
        /// <returns>Returns an ApiResult.</returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneActor(Models.Actor actor)
        {
            bool success = true;
            if (actor != null)
            {
                try
                {
                    this.actingLogic.InsertNewActor(actor.ActorName, actor.Gender, actor.Age, actor.MovieCount, actor.Country);
                }
                catch (ArgumentException)
                {
                    success = false;
                }
            }

            return new ApiResult() { OperationResult = success };
        }

        // POST ActorsApi/mod+ Post 1 actor

        /// <summary>
        /// Modifies the selected actor.
        /// </summary>
        /// <param name="actor">Models.Actor which will be modified.</param>
        /// <returns>Returns an ApiResult.</returns>
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOneActor(Models.Actor actor)
        {
            if (actor != null)
            {
                return new ApiResult() { OperationResult = this.actingLogic.ChangeActor(actor.ActorId, actor.ActorName, actor.Gender, actor.Age, actor.Country) };
            }
            else
            {
                return new ApiResult() { OperationResult = false };
            }
        }
    }
}
