using EduApi.Models.Dto;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IAccountRepository
    {
        Task RegisterUser(RegisterUserDto dto);
        Task RegisterAdmin(RegisterUserDto dto);
        Task<string> GenerateJwt(LoginDto dto);

    }
}
