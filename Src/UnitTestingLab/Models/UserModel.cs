using UnitTestingLab.DAL.Entities;

namespace UnitTestingLab.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public UserModel()
        {

        }

        public UserModel(User entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Email = entity.Email;
        }

        public User ToEntity()
        {
            return new User
            {
                Id = Id,
                Name = Name ?? String.Empty,
                Email = Email ?? String.Empty
            };
        }
    }
}
