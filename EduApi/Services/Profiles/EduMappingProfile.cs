using AutoMapper;
using EduApi.Entities;
using EduApi.Models.Dto;
using System.Linq;

namespace EduApi.Services.Profiles
{
    public class EduMappingProfile : Profile
    {
        public EduMappingProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(x => x.PublishedMaterials, s => s.MapFrom(s => s.Materials.Count()));
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorUpdateDto>().ReverseMap();
            CreateMap<Author, AuthorCreateDto>().ReverseMap();

            CreateMap<Material, MaterialDto>()
                .ForMember(x => x.PublishDate, s => s.MapFrom(s => s.PublishDate.ToShortDateString()))
                .ForMember(x => x.Author, s => s.MapFrom(s => s.Author.Name.ToString()))
                .ForMember(x => x.MaterialType, s => s.MapFrom(s => s.MaterialType.Name.ToString()));
            CreateMap<MaterialDto, Material>();
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
