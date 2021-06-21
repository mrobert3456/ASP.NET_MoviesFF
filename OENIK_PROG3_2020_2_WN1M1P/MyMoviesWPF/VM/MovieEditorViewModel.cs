// <copyright file="MovieEditorViewModel.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using MyMoviesFF.Data;
    using MyMoviesWPF.BL;

    /// <summary>
    /// ViewModel class for the Movie editor window.
    /// </summary>
    public class MovieEditorViewModel : ViewModelBase
    {
        private ObservableCollection<Actor> actors;
        private IList<Actor> allActors;
        private IList<Director> allDirectors;
        private ObservableCollection<Director> directors;
        private Movie movie;
        private Actor actorA;
        private Actor actorCur;
        private Director directorA;
        private Director directorCur;
        private IMovieLogic imovieLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieEditorViewModel"/> class.
        /// </summary>
        /// <param name="movieLogic">Instance of a class, which implements IMovieLogic interface.</param>
        public MovieEditorViewModel(IMovieLogic movieLogic)
        {
            this.imovieLogic = movieLogic;
            this.movie = new Movie();

            this.actorA = new Actor() { ActorName = "jani" };
            this.actorCur = new Actor() { ActorName = "zsofi" };
            this.directorA = new Director() { DirectorName = "laci" };
            this.directorCur = new Director() { DirectorName = "norbi" };

            this.AllDirectors = new List<Director>();
            this.Actors = new ObservableCollection<Actor>();

            this.Directors = new ObservableCollection<Director>();
            this.AllActors = new List<Actor>();
            if (this.IsInDesignMode)
            {
                this.movie.Title = "UNKNOWN";
                this.movie.IMDB = 5;
                this.movie.Genre = "Action";
                this.movie.Year = 2015;
                this.movie.AgeLimit = 16;
                this.AllActors.Add(this.actorA);
                this.Actors.Add(this.ActorCur);

                this.allDirectors.Add(this.DirectorA);
                this.Directors.Add(this.DirectorCur);
            }
            else
            {
                this.AllActors = this.imovieLogic.GetAllActors();
                this.allDirectors = this.imovieLogic.GetAllDirectors();
            }

            this.AddActorcmd = new RelayCommand(() => this.imovieLogic.AddActortoMovie(ref this.movie, this.Actors, this.ActorA));
            this.DelActorcmd = new RelayCommand(() => this.imovieLogic.DelActorFromMovie(ref this.movie, this.Actors, this.ActorCur));
            this.AddDircmd = new RelayCommand(() => this.imovieLogic.AddDirectortoMovie(ref this.movie, this.Directors, this.DirectorA));
            this.DelDircmd = new RelayCommand(() => this.imovieLogic.DelDirectorFromMovie(ref this.movie, this.Directors, this.DirectorCur));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieEditorViewModel"/> class.
        /// </summary>
        public MovieEditorViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMovieLogic>())
        {
        }

        /// <summary>
        /// Gets or sets the selected Movie entity.
        /// </summary>
        public Movie Movie { get => this.movie; set => this.Set(ref this.movie, value); }

        /// <summary>
        /// Gets or sets the actors ObservableCollection, which stores the actors in the selected movie.
        /// </summary>
        public ObservableCollection<Actor> Actors { get => this.actors; set => this.Set(ref this.actors, value); }

        /// <summary>
        /// Gets or sets the directors ObservableCollection, which stores the actors in the selected movie.
        /// </summary>
        public ObservableCollection<Director> Directors { get => this.directors; set => this.Set(ref this.directors, value); }

        /// <summary>
        /// Gets or sets the selected Actor entity, which belongs to the current movie.
        /// </summary>
        public Actor ActorCur { get => this.actorCur; set => this.Set(ref this.actorCur, value); }

        /// <summary>
        /// Gets or sets the selected Director entity, which belongs to the current movie.
        /// </summary>
        public Director DirectorCur { get => this.directorCur; set => this.Set(ref this.directorCur, value); }

        /// <summary>
        /// Gets or sets the IList collection of actors, which containt all the actors of the database.
        /// </summary>
        public IList<Actor> AllActors { get => this.allActors; set => this.allActors = value; }

        /// <summary>
        ///  Gets or sets the IList collection of directors, which containt all the directors of the database.
        /// </summary>
        public IList<Director> AllDirectors { get => this.allDirectors; set => this.allDirectors = value; }

        /// <summary>
        /// Gets or sets the Actor entity, which is one of the actors stored in the database.
        /// </summary>
        public Actor ActorA { get => this.actorA; set => this.Set(ref this.actorA, value); }

        /// <summary>
        /// Gets or sets the Director entity, which is one of the directors stored in the database.
        /// </summary>
        public Director DirectorA { get => this.directorA; set => this.Set(ref this.directorA, value); }

        /// <summary>
        /// Gets the Add actor to a movie command.
        /// </summary>
        public ICommand AddActorcmd { get; private set; }

        /// <summary>
        /// Gets the Delete actor from a movie command.
        /// </summary>
        public ICommand DelActorcmd { get; private set; }

        /// <summary>
        /// Gets the Add director to a movie command.
        /// </summary>
        public ICommand AddDircmd { get; private set; }

        /// <summary>
        /// Gets the Delete director from a movie command.
        /// </summary>
        public ICommand DelDircmd { get; private set; }
    }
}
