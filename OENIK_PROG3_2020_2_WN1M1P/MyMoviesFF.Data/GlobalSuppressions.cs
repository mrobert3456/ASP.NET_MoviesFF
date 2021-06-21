// <copyright file="GlobalSuppressions.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Navigation property should have setter property>", Scope = "member", Target = "~P:MyMoviesFF.Data.Movie.MovieDirectors")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Navigation property should have setter property>", Scope = "member", Target = "~P:MyMoviesFF.Data.Movie.MovieActors")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Navigation property should have setter property>", Scope = "member", Target = "~P:MyMoviesFF.Data.Actor.MovieActors")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<There is no need to specify comparison>", Scope = "member", Target = "~M:MyMoviesFF.Data.Actor.GetHashCode~System.Int32")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Navigation property should have setter property>", Scope = "member", Target = "~P:MyMoviesFF.Data.Director.MovieDirectors")]
[assembly: SuppressMessage("", "CA1014", Justification ="<NikGitStats>", Scope = "module")]