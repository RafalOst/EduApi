using AutoMapper;
using EduApi.Entities;
using EduApi.Models.Dto;

namespace EduApi.Services.Profiles
{
    public class EduMappingProfile : Profile
    {
        public EduMappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorUpdateDto>().ReverseMap();
            CreateMap<Author, AuthorCreateDto>().ReverseMap();

            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Material, MateriaUpdatelDto>().ReverseMap();
            CreateMap<Material, MaterialCreateDto>().ReverseMap();

            CreateMap<MaterialType, MaterialTypeDto>().ReverseMap();
            CreateMap<MaterialType, MaterialTypeUpdateDto>().ReverseMap();
            CreateMap<MaterialType, MaterialTypeCreateDto>().ReverseMap();

            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, ReviewUpdateDto>().ReverseMap();
            CreateMap<Review, ReviewCreateDto>().ReverseMap();

        }
    }
}
