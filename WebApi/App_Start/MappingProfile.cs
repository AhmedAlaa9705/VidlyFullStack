using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Classes;
using WebApi.DTO;

namespace WebApi.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MemberShipType, MemberShipTypeDto>();
            CreateMap<Genre, GenreDto>();



            CreateMap<CustomerDto, Customer>();
            CreateMap<MovieDto, Movie>();
            CreateMap<NewRentalDto, Rental>();


        }
    }
}