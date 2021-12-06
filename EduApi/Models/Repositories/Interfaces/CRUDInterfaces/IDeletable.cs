using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces
{
    public interface IDeletable
    {
        Task Delete(int id);
    }
}
