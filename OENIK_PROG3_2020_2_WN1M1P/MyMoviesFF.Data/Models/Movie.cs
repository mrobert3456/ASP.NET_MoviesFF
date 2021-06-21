// <copyright file="Movie.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// This is the entity of a movie.
    /// </summary>
    public class Movie : ObservableObject
    {
        private string title;
        private int year;
        private string genre;
        private double imdb;
        private int ageLimit;
        private ICollection<MovieActor> movieActors;
        private ICollection<MovieDirector> movieDirectors;

        /// <summary>
        /// Initializes a new instance of the <see cref="Movie"/> class.
        /// </summary>
        public Movie()
        {
            this.MovieDirectors = new ObservableCollection<MovieDirector>();
            this.MovieActors = new ObservableCollection<MovieActor>();
        }

        /// <summary>
        /// Gets all datas of the object.
        /// </summary>
        [NotMapped]
        public string AllData => $"{this.MovieId}, {this.Title}, IMDB:{this.IMDB}, {this.Year}, AgeLimit:{this.AgeLimit}, {this.Genre}";

        /// <summary>
        /// Gets or sets the id of the movie, which is also the primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        /// <summary>
        /// Gets or sets the title of the movie.
        /// </summary>
        [Required]
        public string Title { get => this.title; set => this.Set(ref this.title, value); }

        /// <summary>
        /// Gets or sets the year in which the movie was released.
        /// </summary>
        [Required]
        public int Year { get => this.year; set => this.Set(ref this.year, value); }

        /// <summary>
        /// Gets or sets the genre of the movie.
        /// </summary>
        [Required]
        public string Genre { get => this.genre; set => this.Set(ref this.genre, value); }

        /// <summary>
        /// Gets or sets the imdb point of the movie.
        /// </summary>
        [Required]
        public double IMDB { get => this.imdb; set => this.Set(ref this.imdb, value); }

        /// <summary>
        /// Gets or sets the minimum age limit of the movie.
        /// </summary>
        [Required]
        public int AgeLimit { get => this.ageLimit; set => this.Set(ref this.ageLimit, value); }

        /// <summary>
        /// Gets or sets the connector entity between directors and movies.
        /// </summary>
        [NotMapped]
        public virtual ICollection<MovieDirector> MovieDirectors { get => this.movieDirectors; set => this.Set(ref this.movieDirectors, value); }

        /// <summary>
        /// Gets or sets the connector entity between actors and movies.
        /// </summary>
        [NotMapped]
        public virtual ICollection<MovieActor> MovieActors { get => this.movieActors; set => this.Set(ref this.movieActors, value); }

        /// <summary>
        /// Copies the movie in the paramter to this.
        /// </summary>
        /// <param name="other">Other movie, which will be copied to this movie.</param>
        public void CopyFrom(Movie other)
        {
            if (other != null)
            {
                this.Title = other.Title;
                this.AgeLimit = other.AgeLimit;
                this.MovieId = other.MovieId;
                this.IMDB = other.IMDB;
                this.Year = other.Year;
                this.genre = other.Genre;
                this.MovieActors = other.MovieActors;
                this.MovieDirectors = other.MovieDirectors;
            }
        }
    }
}
