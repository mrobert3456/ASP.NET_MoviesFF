// <copyright file="MovieEditorWindow.xaml.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using MyMoviesFF.Data;
    using MyMoviesWPF.VM;

    /// <summary>
    /// Interaction logic for MovieEditorWindow.xaml.
    /// </summary>
    public partial class MovieEditorWindow : Window
    {
        private MovieEditorViewModel evm;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieEditorWindow"/> class.
        /// </summary>
        public MovieEditorWindow()
        {
            this.InitializeComponent();

            this.evm = this.FindResource("EVM") as MovieEditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieEditorWindow"/> class.
        /// </summary>
        /// <param name="m">Movie entity, which will be edited.</param>
        public MovieEditorWindow(Movie m)
            : this()
        {
            this.evm.Movie = m;
            foreach (var item in m?.MovieActors)
            {
                this.evm.Actors.Add(item.Actor);
            }

            foreach (var item in m.MovieDirectors)
            {
                this.evm.Directors.Add(item.Director);
            }
        }

        /// <summary>
        /// Gets the movie entity, which is selected for editing.
        /// </summary>
        public Movie Movie { get => this.evm.Movie; }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
