﻿using AutoMapper;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;

namespace MagicVilla_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // Villa
            CreateMap<Villa,VillaDTO>();
            CreateMap<VillaDTO,Villa>();
            CreateMap<Villa,VillaCreateDTO>().ReverseMap();
            CreateMap<Villa,VillaUpdateDTO>().ReverseMap();

            //Villa Number 
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();

            CreateMap<ApplicationUser,UserDTO>().ReverseMap();
        }
    }
}