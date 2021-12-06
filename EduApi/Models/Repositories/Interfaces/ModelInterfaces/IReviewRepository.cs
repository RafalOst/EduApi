using EduApi.Entities;
using EduApi.Models.Dto;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IReviewRepository:
        ICreateable<ReviewCreateDto>,
        IDeletable,
        IReadable<Review, ReviewDto>,
        IUpdateable<Review>
    {
    }
}
