using AutoMapper;
using EduApi.Data;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;

namespace EduApi.Models.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EduDbContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(EduDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
