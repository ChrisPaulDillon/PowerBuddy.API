using System.Reflection;
using AutoMapper;
using Xunit;

namespace PowerBuddy.UnitTests.AutoMapper
{
    public class MappingProfileTests
    {
        [Fact]
        public void TestAllMappingProfiles_NoErrorsThrown_AreValid()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.Load("PowerBuddy.Data")));

            // Act
            // Assert
            configuration.AssertConfigurationIsValid();
        }
    }
}