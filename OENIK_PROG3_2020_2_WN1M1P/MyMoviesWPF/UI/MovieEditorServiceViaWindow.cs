// <copyright file="MovieEditorServiceViaWindow.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyMoviesFF.Data;
    using MyMoviesWPF.BL;

    /// <summary>
    /// Class which handles a movie entity editing via window.
    /// </summary>
    public class MovieEditorServiceViaWindow : IMovieEditorService
    {
        /// <summary>
        /// Edits a movie.
        /// </summary>
        /// <param name="m">Movie entity, which will be edited.</param>
        /// <returns>Returns false if the editing failed, otherwise returns true.</returns>
        public bool EditMovie(Movie m)
        {
            MovieEditorWindow win = new MovieEditorWindow(m);
            return win.ShowDialog() ?? false;
        }
    }
}
