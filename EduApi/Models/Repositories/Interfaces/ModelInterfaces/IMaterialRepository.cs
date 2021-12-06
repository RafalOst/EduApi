using EduApi.Entities;
using EduApi.Models.Dto;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IMaterialRepository:
        ICreateable<MaterialCreateDto>,
        IDeletable,
        IReadable<Material, MaterialDto>,
        IUpdateable<Material>
    {
    }
}
