using Actio.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Actio.Api.Tests.Unit.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void HomeController_Get_ShouldReturnStringContent()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Get();            
            var contentResult = result as ContentResult;

            //Assert
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().BeEquivalentTo("Hello from Actio API!");        }
    }
}
