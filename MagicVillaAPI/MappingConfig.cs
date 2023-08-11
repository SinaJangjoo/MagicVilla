using AutoMapper;
using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dto;

namespace MagicVillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa,VillaDTO>().ReverseMap();
            CreateMap<Villa,VillaCreateDTO>().ReverseMap();
            CreateMap<Villa,VillaUpdateDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberUpdateDTO>().ReverseMap();
            //CreateMap<LocalUser,RegisterRequestDTO>().ReverseMap();

        }
    }
}
