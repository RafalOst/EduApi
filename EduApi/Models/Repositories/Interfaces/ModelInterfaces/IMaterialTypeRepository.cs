using EduApi.Entities;
using EduApi.Models.Dto;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IMaterialTypeRepository :
        ICreateable<MaterialTypeCreateDto>,
        IDeletable,
        IReadable<MaterialType, MaterialTypeDto>,
        IUpdateable<MaterialType>
    {
    }
}
