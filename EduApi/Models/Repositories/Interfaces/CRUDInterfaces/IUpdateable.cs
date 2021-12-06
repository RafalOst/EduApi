using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces
{
    public interface IUpdateable<T> where T : class
    {
        Task Update(T obj);
    }
}
