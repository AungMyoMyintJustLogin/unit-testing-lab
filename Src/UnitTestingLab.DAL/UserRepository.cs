using System.Collections.Concurrent;
using UnitTestingLab.DAL.Entities;

namespace UnitTestingLab.DAL
{
    public class UserRepository : IUserRepository
    {
        private static readonly ConcurrentBag<User> _database = new()
        {
            new User 
            { 
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "John Bily",
                Email = "johnbily@mail.com",
                CreatedDate = DateTimeOffset.UtcNow,
                IsDeleted = false
            },
            new User
            {
                Id = Guid.Parse("45a2a76a-d5c1-4b35-81b4-195088f38770"),
                Name = "Kally Cool",
                Email = "kallycool@mail.com",
                CreatedDate = DateTimeOffset.UtcNow,
                IsDeleted = false
            }
        };

        public IEnumerable<User> Get()
        {
            return _database.Where(u => !u.IsDeleted).ToList();
        }

        public User Get(Guid id)
        {
            return _database.First(u => u.Id == id && !u.IsDeleted);
        }
        public void Create(User user)
        {
            user.CreatedDate = DateTimeOffset.UtcNow;
            _database.Add(user);
        }

        public void Delete(Guid id)
        {
            var user = Get(id);
            if (user is null)
            {
                return;
            }

            user.UpdatedDate = DateTimeOffset.UtcNow;
            user.IsDeleted = true;
        }

        public void Update(Guid id, User user)
        {
            var dbUser = Get(id);
            if (dbUser is null)
            {
                return;
            }

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.UpdatedDate = DateTimeOffset.UtcNow;
        }
    }
}