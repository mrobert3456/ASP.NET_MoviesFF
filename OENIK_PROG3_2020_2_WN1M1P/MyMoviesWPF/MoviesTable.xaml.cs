// <copyright file="MoviesTable.xaml.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using MyMoviesWPF.VM;

    /// <summary>
    /// Interaction logic for MoviesTable.xaml.
    /// </summary>
    public partial class MoviesTable : UserControl
    {
        private MoviesTableViewModel mtVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesTable"/> class.
        /// </summary>
        public MoviesTable()
        {
            this.InitializeComponent();
            this.mtVM = this.FindResource("mtVM") as MoviesTableViewModel;
        }
    }
}
