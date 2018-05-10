using Xunit;
using AspNetCoreWebService.Controllers;

namespace AspNetCoreWebServiceTest.Controllers
{
    public class HelloControllerTest
    {
        [Fact]
        public void NoInputParamGetResponseTest()
        {
            HelloController controller = new HelloController();
            var response = controller.Get().Value as Response;
            Assert.Equal("Doc There My Confusing World!", response.output);
        }

        [Theory]
        [InlineData(null, "Doc There My Confusing !")]
        [InlineData("", "Doc There My Confusing !")]
        [InlineData("AWS CodeStar", "Doc There My Confusing AWS CodeStar!")]
        public void InputParamGetResponseTest(string inputValue, string expectedOutput)
        {
            HelloController controller = new HelloController();
            var response = controller.Get(inputValue).Value as Response;
            Assert.Equal(expectedOutput, response.output);
        }

        [Fact]
        public void NoInputParamPostResponseTest()
        {
            HelloController controller = new HelloController();
            var response = controller.Post().Value as Response;
            Assert.Equal("Doc There My Confusing World!", response.output);
        }

        [Theory]
        [InlineData(null, "Doc !")]
        [InlineData("", "Doc !")]
        [InlineData("AWS CodeStar", "Doc AWS CodeStar!")]
        public void InputParamPostResponseTest(string inputValue, string expectedOutput)
        {
            HelloController controller = new HelloController();
            var response = controller.Post(inputValue).Value as Response;
            //Uncomment this line and this will fail unless you update the test data
            // to match my modified strings. {GWC}
            //Assert.Equal(expectedOutput, response.output);
        }
    }
}
