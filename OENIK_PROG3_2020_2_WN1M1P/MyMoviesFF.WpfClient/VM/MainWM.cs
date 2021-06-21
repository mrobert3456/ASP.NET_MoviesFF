// <copyright file="MainWM.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using MyMoviesFF.WpfClient.BL;

    /// <summary>
    /// Main viewmodel for the WPFclient.
    /// </summary>
    public class MainWM : ViewModelBase
    {
        private IMainLogic logic;
        private ActorVM selectedActor;
        private ObservableCollection<ActorVM> allActors;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWM"/> class.
        /// </summary>
        /// <param name="logic">IMainLogic implementation.</param>
        public MainWM(IMainLogic logic)
        {
            this.logic = logic;

            this.LoadCmd = new RelayCommand(() => this.AllActors = new ObservableCollection<ActorVM>(this.logic.ApiGetActors()));
            this.DelCmd = new RelayCommand(() => this.logic.ApiDelActor(this.SelectedActor));
            this.AddCmd = new RelayCommand(() => this.logic.EditActor(null, this.EditorFunc));
            this.ModCmd = new RelayCommand(() => this.logic.EditActor(this.SelectedActor, this.EditorFunc));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWM"/> class.
        /// </summary>
        public MainWM()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMainLogic>())
        {
        }

        /// <summary>
        /// Gets or sets the Actors collection.
        /// </summary>
        public ObservableCollection<ActorVM> AllActors
        {
            get { return this.allActors; }
            set { this.Set(ref this.allActors, value); }
        }

        /// <summary>
        /// Gets or sets the selected Actor.
        /// </summary>
        public ActorVM SelectedActor
        {
            get { return this.selectedActor; }
            set { this.selectedActor = value; }
        }

        /// <summary>
        /// Gets or sets the Function of the editor.
        /// </summary>
        public Func<ActorVM, bool> EditorFunc { get; set; }

        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public ICommand LoadCmd { get; private set; }
    }
}
