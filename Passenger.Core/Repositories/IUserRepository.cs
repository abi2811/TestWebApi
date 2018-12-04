using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository
    {
         Task<User> GetAsync(string email);
         Task<User> GetAsync(Guid id);
         Task<IEnumerable<User>> GetAllAsync();
         Task AddAsync(User user);
         Task UpdateAsync(User user);
         Task RemoveAsync(User user);
    }
}