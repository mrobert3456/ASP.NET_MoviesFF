// <copyright file="MyIoc.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// An Ioc class which inherits SimpleIoc, and IServiceLocator interface.
    /// </summary>
    public class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets MyIoc instance.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
}
