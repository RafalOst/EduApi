using AutoMapper;
using EduApi.Data;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;

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
    }
}
