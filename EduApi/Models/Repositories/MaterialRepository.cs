using AutoMapper;
using EduApi.Data;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;

namespace EduApi.Models.Repositories
{
    public class MaterialRepository : IMaterialrRepository
    {
        private readonly EduDbContext _context;
        private readonly IMapper _mapper;

        public MaterialRepository(EduDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
