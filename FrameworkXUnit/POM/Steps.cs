using FrameworkXUnit1.Config;
using Xunit;

namespace FrameworkXUnit1.Tests
{
    [CollectionDefinition(nameof(AutomationWebFixtureCollection))]
    public class Steps
    {

        private readonly AutomationWebTestsFixture _testsFixture;
        private readonly ConfigurationHelper _config;

        public Steps(AutomationWebTestsFixture testsFixture)
        {
            _config = new ConfigurationHelper();
        }

        [Fact]
        public void Test1()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}