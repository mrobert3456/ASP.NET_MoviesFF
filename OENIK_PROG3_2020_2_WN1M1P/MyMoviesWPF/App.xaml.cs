// <copyright file="App.xaml.cs" company="WN1M'P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Messaging;
    using Microsoft.EntityFrameworkCore;
    using MyMoviesFF.Data;
    using MyMoviesFF.Logic;
    using MyMoviesFF.Repository;
    using MyMoviesWPF.BL;
    using MyMoviesWPF.UI;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);

            MyIoc.Instance.Register<IActorRepository, ActorRepository>();

            MyIoc.Instance.Register<IMovieRepository, MovieRepository>();
            MyIoc.Instance.Register<IDirectorRepository, DirectorRepository>();
            MyIoc.Instance.Register<IMovieDirectorRepository, MovieDirectorRepository>();
            MyIoc.Instance.Register<IMovieActorRepository, MovieActorRepository>();

            MyIoc.Instance.Register<IMovieEditorService, MovieEditorServiceViaWindow>();

            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);

            MyIoc.Instance.Register<IActingLogic, ActingLogic>();
            MyIoc.Instance.Register<IMovieDirectLogic, MovieDirectLogic>();
            MyIoc.Instance.Register<IMovieMakeLogic, MovieMakeLogic>();

            MyIoc.Instance.Register<IMovieLogic, MovieLogic>();
            MyIoc.Instance.Register<IMovieMethods, MovieMethods>();
            MyIoc.Instance.Register<IRepository<Actor>, BaseRepo<Actor>>();
            MyIoc.Instance.Register<IRepository<Director>, BaseRepo<Director>>();
            MyIoc.Instance.Register<IRepository<Movie>, BaseRepo<Movie>>();
            MyIoc.Instance.Register<IRepository<MovieActor>, BaseRepo<MovieActor>>();
            MyIoc.Instance.Register<IRepository<MovieDirector>, BaseRepo<MovieDirector>>();
            MyIoc.Instance.Register<IConnRepository<MovieDirector>, ConnRepository<MovieDirector>>();
            MyIoc.Instance.Register<IConnRepository<MovieActor>, ConnRepository<MovieActor>>();
            MyIoc.Instance.Register<DbContext, MovieDbContext>();
        }
    }
}
