using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Application.DTOs;
using WillyNet.JunCars.Core.Domain.Entities;

namespace WillyNet.JunCars.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}
