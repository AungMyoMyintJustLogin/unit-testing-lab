using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingLab.BLL.Exceptions;
using UnitTestingLab.BLL.Services;
using UnitTestingLab.DAL;
using UnitTestingLab.DAL.Entities;

namespace UnitTestingLab.BLL.UnitTests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public void Create_UserWithEmptyName_ThrowNameIsRequiredException()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = String.Empty,
                Email = "john@mail.com"
            };

            // Act
            Action action = () => _userService.Create(payload);

            // Assert
            Assert.Throws<NameIsRequiredException>(action);
        }

        [Fact]
        public void Create_UserWithEmptyEmail_ThrowEmailIsRequiredException()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = String.Empty
            };

            // Act
            Action action = () => _userService.Create(payload);

            // Assert
            Assert.Throws<EmailIsRequiredException>(action);
        }

        [Fact]
        public void Create_UserWithInvalidEmailFormat_ThrowEmailInvalidFormatException()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "john.mail.com"
            };

            // Act
            Action action = () => _userService.Create(payload);

            // Assert
            Assert.Throws<EmailInvalidFormatException>(action);
        }

        [Fact]
        public void Create_UserWithValidProperties_ShouldCreateUser()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "john@mail.com"
            };

            // Act
            _userService.Create(payload);

            // Assert
            _mockUserRepository.Verify(m => m.Create(It.IsAny<User>()), Times.Once);
        }


        [Fact]
        public void Update_UserWithNullName_ThrowNameIsRequiredException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var payload = new User
            {
                Id = userId,
                Name = null,
                Email = "john@mail.com"
            };

            // Act
            Action action = () => _userService.Update(userId, payload);

            // Assert
            Assert.Throws<NameIsRequiredException>(action);
        }

        [Fact]
        public void Update_UserWithNullEmail_ThrowEmailIsRequiredException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var payload = new User
            {
                Id = userId,
                Name = "John",
                Email = null
            };

            // Act
            Action action = () => _userService.Update(userId, payload);

            // Assert
            Assert.Throws<EmailIsRequiredException>(action);
        }

        [Fact]
        public void Update_UserWithInvalidEmailFormat_ThrowEmailInvalidFormatException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var payload = new User
            {
                Id = userId,
                Name = "John",
                Email = "john@mail@com"
            };

            // Act
            Action action = () => _userService.Update(userId, payload);

            // Assert
            Assert.Throws<EmailInvalidFormatException>(action);
        }

        [Fact]
        public void Update_UserWithValidProperties_ShouldUpdateUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var payload = new User
            {
                Id = userId,
                Name = "John",
                Email = "john@mail.com"
            };

            // Act
            _userService.Update(userId, payload);

            // Assert
            _mockUserRepository.Verify(
                m => m.Update(
                    It.Is<Guid>(x => x == userId), 
                    It.IsAny<User>()),
                Times.Once);
        }

    }
}
