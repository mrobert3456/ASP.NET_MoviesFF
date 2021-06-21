// <copyright file="ErrorViewModel.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web.Models
{
    using System;

    /// <summary>
    /// ErrorViewModel class.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the requested id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the RequestId is null or not.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
