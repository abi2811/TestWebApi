using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryRepository : IUserRepository
    {
        private static ISet<User> _userDatabase = new HashSet<User>();
        public InMemoryRepository()
        {
            _userDatabase.Add(new User("user1@email.com", "user1", "User First", "secret", "salt"));
            _userDatabase.Add(new User("user2@email.com", "user2", "User Second", "secret", "salt"));
            _userDatabase.Add(new User("user2@email.com", "user3", "User Third", "secret", "salt"));
        }

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_userDatabase.FirstOrDefault(x => x.Email == email));
        
        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_userDatabase.FirstOrDefault(x => x.Id == id));
        
        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_userDatabase.ToList());
        
        public async Task AddAsync(User user)
        {
            _userDatabase.Add(user);
            await Task.CompletedTask;
        }
    
        public async Task RemoveAsync(User user)
        {
            _userDatabase.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}