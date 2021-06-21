// <copyright file="MovieDbContext.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Data
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the class where the entity tables are declared, where the relationships are defined between the entity classes, and where the tables are filled with datas.
    /// </summary>
    public class MovieDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieDbContext"/> class.
        /// </summary>
        public MovieDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the movie entity table.
        /// </summary>
        public virtual DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Gets or sets the director entity table.
        /// </summary>
        public virtual DbSet<Director> Directors { get; set; }

        /// <summary>
        /// Gets or sets the actor entity table.
        /// </summary>
        public virtual DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// Gets or sets the connector entity table, which connects the movies and the actors.
        /// </summary>
        public virtual DbSet<MovieActor> MovieActors { get; set; }

        /// <summary>
        /// Gets or sets the connector entity table, which connect the movies and the directors.
        /// </summary>
        public virtual DbSet<MovieDirector> MovieDirectors { get; set; }

        /// <summary>
        /// This method is used for the configuration of the sql server.
        /// </summary>
        /// <param name="optionsBuilder"> This parameter is for the initialization of the slq server.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieDb.mdf;Integrated Security=True;MultipleActiveResultSets=true");
        }

        /// <summary>
        /// This method is used for define the relationships of the entities, and for fill the tabels.
        /// </summary>
        /// <param name="modelBuilder">This parameter is for the realtionship definitions.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.ActorId, ma.MovieId });

                modelBuilder.Entity<MovieDirector>().HasKey(ma => new { ma.DirectorId, ma.MovieId });

                modelBuilder.Entity<MovieActor>()
                .HasOne<Actor>(ma => ma.Actor)
                .WithMany(s => s.MovieActors)
                .HasForeignKey(ma => ma.ActorId);
                modelBuilder.Entity<MovieActor>()
                    .HasOne<Movie>(ma => ma.Movie)
                    .WithMany(s => s.MovieActors)
                    .HasForeignKey(ma => ma.MovieId);
                modelBuilder.Entity<MovieDirector>()
              .HasOne<Director>(ma => ma.Director)
              .WithMany(s => s.MovieDirectors)
              .HasForeignKey(ma => ma.DirectorId);
                modelBuilder.Entity<MovieDirector>()
                    .HasOne<Movie>(ma => ma.Movie)
                    .WithMany(s => s.MovieDirectors)
                    .HasForeignKey(ma => ma.MovieId);
                Movie movie1 = new Movie() { MovieId = 1, Title = "Spider-Man: Far From Home", Year = 2019, IMDB = 7.5, Genre = "action", AgeLimit = 13 };
                Movie movie2 = new Movie() { MovieId = 2, Title = "Doctor Strange", Year = 2016, IMDB = 7.5, Genre = "action", AgeLimit = 13 };
                Movie movie3 = new Movie() { MovieId = 3, Title = "The Babysitter", Year = 2017, IMDB = 6.3, Genre = "horror", AgeLimit = 18 };
                Movie movie4 = new Movie() { MovieId = 4, Title = "Hot Fuzz", Year = 2007, IMDB = 7.8, Genre = "comedy", AgeLimit = 18 };
                Movie movie5 = new Movie() { MovieId = 5, Title = "Jumanji", Year = 2017, IMDB = 6.9, Genre = "adventure", AgeLimit = 16 };
                Director director1 = new Director() { DirectorId = 1, DirectorName = "McG", MovieCount = 15, Gender = true, Age = 52, Country = "USA" };
                Director director2 = new Director() { DirectorId = 2, DirectorName = "David Caffrey", MovieCount = 10, Gender = true, Age = 51, Country = "Ireland" };
                Director director3 = new Director() { DirectorId = 3, DirectorName = "Otto Bathurst", MovieCount = 10, Gender = true, Age = 49, Country = "England" };
                Director director4 = new Director() { DirectorId = 4, DirectorName = "Owen Harris", MovieCount = 10, Gender = true, Age = 52, Country = "England" };
                Director director5 = new Director() { DirectorId = 5, DirectorName = "Paul McGuigan", MovieCount = 20, Gender = true, Age = 57, Country = "England" };
                Director director6 = new Director() { DirectorId = 6, DirectorName = "Scott Derrickson", MovieCount = 20, Gender = true, Age = 54, Country = "USA" };
                Director director7 = new Director() { DirectorId = 7, DirectorName = "Jon Watts", MovieCount = 30, Gender = true, Age = 43, Country = "Malaysia" };
                Director director8 = new Director() { DirectorId = 8, DirectorName = "Edgar Wright", MovieCount = 50, Gender = true, Age = 46, Country = "England" };
                Director director9 = new Director() { DirectorId = 9, DirectorName = "Charlie Brooker", MovieCount = 30, Gender = true, Age = 49, Country = "England" };
                Director director10 = new Director() { DirectorId = 10, DirectorName = "Jake Kasdan", MovieCount = 45, Gender = true, Age = 54, Country = "USA" };
                Actor actor1 = new Actor() { ActorId = 1, ActorName = "Tom Holland", Age = 24, MovieCount = 20, Gender = true, Country = "England" };
                Actor actor2 = new Actor() { ActorId = 2, ActorName = "Benedict Cumberbatch", Age = 44, MovieCount = 50, Gender = true, Country = "England" };
                Actor actor3 = new Actor() { ActorId = 3, ActorName = "Simon Pegg", Age = 50, MovieCount = 50, Gender = true, Country = "England" };
                Actor actor4 = new Actor() { ActorId = 4, ActorName = "Samara Weaving", Age = 28, MovieCount = 20, Gender = false, Country = "Australia" };
                Actor actor5 = new Actor() { ActorId = 5, ActorName = "Dwayne Johnson", Age = 48, MovieCount = 50, Gender = true, Country = "USA" };
                Actor actor6 = new Actor() { ActorId = 6, ActorName = "Zendaya", Age = 24, MovieCount = 15, Gender = false, Country = "USA" };
                Actor actor7 = new Actor() { ActorId = 7, ActorName = "Jack Black", Age = 51, MovieCount = 50, Gender = true, Country = "USA" };

                modelBuilder.Entity<Movie>().HasData(movie1, movie2, movie3, movie4, movie5);
                modelBuilder.Entity<Actor>().HasData(actor1, actor2, actor3, actor4, actor5, actor6, actor7);
                modelBuilder.Entity<Director>().HasData(director1, director2, director3, director4, director5, director6, director7, director8, director9, director10);

                MovieActor m1 = new MovieActor() { MovieId = 1, ActorId = 1 };
                MovieActor m2 = new MovieActor() { MovieId = 1, ActorId = 6 };

                MovieActor m3 = new MovieActor() { MovieId = 2, ActorId = 2 };

                MovieActor m4 = new MovieActor() { MovieId = 3, ActorId = 4 };

                MovieActor m5 = new MovieActor() { MovieId = 4, ActorId = 3 };

                MovieActor m6 = new MovieActor() { MovieId = 5, ActorId = 5 };
                MovieActor m7 = new MovieActor() { MovieId = 5, ActorId = 7 };

                modelBuilder.Entity<MovieActor>().HasData(m1, m2, m3, m4, m5, m6, m7);
                MovieDirector d1 = new MovieDirector() { MovieId = 1, DirectorId = 7 };
                MovieDirector d2 = new MovieDirector() { MovieId = 2, DirectorId = 6 };
                MovieDirector d3 = new MovieDirector() { MovieId = 3, DirectorId = 1 };
                MovieDirector d4 = new MovieDirector() { MovieId = 4, DirectorId = 8 };
                MovieDirector d5 = new MovieDirector() { MovieId = 5, DirectorId = 10 };

                modelBuilder.Entity<MovieDirector>().HasData(d1, d2, d3, d4, d5);
            }
        }
    }
}
