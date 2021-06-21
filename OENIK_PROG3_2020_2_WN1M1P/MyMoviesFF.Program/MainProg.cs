// <copyright file="MainProg.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Program
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using ConsoleTools;
    using Microsoft.Win32.SafeHandles;
    using MyMoviesFF.Data;
    using MyMoviesFF.Logic;
    using MyMoviesFF.Repository;

    /// <summary>
    /// This is the main program.
    /// </summary>
    public static class MainProg
    {
        /// <summary>
        /// This is the main method, which is the entry point for the program.
        /// </summary>
        public static void Main()
        {
            MovieDbContext ctx = Factory.CreateMovieDbContext();
            DirectorRepository directorrepo = Factory.CreateDirectorRepository(ctx);
            ActorRepository actorrepo = Factory.CreateActorRepository(ctx);
            MovieRepository movierepo = Factory.CreateMovieRepository(ctx, actorrepo, directorrepo);
            MovieActorRepository movieactorrepo = Factory.CreateMovieActorRepository(ctx, actorrepo, movierepo);
            MovieDirectorRepository moviedirrepo = Factory.CreateMovieDirectorRepository(ctx, directorrepo, movierepo);
            ActingLogic actingLogic = Factory.CreateActingLogic(movierepo, actorrepo, movieactorrepo);
            MovieDirectLogic movieDirectLogic = Factory.CreateMovieDirectLogic(movierepo, directorrepo, moviedirrepo);
            MovieMakeLogic movieMakeLogic = Factory.CreateMovieMakeLogic(movierepo, movieactorrepo, moviedirrepo);
            ShowMenu(directorrepo, actorrepo, movierepo, actingLogic, movieDirectLogic, movieMakeLogic);
        }

        /// <summary>
        /// Shows the console menu.
        /// </summary>
        /// <param name="directorrepo">DirectorRepository object.</param>
        /// <param name="actorrepo">ActorRepository object.</param>
        /// <param name="movierepo">MovieRepository object.</param>
        /// <param name="actingLogic">ActingLogic object.</param>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        /// <param name="movieMakeLogic">MovieMakeLogic object.</param>
        public static void ShowMenu(DirectorRepository directorrepo, ActorRepository actorrepo, MovieRepository movierepo, ActingLogic actingLogic, MovieDirectLogic movieDirectLogic, MovieMakeLogic movieMakeLogic)
        {
            try
            {
                var menu = new ConsoleMenu()
                 .Add("List all", () => ListAll(movierepo, directorrepo, actorrepo))
                 .Add("Movies", () => new ConsoleMenu()
                 .Add("List all movies", () => ListAllMovies(movierepo))
                 .Add("Get one movie", () => GetOneMovie(actingLogic))
                 .Add("Remove one movie", () => RemoveMovie(actingLogic))
                 .Add("Add new movie", () => InsertNewMovie(actingLogic))
                 .Add("Change movie IMDB score", () => ChangeIMDB(actingLogic))
                 .Add("Add actor to a movie", () => AddActorToMovie(movieMakeLogic, movierepo, actorrepo))
                 .Add("Add director to a movie", () => AddDirectorToMovie(movieMakeLogic, movierepo, directorrepo))
                 .Add("Remove an actor from a movie", () => RemoveActorFromMovie(movieMakeLogic, movierepo))
                 .Add("Remove a director from a movie", () => RemoveDirectorFromMovie(movieMakeLogic, movierepo))
                 .Add("Back", i => i.CloseMenu()).Show())
                 .Add("Actors", () => new ConsoleMenu()
                 .Add("List all actors", () => ListAllActors(actorrepo))
                 .Add("Get one actor", () => GetOneActor(actingLogic))
                 .Add("Remove one actor", () => RemoveActor(actingLogic))
                 .Add("Add new actor", () => InsertNewActor(actingLogic))
                 .Add("Change an actor's age", () => ChangeAge(actingLogic))
                 .Add("Back", i => i.CloseMenu()).Show())
                 .Add("Directors", () => new ConsoleMenu()
                 .Add("List all directors", () => ListAllDirectors(directorrepo))
                 .Add("Get one director", () => GetOneDirector(movieDirectLogic))
                 .Add("Remove one director", () => RemoveDirector(movieDirectLogic))
                 .Add("Add new director", () => InsertNewDirector(movieDirectLogic))
                 .Add("Change a director's country", () => ChangeCountry(movieDirectLogic))
                 .Add("Back", i => i.CloseMenu()).Show())
                 .Add("Non-crud methods", () => new ConsoleMenu()
                 .Add("Get the avarage age among the actors", () => GetAVGActorAge(actingLogic))
                 .Add("Get the avarage age among the directors", () => GetAVGDirectorAge(movieDirectLogic))
                 .Add("Lists actor count in every country", () => GetActorCountPerCountries(actingLogic))
                 .Add("Lists director count in every country", () => GetDirectorsCountPerCountries(movieDirectLogic))
                 .Add("Lists movies and it's actors", () => GetActorsPerMovies(actingLogic))
                 .Add("List the directors and his/her movies", () => GetMoviesPerDirectors(movieDirectLogic))
                 .Add("List movies and it's actors, and directors", () => GetActorsDirectorsPerMovies(movieMakeLogic))
                 .Add("Lists actor count in every country (Async version)", () => GetActorCountPerCountriesAsync(actingLogic))
                 .Add("Lists director count in every country (Async version)", () => GetDirectorsCountPerCountriesAsync(movieDirectLogic))
                 .Add("Lists movies and it's actors (Async version)", () => GetActorsPerMoviesAsync(actingLogic))
                 .Add("List the directors and his/her movies (Async version)", () => GetMoviesPerDirectorsAsync(movieDirectLogic))
                 .Add("List movies and it's actors, and directors (Async version)", () => GetActorsDirectorsPerMoviesAsync(movieMakeLogic))
                 .Add("Back", i => i.CloseMenu()).Show())
                 .Add("Exit", () => Environment.Exit(0));

                menu.Show();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error message: " + e.Message);
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
                ShowMenu(directorrepo, actorrepo, movierepo, actingLogic, movieDirectLogic, movieMakeLogic);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error message: " + e.Message);
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
                ShowMenu(directorrepo, actorrepo, movierepo, actingLogic, movieDirectLogic, movieMakeLogic);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error message: " + e.Message);
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
                ShowMenu(directorrepo, actorrepo, movierepo, actingLogic, movieDirectLogic, movieMakeLogic);
            }
        }

        /// <summary>
        /// Lists all three table datas.
        /// </summary>
        /// <param name="movierepo">MovieRepository object.</param>
        /// <param name="directorrepo">DirectorRepository object.</param>
        /// <param name="actorrepo">ActorRepository object.</param>
        public static void ListAll(MovieRepository movierepo, DirectorRepository directorrepo, ActorRepository actorrepo)
        {
            ListAllMovies(movierepo);
            ListAllActors(actorrepo);
            ListAllDirectors(directorrepo);
        }

        /// <summary>
        /// Lists all movies.
        /// </summary>
        /// <param name="movierepo">MovieRepository object.</param>
        public static void ListAllMovies(MovieRepository movierepo)
        {
            if (movierepo != null)
            {
                IQueryable<Movie> movies = movierepo.GetAll();
                if (movies != null)
                {
                    foreach (var item in movies)
                    {
                        Console.WriteLine(item.AllData);
                    }
                }
                else
                {
                    throw new NullReferenceException("Object Movie is null!");
                }
            }
            else
            {
                throw new NullReferenceException("Object MovieRepo is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        ///  Lists all actors.
        /// </summary>
        /// <param name="actorrepo">ActorRepository object.</param>
        public static void ListAllActors(ActorRepository actorrepo)
        {
            if (actorrepo != null)
            {
                IQueryable<Actor> actors = actorrepo.GetAll();
                if (actors != null)
                {
                    foreach (var item in actors)
                    {
                        Console.WriteLine(item.AllData);
                    }
                }
                else
                {
                    throw new NullReferenceException("Object Actor is null!");
                }
            }
            else
            {
                throw new NullReferenceException("Object ActorRepo is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Lists all directors.
        /// </summary>
        /// <param name="directorrepo">DirectorRepository object.</param>
        public static void ListAllDirectors(DirectorRepository directorrepo)
        {
            if (directorrepo != null)
            {
                IQueryable<Director> dirs = directorrepo.GetAll();
                if (dirs != null)
                {
                    foreach (var item in dirs)
                    {
                        Console.WriteLine(item.AllData);
                    }
                }
                else
                {
                    throw new NullReferenceException("Object Director is null!");
                }
            }
            else
            {
                throw new NullReferenceException("Object DirectorRepo is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Determine the avarage age among actors.
        /// </summary>
        /// <param name="actingLogic">ActorRepository object.</param>
        public static void GetAVGActorAge(ActingLogic actingLogic)
        {
            if (actingLogic != null)
            {
                Console.WriteLine("Avarage actor age: " + Math.Round(actingLogic.AVGActorAge()) + " year.");
            }
            else
            {
                throw new NullReferenceException("Object ActingLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Determine the avarage age among directors.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void GetAVGDirectorAge(MovieDirectLogic movieDirectLogic)
        {
            if (movieDirectLogic != null)
            {
                Console.WriteLine("Avarage director age: " + Math.Round(movieDirectLogic.AVGDirectorAge()) + " year.");
            }
            else
            {
                throw new NullReferenceException("Object MovieDirectLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets how many directors living in every country stored in the database.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void GetDirectorsCountPerCountries(MovieDirectLogic movieDirectLogic)
        {
            if (movieDirectLogic != null)
            {
                IList<DirectorsCountPerCountries> dirs = movieDirectLogic.GetDirectorCountPerCountries();
                if (dirs != null || dirs.Count == 0)
                {
                    foreach (var item in dirs)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero elemenent!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object MovieDirectLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets how many actors living in every country stored in the database.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void GetActorCountPerCountries(ActingLogic actingLogic)
        {
            if (actingLogic != null)
            {
                IList<ActorCountPerCountries> actors = actingLogic.GetActorCountPerCountries();
                if (actors != null || actors.Count == 0)
                {
                    foreach (var item in actors)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero elemenent!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object ActingLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Calls the Async version of GetDirectorsCountPerCountries method.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void GetDirectorsCountPerCountriesAsync(MovieDirectLogic movieDirectLogic)
        {
            if (movieDirectLogic != null)
            {
                IList<DirectorsCountPerCountries> dirs = movieDirectLogic.GetDirectorCountPerCountriesAsync().Result;
                if (dirs != null || dirs.Count == 0)
                {
                    foreach (var item in dirs)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero elemenent!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object MovieDirectLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Calls the Async version of GetActorCountPerCountries method.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void GetActorCountPerCountriesAsync(ActingLogic actingLogic)
        {
            if (actingLogic != null)
            {
                IList<ActorCountPerCountries> actors = actingLogic.GetActorCountPerCountriesAsync().Result;
                if (actors != null || actors.Count == 0)
                {
                    foreach (var item in actors)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero elemenent!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object ActingLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        ///  Insert a new actor to the database.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void InsertNewActor(ActingLogic actingLogic)
        {
            Console.Write("\nActor name: ");
            string actorname = Console.ReadLine();
            Console.Write("\nGender(true-male, false-female): ");
            bool gender = Convert.ToBoolean(Console.ReadLine());
            Console.Write("\nAge: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("\nHow many movies had the actor?: ");
            int moviecount = int.Parse(Console.ReadLine());
            Console.Write("\nCountry: ");
            string country = Console.ReadLine();

            if (actingLogic != null)
            {
                actingLogic.InsertNewActor(actorname, gender, age, moviecount, country);
                Console.WriteLine("Actor has been inserted.");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object ActingLogic is null!");
            }
        }

        /// <summary>
        /// Insert a new movie to the database.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void InsertNewMovie(ActingLogic actingLogic)
        {
            Console.Write("\nTitle of the movie: ");
            string title = Console.ReadLine();
            Console.Write("\nRelease year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("\nMovie genre: ");
            string genre = Console.ReadLine();
            Console.Write("\nIMDB score: ");
            double imdb = double.Parse(Console.ReadLine());
            Console.Write("\nAge limit: ");
            int agelimit = int.Parse(Console.ReadLine());
            if (actingLogic != null)
            {
                actingLogic.InsertNewMovie(title, year, genre, imdb, agelimit);
                Console.WriteLine("Movie has been inserted.");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object ActingLogic is null!");
            }
        }

        /// <summary>
        /// Insert a new director to the database.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void InsertNewDirector(MovieDirectLogic movieDirectLogic)
        {
            Console.Write("\nDirector name: ");
            string directorName = Console.ReadLine();
            Console.Write("\nHow many movies were directed by this director?: ");
            int movieCount = int.Parse(Console.ReadLine());
            Console.Write("\nGender(true-male, false-female): ");
            bool gender = Convert.ToBoolean(Console.ReadLine());
            Console.Write("\nCountry: ");
            string country = Console.ReadLine();
            Console.Write("\nAge: ");
            int age = int.Parse(Console.ReadLine());

            if (movieDirectLogic != null)
            {
                movieDirectLogic.InsertNewDirector(directorName, movieCount, gender, country, age);
                Console.WriteLine("Director has been inserted.");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object MovieDirectLogic is null!");
            }
        }

        /// <summary>
        /// Removes a movie from the database.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void RemoveMovie(ActingLogic actingLogic)
        {
            Console.Write("Movie id: ");
            int movieid = int.Parse(Console.ReadLine());
            if (actingLogic != null)
            {
                bool s = actingLogic.RemoveMovie(actingLogic.GetOneMovie(movieid));
                Console.WriteLine(s == true ? "Movie was removed successfully." : "Movie cannot be removed!");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Removes an actor from the database.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void RemoveActor(ActingLogic actingLogic)
        {
            Console.Write("Actor id: ");
            int actorid = int.Parse(Console.ReadLine());
            if (actingLogic != null)
            {
                bool s = actingLogic.RemoveActor(actingLogic.GetOneActor(actorid));
                Console.WriteLine(s == true ? "Actor was removed successfully." : "Actor cannot be removed!");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Removes a director from the database.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void RemoveDirector(MovieDirectLogic movieDirectLogic)
        {
            Console.Write("Director id: ");
            int directorid = int.Parse(Console.ReadLine());
            if (movieDirectLogic != null)
            {
                bool s = movieDirectLogic.RemoveDirector(movieDirectLogic.GetOneDirector(directorid));
                Console.WriteLine(s == true ? "Director was removed successfully." : "Director cannot be removed!");

                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// This method changes the birth country of the actor.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void ChangeCountry(MovieDirectLogic movieDirectLogic)
        {
            Console.Write("Director id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("\nNew country: ");
            string newcountry = Console.ReadLine();

            if (movieDirectLogic != null)
            {
                movieDirectLogic.ChangeCountry(id, newcountry);
                Console.WriteLine("Country has been modified.");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object MovieDirectLogic is null!!");
            }
        }

        /// <summary>
        /// Changes the imdb score of a specified movie object.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void ChangeIMDB(ActingLogic actingLogic)
        {
            Console.Write("Movie id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("\nNew IMDB: ");
            int newimdb = int.Parse(Console.ReadLine());

            if (actingLogic != null)
            {
                actingLogic.ChangeIMDB(id, newimdb);
                Console.WriteLine("IMDB score has been modified.");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object ActingLogic is null!!");
            }
        }

        /// <summary>
        /// This method changes the age of actor.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void ChangeAge(ActingLogic actingLogic)
        {
            Console.Write("Actor id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("\nNew age: ");
            int newage = int.Parse(Console.ReadLine());

            if (actingLogic != null)
            {
                actingLogic.ChangeAge(id, newage);
                Console.WriteLine("Actor's age has been modified.");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object ActingLogic is null!!");
            }
        }

        /// <summary>
        /// Gets one actor.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void GetOneActor(ActingLogic actingLogic)
        {
            Console.Write("Actor id: ");
            int id = int.Parse(Console.ReadLine());
            if (actingLogic != null)
            {
                Actor actor = actingLogic.GetOneActor(id);
                Console.WriteLine(actor == null ? "Object actor is null!" : actor.AllData);
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object ActingLogic is null!");
            }
        }

        /// <summary>
        /// Gets one movie.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void GetOneMovie(ActingLogic actingLogic)
        {
            Console.Write("Movie id: ");
            int id = int.Parse(Console.ReadLine());
            if (actingLogic != null)
            {
                Movie movie = actingLogic.GetOneMovie(id);
                Console.WriteLine(movie == null ? "Object movie is null!" : movie.AllData);

                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object ActingLogic is null!");
            }
        }

        /// <summary>
        /// Gets one specified director.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void GetOneDirector(MovieDirectLogic movieDirectLogic)
        {
            Console.Write("Director id: ");
            int id = int.Parse(Console.ReadLine());
            if (movieDirectLogic != null)
            {
                Director director = movieDirectLogic.GetOneDirector(id);
                Console.WriteLine(director == null ? "Object director is null!" : director.AllData);

                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            else
            {
                throw new InvalidOperationException("Object MovieDirectLogic is null!");
            }
        }

        /// <summary>
        /// Gets the movies and the actors who played in them.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void GetActorsPerMovies(ActingLogic actingLogic)
        {
            if (actingLogic != null)
            {
                IList<ActorsPerMovies> result = actingLogic.GetActorsPerMovies();
                if (result.Count != 0)
                {
                    foreach (var movie in result)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero element!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object ActingLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets the directors and his/her movies.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void GetMoviesPerDirectors(MovieDirectLogic movieDirectLogic)
        {
            if (movieDirectLogic != null)
            {
                IList<MoviesPerDirectors> result = movieDirectLogic.GetMoviesPerDirectors();
                if (result.Count != 0)
                {
                    foreach (var movie in result)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero element!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object MovieDirectLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        ///  Gets the movies and it's actors, and directors.
        /// </summary>
        /// <param name="movieMakeLogic">MovieMakeLogic object.</param>
        public static void GetActorsDirectorsPerMovies(MovieMakeLogic movieMakeLogic)
        {
            if (movieMakeLogic != null)
            {
                IList<ActorsDirectorsPerMovies> result = movieMakeLogic.GetActorsDirectorPerMovies();
                if (result.Count != 0)
                {
                    foreach (var movie in result)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero element!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object MovieMakeLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Calls the Async version of GetActorsPerMovies method.
        /// </summary>
        /// <param name="actingLogic">ActingLogic object.</param>
        public static void GetActorsPerMoviesAsync(ActingLogic actingLogic)
        {
            if (actingLogic != null)
            {
                IList<ActorsPerMovies> result = actingLogic.GetActorsPerMoviesAsync().Result;
                if (result.Count != 0)
                {
                    foreach (var movie in result)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero element!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object ActingLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Calls the Async version of GetMoviesPerDirectors method.
        /// </summary>
        /// <param name="movieDirectLogic">MovieDirectLogic object.</param>
        public static void GetMoviesPerDirectorsAsync(MovieDirectLogic movieDirectLogic)
        {
            if (movieDirectLogic != null)
            {
                IList<MoviesPerDirectors> result = movieDirectLogic.GetMoviesPerDirectorsAsync().Result;
                if (result.Count != 0)
                {
                    foreach (var movie in result)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero element!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object MovieDirectLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Calls the Async version of GetActorsDirectorsPerMovies method.
        /// </summary>
        /// <param name="movieMakeLogic">MovieMakeLogic object.</param>
        public static void GetActorsDirectorsPerMoviesAsync(MovieMakeLogic movieMakeLogic)
        {
            if (movieMakeLogic != null)
            {
                IList<ActorsDirectorsPerMovies> result = movieMakeLogic.GetActorsDirectorPerMoviesAsync().Result;
                if (result.Count != 0)
                {
                    foreach (var movie in result)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
                else
                {
                    throw new NullReferenceException("Result returned zero element!!");
                }
            }
            else
            {
                throw new NullReferenceException("Object MovieMakeLogic is null!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Add an actor to a film.
        /// </summary>
        /// <param name="movieMakeLogic">MovieMakeLogic object.</param>
        /// <param name="movieRepository">MovieRepository object.</param>
        /// <param name="actorRepository">ActorRepository object.</param>
        public static void AddActorToMovie(MovieMakeLogic movieMakeLogic, MovieRepository movieRepository, ActorRepository actorRepository)
        {
            Console.WriteLine("You can choose a movie from the following list:");
            ListAllMovies(movieRepository);
            Console.Write("Movie Id:");
            int movieid = int.Parse(Console.ReadLine());

            Console.WriteLine("Which actor do you want to add?");
            ListAllActors(actorRepository);
            Console.Write("\nActor Id:");
            int actorid = int.Parse(Console.ReadLine());

            if (movieMakeLogic != null)
            {
                movieMakeLogic.AddActor(movieid, actorid);
            }
            else
            {
                throw new InvalidOperationException("Object MovieMakeLogic is null!!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Add a director to a movie.
        /// </summary>
        /// <param name="movieMakeLogic">MovieMakeLogic object.</param>
        /// <param name="movieRepository">MovieRepository object.</param>
        /// <param name="directorRepository">DirectorRepository object.</param>
        public static void AddDirectorToMovie(MovieMakeLogic movieMakeLogic, MovieRepository movieRepository, DirectorRepository directorRepository)
        {
            Console.WriteLine("You can choose a movie from the following list:");
            ListAllMovies(movieRepository);
            Console.Write("Movie Id:");
            int movieid = int.Parse(Console.ReadLine());

            Console.WriteLine("Which director do you want to add?");
            ListAllDirectors(directorRepository);
            Console.Write("\nDirector Id:");
            int directorid = int.Parse(Console.ReadLine());

            if (movieMakeLogic != null)
            {
                movieMakeLogic.AddDirector(movieid, directorid);
            }
            else
            {
                throw new InvalidOperationException("Object MovieMakeLogic is null!!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Removes an actor from a movie.
        /// </summary>
        /// <param name="movieMakeLogic">MovieMakeLogic object.</param>
        /// <param name="movieRepository">MovieRepository object.</param>
        public static void RemoveActorFromMovie(MovieMakeLogic movieMakeLogic, MovieRepository movieRepository)
        {
            Console.WriteLine("You can choose a movie from the following list:");
            ListAllMovies(movieRepository);
            Console.Write("Movie Id:");
            int movieid = int.Parse(Console.ReadLine());

            Movie movie = movieRepository.GetOne(movieid);
            if (movieRepository != null && movie != null)
            {
                Console.WriteLine("Which actor do you want to remove?");
                movie.MovieActors.Select(i => i.Actor.AllData).ToList().ForEach(i => Console.WriteLine(i));
            }
            else
            {
                throw new InvalidOperationException("Movie table cannot be reached.");
            }

            Console.Write("\nActor Id:");
            int actorid = int.Parse(Console.ReadLine());

            if (movieMakeLogic != null)
            {
                movieMakeLogic.RemoveActor(movieid, actorid);
            }
            else
            {
                throw new InvalidOperationException("Object MovieMakeLogic is null!!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Removes a director from a movie.
        /// </summary>
        /// <param name="movieMakeLogic">MovieMakeLogic object.</param>
        /// <param name="movieRepository">MovieRepository object.</param>
        public static void RemoveDirectorFromMovie(MovieMakeLogic movieMakeLogic, MovieRepository movieRepository)
        {
            Console.WriteLine("You can choose a movie from the following list:");
            ListAllMovies(movieRepository);
            Console.Write("Movie Id:");
            int movieid = int.Parse(Console.ReadLine());

            Movie movie = movieRepository.GetOne(movieid);
            if (movieRepository != null && movie != null)
            {
                Console.WriteLine("Which director do you want to remove?");
                movieRepository.GetOne(movieid).MovieDirectors.Select(i => i.Director.AllData).ToList().ForEach(i => Console.WriteLine(i));
            }
            else
            {
                throw new InvalidOperationException("Movie table cannot be reached.");
            }

            Console.Write("\nDirector Id:");
            int directorid = int.Parse(Console.ReadLine());

            if (movieMakeLogic != null)
            {
                movieMakeLogic.RemoveDirector(movieid, directorid);
            }
            else
            {
                throw new InvalidOperationException("Object MovieMakeLogic is null!!");
            }

            Console.WriteLine("Press Enter to continue....");
            Console.ReadLine();
        }
    }
}
