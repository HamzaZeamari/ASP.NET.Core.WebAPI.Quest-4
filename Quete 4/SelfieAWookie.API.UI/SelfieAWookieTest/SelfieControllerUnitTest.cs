using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Controllers;

namespace SelfieAWookieTest
{
    public class SelfieControllerUnitTest
    {
        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            
            //ARRANGE

            var controller = new SelfieController();

            //ACT

            var result = controller.Get();

            //ASSERT

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);
            
        }
    }
}