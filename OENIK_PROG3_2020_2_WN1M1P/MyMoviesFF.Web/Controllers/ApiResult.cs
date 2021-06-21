// <copyright file="ApiResult.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines a result of an Api action.
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation was successfull or not.
        /// </summary>
        public bool OperationResult { get; set; }
    }
}
