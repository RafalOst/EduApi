using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces
{
    public interface ICreateable<Dto> where Dto : class
    {
        Task<int> Add(int id);
    }
}
