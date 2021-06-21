// <copyright file="MoviesTableViewModel.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using MyMoviesFF.Data;
    using MyMoviesWPF.BL;

    /// <summary>
    /// ViewModel class for the Movie table usercontrol.
    /// </summary>
    public class MoviesTableViewModel : ViewModelBase
    {
        private IMovieLogic movieLogic;
        private Movie oneMovie;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesTableViewModel"/> class.
        /// </summary>
        /// <param name="movieLogic"> Instance of a class, which implements IMovieLogic interface.</param>
        public MoviesTableViewModel(IMovieLogic movieLogic)
        {
            this.movieLogic = movieLogic;
            this.Movies = new ObservableCollection<Movie>();
            this.OneMovie = new Movie();

            if (this.IsInDesignMode)
            {
                Movie movie1 = new Movie() { MovieId = 1, Title = "joooo", Year = 2019, IMDB = 7.5, Genre = "action", AgeLimit = 13 };
                Movie movie2 = new Movie() { MovieId = 2, Title = "Doctor Strange", Year = 2016, IMDB = 7.5, Genre = "action", AgeLimit = 13 };
                Movie movie3 = new Movie() { MovieId = 3, Title = "The Babysitter", Year = 2017, IMDB = 6.3, Genre = "horror", AgeLimit = 18 };
                Movie movie4 = new Movie() { MovieId = 4, Title = " Fuzzi algo", Year = 2007, IMDB = 7.8, Genre = "comedy", AgeLimit = 18 };
                Movie movie5 = new Movie() { MovieId = 5, Title = "Jumanji", Year = 2017, IMDB = 6.9, Genre = "adventure", AgeLimit = 16 };

                this.Movies.Add(movie1);
                this.Movies.Add(movie2);

                this.Movies.Add(movie3);

                this.Movies.Add(movie4);

                this.Movies.Add(movie5);
            }
            else
            {
                this.movieLogic.GetAllMovies().ToList().ForEach(i => this.Movies.Add(i));
            }

            this.Addcmd = new RelayCommand(() => movieLogic.AddMovie(this.Movies), true);
            this.Modcmd = new RelayCommand(() => movieLogic.ModMovie(ref this.oneMovie), true);
            this.Delcmd = new RelayCommand(() => movieLogic.DelMovie(this.Movies, ref this.oneMovie), true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesTableViewModel"/> class.
        /// </summary>
        public MoviesTableViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMovieLogic>())
        {
        }

        /// <summary>
        /// Gets  ObservableCollection of movies.
        /// </summary>
        public ObservableCollection<Movie> Movies { get; private set; }

        /// <summary>
        /// Gets Movie add command.
        /// </summary>
        public ICommand Addcmd { get; private set; }

        /// <summary>
        /// Gets Movie delete command.
        /// </summary>
        public ICommand Delcmd { get; private set; }

        /// <summary>
        /// Gets Movie edit command.
        /// </summary>
        public ICommand Modcmd { get; private set; }

        /// <summary>
        /// Gets or sets the selected movie from the MainWindow.
        /// </summary>
        public Movie OneMovie { get => this.oneMovie; set => this.Set(ref this.oneMovie, value); }
    }
}
