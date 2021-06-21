// <copyright file="MainWindow.xaml.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using GalaSoft.MvvmLight.Messaging;
    using MyMoviesFF.WpfClient.UI;
    using MyMoviesFF.WpfClient.VM;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string>(this, "ActorResult", msg =>
            {
                (this.DataContext as MainWM).LoadCmd.Execute(null);
                MessageBox.Show(msg);
            });

            (this.DataContext as MainWM).EditorFunc = (actor) =>
            {
                EditorWindow win = new EditorWindow(actor);
                return win.ShowDialog() == true;
            };
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
