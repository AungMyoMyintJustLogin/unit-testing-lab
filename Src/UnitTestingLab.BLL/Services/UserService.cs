using UnitTestingLab.DAL;
using UnitTestingLab.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace UnitTestingLab.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Get()
        {
            var users = _userRepository.Get();

            return users;
        }

        public User Get(Guid id)
        {
            var user = _userRepository.Get(id);

            return user;
        }

        public void Create(User user)
        {
            // TODO: Domain Validation
            // 1. Check User Name is not null and empty.
            // 2.1. Check User Email is not null and empty.
            // 2.2. Check User Email format with `new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(user.Email)`

            _userRepository.Create(user);
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public void Update(Guid id, User user)
        {
            // TODO: Domain Validation
            // 1. Check User Name is not null and empty.
            // 2.1. Check User Email is not null and empty.
            // 2.2. Check User Email format with `new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(user.Email)`

            _userRepository.Update(id, user);
        }
    }
}