// <copyright file="App.xaml.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient
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
    using MyMoviesFF.WpfClient.BL;

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
            MyIoc.Instance.Register<IMainLogic, MainLogic>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);
        }
    }
}
