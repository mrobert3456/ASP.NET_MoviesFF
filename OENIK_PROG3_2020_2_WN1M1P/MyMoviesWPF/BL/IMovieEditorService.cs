// <copyright file="IMovieEditorService.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyMoviesWPF.BL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;

    /// <summary>
    /// This is the interface, which is used for movie editing.
    /// </summary>
    public interface IMovieEditorService
    {
        /// <summary>
        /// Used for movie editing or adding.
        /// </summary>
        /// <param name="m"> Movie entity.</param>
        /// <returns> Returns true if Edit movie was successful, otherwise returns false.</returns>
        bool EditMovie(Movie m);
    }
}
