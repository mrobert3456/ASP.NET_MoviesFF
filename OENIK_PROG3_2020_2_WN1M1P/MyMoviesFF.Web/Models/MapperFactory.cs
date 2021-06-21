// <copyright file="MapperFactory.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;

    /// <summary>
    /// Mapper which converts MyMoviesFF.Data.Actor to MyMoviesFF.Web.Model.Actor and back.
    /// </summary>
    public static class MapperFactory
    {
        /// <summary>
        /// Converts MyMoviesFF.Data.Actor to MyMoviesFF.Web.Model.Actor and back.
        /// </summary>
        /// <returns>Returns an IMapper.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyMoviesFF.Data.Actor, Actor>()
                .ForMember(dest => dest.ActorId, map => map.MapFrom(src => src.ActorId))
                .ForMember(dest => dest.ActorName, map => map.MapFrom(src => src.ActorName))
                .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, map => map.MapFrom(src => src.Age))
                .ForMember(dest => dest.Country, map => map.MapFrom(src => src.Country))
                .ForMember(dest => dest.MovieCount, map => map.MapFrom(src => src.MovieCount))
                .ForMember(dest => dest.MovieActors, map => map.MapFrom(src => src.MovieActors));
            });

            return config.CreateMapper();
        }
    }
}
