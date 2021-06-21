// <copyright file="GlobalSuppressions.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Should be protected because of the inheritence>", Scope = "member", Target = "~F:MyMoviesFF.Repository.BaseRepo`1.ctx")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Need to be visible for inheritence and for other methods>", Scope = "member", Target = "~F:MyMoviesFF.Repository.BaseRepo`1.ctx")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<DbContext fiels should be visible to it's descentants>", Scope = "member", Target = "~F:MyMoviesFF.Repository.ConnRepository`1.ctx")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<DbContext fiels should be visible to it's descentants>", Scope = "member", Target = "~F:MyMoviesFF.Repository.ConnRepository`1.ctx")]
[assembly: SuppressMessage("Design", "CA1012:Abstract types should not have public constructors", Justification = "It must have public constructor in order to work properly.", Scope = "type", Target = "~T:MyMoviesFF.Repository.BaseRepo`1")]
[assembly: SuppressMessage("Design", "CA1012:Abstract types should not have public constructors", Justification = "It must have public constructor in order to work properly.", Scope = "type", Target = "~T:MyMoviesFF.Repository.ConnRepository`1")]
[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]