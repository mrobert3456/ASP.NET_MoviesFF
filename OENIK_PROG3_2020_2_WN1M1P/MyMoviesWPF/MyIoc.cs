// <copyright file="MyIoc.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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
