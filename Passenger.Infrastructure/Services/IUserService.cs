using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string username, string fullname, string password);
        Task<UserDto> GetAsync(string email);
    }
}