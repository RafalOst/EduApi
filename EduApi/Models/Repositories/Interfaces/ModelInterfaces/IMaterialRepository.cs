using EduApi.Entities;
using EduApi.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IMaterialRepository :
        ICreateable<MaterialCreateDto>,
        IDeletable,
        IUpdateable<Material>
    {
        Task<MaterialDto> GetSingleDto(int id);
        Task<Material> GetObjectById(int id);
        Task<IEnumerable<MaterialDto>> GetAllDto(SeriesQuery query);
    }
}
