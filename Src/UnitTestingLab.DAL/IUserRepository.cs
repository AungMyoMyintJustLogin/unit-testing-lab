using UnitTestingLab.DAL.Entities;

namespace UnitTestingLab.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(Guid id);
        void Create(User user);
        void Update(Guid id, User user);
        void Delete(Guid id);
    }
}
