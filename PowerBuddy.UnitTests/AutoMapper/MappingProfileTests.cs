using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Xunit;

namespace PowerBuddy.UnitTests.AutoMapper
{
    public class MappingProfileTests
    {
        [Fact]
        public async Task TestAllMappingProfiles_NoErrorsThrown_AreValid()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.Load("PowerBuddy.Data")));

            // Act
            // Assert
            configuration.AssertConfigurationIsValid();
        }
    }
}