// <copyright file="ActorVM.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using MyMoviesFF.WpfClient.Data;

    /// <summary>
    /// Actor's viewmodel.
    /// </summary>
    public class ActorVM : ObservableObject
    {
        private int id;
        private string name;
        private bool gender;
        private int age;
        private string country;

        /// <summary>
        /// Gets or sets the Actor's id.
        /// </summary>
        public int ActorId { get => this.id; set => this.Set(ref this.id, value); }

        /// <summary>
        /// Gets or sets the Actor's name.
        /// </summary>
        public string ActorName { get => this.name; set => this.Set(ref this.name, value); }

        /// <summary>
        /// Gets or sets a value indicating whether the Actor is a male or a female.
        /// </summary>
        public bool Gender { get => this.gender; set => this.Set(ref this.gender, value); }

        /// <summary>
        /// Gets or sets the Actor's age.
        /// </summary>
        public int Age { get => this.age; set => this.Set(ref this.age, value); }

        /// <summary>
        /// Gets or sets the Actor's country.
        /// </summary>
        public string Country { get => this.country; set => this.Set(ref this.country, value); }

        /// <summary>
        /// Converts ActorFromApi to ActorVM.
        /// </summary>
        /// <param name="actor">ActorFromApi object.</param>
        /// <returns>Returns an ActorVM object.</returns>
        public static ActorVM ConvertFromApi(ActorFromApi actor)
        {
            if (actor != null)
            {
                return new ActorVM()
                {
                    ActorId = actor.ActorId,
                    ActorName = actor.ActorName,
                    Gender = actor.Gender,
                    Age = actor.Age,
                    Country = actor.Country,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Copy one ActorVM.
        /// </summary>
        /// <param name="actor">Other ActorVM.</param>
        public void CopyFrom(ActorVM actor)
        {
            if (actor == null)
            {
                return;
            }
            else
            {
                this.id = actor.id;
                this.name = actor.name;
                this.gender = actor.gender;
                this.age = actor.Age;
                this.country = actor.Country;
            }
        }
    }
}
