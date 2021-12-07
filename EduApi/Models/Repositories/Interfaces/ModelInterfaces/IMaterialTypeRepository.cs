using EduApi.Entities;
using EduApi.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IMaterialTypeRepository:
        ICreateable<MaterialTypeCreateDto>,
        IDeletable,
        IReadable<MaterialType, MaterialTypeDto>,
        IUpdateable<MaterialType>
    {       
    }
}
