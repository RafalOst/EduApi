using EduApi.Entities;
using EduApi.Models.Dto;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IAuthorRepository:
        ICreateable<AuthorCreateDto>,
        IDeletable,
        IReadable<Author, AuthorDto>,
        IUpdateable<Author>
    {
    }
}
