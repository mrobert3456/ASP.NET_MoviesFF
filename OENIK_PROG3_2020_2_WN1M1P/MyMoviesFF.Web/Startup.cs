// <copyright file="Startup.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MyMoviesFF.Data;
    using MyMoviesFF.Logic;
    using MyMoviesFF.Repository;
    using MyMoviesFF.Web.Models;

    /// <summary>
    /// Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">IConfiguration implementation.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Adds services to the container in runtime.
        /// </summary>
        /// <param name="services">IServiceCollection implementation.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IMovieMethods, MovieMethods>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IActingLogic, ActingLogic>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<DbContext, MovieDbContext>();
            services.AddSingleton<IMapper>(provicer => MapperFactory.CreateMapper());

            services.AddControllersWithViews().AddJsonOptions(i => i.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        }

        /// <summary>
        /// Configures the HTTP request pipeline in runtime.
        /// </summary>
        /// <param name="app">IApplicationBuilder implementation.</param>
        /// <param name="env">IWebHostEnvironment implementation.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
