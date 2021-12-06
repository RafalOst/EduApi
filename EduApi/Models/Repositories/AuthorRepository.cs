using AutoMapper;
using EduApi.Data;
using EduApi.Entities;
using EduApi.Models.Dto;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly EduDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(EduDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> Add(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AuthorDto>> GetAllDto()
        {
            throw new System.NotImplementedException();
        }

        public Task<Author> GetObjectById()
        {
            throw new System.NotImplementedException();
        }

        public Task<AuthorDto> GetSingleDto(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Author obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
