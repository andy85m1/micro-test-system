using Actio.Common.Auth;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;
using Actio.Services.Identity.Services;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Actio.Services.Identity.Tests.Unit.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task UserService_Login_ShouldReturnJWT()
        {
            var email = "test@test.com";
            var password = "secret";
            var name = "test";
            var salt = "salt";
            var hash = "hash";
            var token = "token";
            var userRepositoryMock = new Mock<IUserRepository>();
            var encryptorMock = new Mock<IEncryptor>();
            var jwtHandlerMock = new Mock<IJwtHandler>();

            encryptorMock.Setup(x => x.GetSalt()).Returns(salt);
            encryptorMock.Setup(x => x.GetHash(password, salt)).Returns(hash);
            jwtHandlerMock.Setup(x => x.Create(It.IsAny<Guid>())).Returns(new JsonWebToken
            {
                Token = token
            });

            var user = new User(email, name);
            user.SetPassword(password, encryptorMock.Object);
            userRepositoryMock.Setup(x => x.GetAsync(email)).ReturnsAsync(user);

            var userService = new UserService(userRepositoryMock.Object, encryptorMock.Object, jwtHandlerMock.Object);

            var jwt = await userService.LoginAsync(email, password);
            userRepositoryMock.Verify(x => x.GetAsync(email), Times.Once);
            jwtHandlerMock.Verify(x => x.Create(It.IsAny<Guid>()), Times.Once);
            jwt.Token.Should().BeEquivalentTo(token);
        }

    }
}
