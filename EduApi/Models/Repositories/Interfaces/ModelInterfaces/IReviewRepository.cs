using EduApi.Entities;
using EduApi.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IReviewRepository:
        IUpdateable<Review>
    {
        Task<int> Add(ReviewCreateDto objectToCreate, int materialId);
        Task Delete(int materialId, int reviewId);
        Task<ReviewDto> GetSingleDto(int materialId, int id);
        Task<Review> GetObjectById(int materialId, int id);
        Task<IEnumerable<ReviewDto>> GetAllDto(int materialId);
    }
}
