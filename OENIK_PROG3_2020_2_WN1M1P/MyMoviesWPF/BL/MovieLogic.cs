// <copyright file="MovieLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyMoviesWPF.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GalaSoft.MvvmLight.Messaging;
    using MyMoviesFF.Data;
    using MyMoviesFF.Logic;

    /// <summary>
    /// Implements IMovieLogic interface.
    /// </summary>
    public class MovieLogic : IMovieLogic
    {
        private IMovieDirectLogic movieDirectLogic;
        private IMovieMakeLogic movieMakeLogic;
        private IMovieEditorService movieEditorService;
        private IMessenger messengerService;
        private IActingLogic actingLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieLogic"/> class.
        /// </summary>
        /// <param name="movieDirectLogic"> Instance of a class which implements IMovieDirectLogic interface.</param>
        /// <param name="movieEditorService"> Instance of a class which implements MovieEditorService interface.</param>
        /// <param name="movieMakeLogic"> Instance of a class which implements IMovieMakeLogic interface.</param>
        /// <param name="messenger"> Instance of a class which implements IMessenger interface.</param>
        /// <param name="actingLogic"> Instance of a class which implements IActingLogic interface.</param>
        public MovieLogic(IMovieDirectLogic movieDirectLogic, IMovieEditorService movieEditorService, IMovieMakeLogic movieMakeLogic, IMessenger messenger, IActingLogic actingLogic)
        {
            this.movieDirectLogic = movieDirectLogic;
            this.movieEditorService = movieEditorService;
            this.movieMakeLogic = movieMakeLogic;
            this.messengerService = messenger;
            this.actingLogic = actingLogic;
        }

        /// <inheritdoc/>
        public IList<Movie> GetAllMovies()
        {
            return this.movieDirectLogic.GetAllMovies();
        }

        /// <inheritdoc/>
        public void AddMovie(IList<Movie> list)
        {
            try
            {
                Movie m = new Movie();
                if (this.movieEditorService.EditMovie(m) && m.MovieId != 0)
                {
                    list?.Add(m);
                    this.movieDirectLogic.InsertNewMovie(m.Title, m.Year, m.Genre, m.IMDB, m.AgeLimit);

                    this.messengerService.Send("ADD OK", "MovieLogicResult");
                }
                else
                {
                    this.messengerService.Send("ADD FAILED", "MovieLogicResult");
                }
            }
            catch (InvalidOperationException)
            {
                this.messengerService.Send("ADD FAILED", "MovieLogicResult");
            }
        }

        /// <inheritdoc/>
        public void ModMovie(ref Movie movie)
        {
            try
            {
                if (movie == null)
                {
                    return;
                }

                Movie clone = new Movie();
                clone.CopyFrom(movie);
                if (this.movieEditorService.EditMovie(clone))
                {
                    movie.CopyFrom(clone);
                    this.movieDirectLogic.GetOneMovie(movie.MovieId).CopyFrom(movie);

                    this.messengerService.Send("EDIT OK", "MovieLogicResult");
                }
                else
                {
                    this.messengerService.Send("EDIT FAILED", "MovieLogicResult");
                }
            }
            catch (InvalidOperationException)
            {
                this.messengerService.Send("EDIT FAILED", "MovieLogicResult");
            }
        }

        /// <inheritdoc/>
        public void DelMovie(IList<Movie> list, ref Movie movie)
        {
            try
            {
                if (movie != null && list != null && list.Remove(movie))
                {
                    this.movieDirectLogic.RemoveMovie(movie);
                    this.messengerService.Send("DELETE OK", "MovieLogicResult");
                }
                else
                {
                    this.messengerService.Send("DELETE FAILED", "MovieLogicResult");
                }
            }
            catch (InvalidOperationException)
            {
                this.messengerService.Send("DELETE FAILED", "MovieLogicResult");
            }
        }

        /// <inheritdoc/>
        public IList<Actor> GetAllActors()
        {
            return this.actingLogic.GetAllActors();
        }

        /// <inheritdoc/>
        public IList<Director> GetAllDirectors()
        {
            return this.movieDirectLogic.GetAllDirectors();
        }

        /// <inheritdoc/>
        public void AddActortoMovie(ref Movie movie, IList<Actor> actors, Actor actor)
        {
            if (movie?.MovieId == 0)
            {
                movie.MovieId = this.movieDirectLogic.GetAllMovies().Select(i => i.MovieId).Max(i => i) + 1;
            }

            if (actor != null && !movie.MovieActors.Any(i => i.ActorId == actor.ActorId))
            {
                actors?.Add(actor);

                MovieActor movieActor = new MovieActor()
                {
                    Actor = actor,
                    ActorId = actor.ActorId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                };

                movie.MovieActors.Add(movieActor);
            }
        }

        /// <inheritdoc/>
        public void DelActorFromMovie(ref Movie movie, IList<Actor> actors, Actor actor)
        {
            if (actor != null)
            {
                actors?.Remove(actor);

                movie?.MovieActors.Remove(movie.MovieActors.Where(i => i.ActorId == actor.ActorId).FirstOrDefault());
            }
        }

        /// <inheritdoc/>
        public void AddDirectortoMovie(ref Movie movie, IList<Director> directors, Director dir)
        {
            if (movie?.MovieId == 0)
            {
                movie.MovieId = this.movieDirectLogic.GetAllMovies().Select(i => i.MovieId).Max(i => i) + 1;
            }

            if (dir != null && !movie.MovieDirectors.Any(i => i.DirectorId == dir.DirectorId))
            {
                directors?.Add(dir);

                MovieDirector movieDirector = new MovieDirector()
                {
                    Movie = movie,
                    MovieId = movie.MovieId,
                    Director = dir,
                    DirectorId = dir.DirectorId,
                };
                movie.MovieDirectors.Add(movieDirector);
            }
        }

        /// <inheritdoc/>
        public void DelDirectorFromMovie(ref Movie movie, IList<Director> directors, Director dir)
        {
            if (dir != null)
            {
                directors?.Remove(dir);
                movie?.MovieDirectors.Remove(movie.MovieDirectors.Where(i => i.DirectorId == dir.DirectorId).FirstOrDefault());
            }
        }
    }
}
