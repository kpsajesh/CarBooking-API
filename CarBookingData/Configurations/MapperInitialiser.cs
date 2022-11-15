﻿using AutoMapper;
using CarBookingData.DataModels;
using CarBookingData.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.Configurations
{
    public class MapperInitialiser: Profile
    {
        public MapperInitialiser()
        {
            CreateMap<Style, CreateStyleDTO>().ReverseMap();
            CreateMap<Style, StyleDTO>().ReverseMap();

            CreateMap<Make, CreateMakeDTO>().ReverseMap();
            CreateMap<Make, MakeDTO>().ReverseMap();

            CreateMap<CarModel, CreateCarModelDTO>().ReverseMap();
            CreateMap<CarModel, CarModelDTO>().ReverseMap();

            CreateMap<Car, CreateCarDTO>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();
        }
    }
}