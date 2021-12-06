using AutoMapper;
using EduApi.Data;
using EduApi.Entities;
using EduApi.Models.Dto;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories
{
    public class MaterialTypeRepository : IMaterialTypeRepository
    {
        private readonly EduDbContext _context;
        private readonly IMapper _mapper;

        public MaterialTypeRepository(EduDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> Add(MaterialTypeCreateDto objectToCreate)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MaterialTypeDto>> GetAllDto()
        {
            throw new System.NotImplementedException();
        }

        public Task<MaterialType> GetObjectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<MaterialTypeDto> GetSingleDto(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(MaterialType obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
