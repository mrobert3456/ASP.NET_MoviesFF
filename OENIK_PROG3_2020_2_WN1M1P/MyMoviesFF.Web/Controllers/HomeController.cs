// <copyright file="HomeController.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MyMoviesFF.Web.Models;

    /// <summary>
    /// HomeController class.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">ILogger implementation.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Shows the Index.
        /// </summary>
        /// <returns>Returns an IActionResult of the index.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Shows the Privacy.
        /// </summary>
        /// <returns>Returns an IActionResult of the privacy.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Shows th errors.
        /// </summary>
        /// <returns>Returns an IActionResult of the errors.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
