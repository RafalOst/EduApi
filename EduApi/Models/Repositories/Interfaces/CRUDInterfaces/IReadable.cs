using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces
{
    public interface IReadable<T, Dto> where T : class
    {
        Task<Dto> GetSingleDto(int id);
        Task<T> GetObjectById(int id);
        Task<IEnumerable<Dto>> GetAllDto();
      
    }
}
