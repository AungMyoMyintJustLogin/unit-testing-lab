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
        public readonly UserService _userService;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }
        #region Create 
        [Fact]
        public void Create_UserWithEmptyName_ThrowNameIsRequired()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = String.Empty, //"John_AungMyo",
                Email = "john_AungMyo@gmail.com"
            };

            // Act
            Action action = () => _userService.Create(payload);

            // Assert
            Assert.Throws<NameIsRequiredException>(action);
        }

        [Fact]
        public void Create_UserWithNullName_ThrowNameIsRequired()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = null, //"John_AungMyo",
                Email = "john_AungMyo@gmail.com"
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
                Name = "John_AungMyo",
                Email = String.Empty
            };

            // Act
            Action action = () => _userService.Create(payload);

            // Assert
            Assert.Throws<EmailIsRequiredException>(action);
        }

        [Fact]
        public void Create_UserWithNull_Email_ThrowEmailIsRequiredException()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John_AungMyo",
                Email = null
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
                Name = "John_AungMyo",
                Email = "john_AungMyo.mail.com"
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
                Name = "John_AungMyo",
                Email = "john_AungMyo@mail.com"
            };

            // Act
            _userService.Create(payload);

            // Assert
            _mockUserRepository.Verify(x => x.Create(It.IsAny<User>()), Times.Once());
        }
        #endregion


        #region Update 
        [Fact]
        public void Update_UserWithEmptyName_ThrowNameIsRequired()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = String.Empty, //"John_AungMyo",
                Email = "john_AungMyo@gmail.com"
            };

            // Act
            Action action = () => _userService.Update(payload.Id, payload);

            // Assert
            Assert.Throws<NameIsRequiredException>(action);
        }

        [Fact]
        public void Update_UserWithNullName_ThrowNameIsRequired()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = null, //"John_AungMyo",
                Email = "john_AungMyo@gmail.com"
            };

            // Act
            Action action = () => _userService.Update(payload.Id, payload);

            // Assert
            Assert.Throws<NameIsRequiredException>(action);
        }

        [Fact]
        public void Update_UserWithEmptyEmail_ThrowEmailIsRequiredException()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John_AungMyo",
                Email = String.Empty
            };

            // Act
            Action action = () => _userService.Update(payload.Id, payload);

            // Assert
            Assert.Throws<EmailIsRequiredException>(action);
        }

        [Fact]
        public void Update_UserWithNull_Email_ThrowEmailIsRequiredException()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John_AungMyo",
                Email = null
            };

            // Act
            Action action = () => _userService.Update(payload.Id, payload);

            // Assert
            Assert.Throws<EmailIsRequiredException>(action);
        }

        [Fact]
        public void Update_UserWithInvalidEmailFormat_ThrowEmailInvalidFormatException()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John_AungMyo",
                Email = "john_AungMyo.mail.com"
            };

            // Act
            Action action = () => _userService.Update(payload.Id, payload);

            // Assert
            Assert.Throws<EmailInvalidFormatException>(action);
        }

        [Fact]
        public void Update_UserWithValidProperties_ShouldUpdateUser()
        {
            // Arrange
            var payload = new User
            {
                Id = Guid.NewGuid(),
                Name = "John_AungMyo",
                Email = "john_AungMyo@mail.com"
            };

            // Act
            _userService.Update(payload.Id, payload);

            // Assert
            _mockUserRepository.Verify(x => x.Update(It.Is<Guid>(x => x == payload.Id), It.IsAny<User>()), Times.Once());
        }
        #endregion
    }
}
