using AutoMapper;
using EduApi.Data;
using EduApi.Entities;
using EduApi.Models.Dto;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<int> Add(ReviewCreateDto objectToCreate)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ReviewDto>> GetAllDto()
        {
            throw new System.NotImplementedException();
        }

        public Task<Review> GetObjectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReviewDto> GetSingleDto(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Review obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
