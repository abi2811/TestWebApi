using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _repository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string username, string fullname, string password)
        {
            await _repository.AddAsync(new User(email, username, fullname, password, "salt"));
        }
    }
}