using AutoMapper;
using EduApi.Data;
using EduApi.Entities;
using EduApi.Exceptions;
using EduApi.Models.Dto;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> Add(ReviewCreateDto objectToCreate, int materialId)
        {
            var reviewModel = _mapper.Map<Review>(objectToCreate);
            reviewModel.MaterialId = materialId;

            await _context.Reviews.AddAsync(reviewModel);
            await _context.SaveChangesAsync();

            return reviewModel.Id;
        }

        public async Task Delete(int materialId, int reviewId)
        {

            var material = await _context.Materials.Include(x => x.Reviews).FirstOrDefaultAsync(s => s.Id == materialId);

            var review = material.Reviews.FirstOrDefault(s => s.Id == reviewId);

            if (review is null)
                throw new NotFoundException("Review not found");

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewDto>> GetAllDto(int materialId)
        {
            var material = await _context
                .Materials
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(i => i.Id == materialId);

            var reviews = material.Reviews;

            var reviewsDto = _mapper.Map<List<ReviewDto>>(reviews);

            return reviewsDto;
        }

        public async Task<Review> GetObjectById(int materialId, int reviewId)
        {
            var material = await _context
                .Materials
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(i => i.Id == materialId);

            var review = material.Reviews.FirstOrDefault(i => i.Id == reviewId);

            if (review is null)
                throw new NotFoundException("Review not found");

            return review;
        }

        public async Task<ReviewDto> GetSingleDto(int materialId, int reviewId)
        {
            var material = await _context
             .Materials
             .Include(x => x.Reviews)
             .FirstOrDefaultAsync(i => i.Id == materialId);

            var review = material.Reviews.FirstOrDefault(i => i.Id == reviewId);

            if (review is null)
                throw new NotFoundException("Review not found");

            var reviewDto = _mapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public async Task Update(Review reviewToUpdate)
        {
            if (reviewToUpdate is null)
                throw new NotFoundException("Author not found");

            _context.Reviews.Update(reviewToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
