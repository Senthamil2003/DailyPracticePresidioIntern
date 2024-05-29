using EmployeeManagerApi.BusinessLogic;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using Microsoft.Extensions.Configuration;
using Moq;

namespace EmployeeManagerTester
{
    public class TokenServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

       [Test]
        public void CreateTokenPassTest()
        {
            //Arrange
            Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
            configurationJWTSection.Setup(x => x.Value).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");
            Mock<IConfigurationSection> congigTokenSection = new Mock<IConfigurationSection>();
            congigTokenSection.Setup(x => x.GetSection("JWT")).Returns(configurationJWTSection.Object);
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x=>x.GetSection("TokenKey")).Returns(congigTokenSection.Object);
            ITokenService service = new TokenService(mockConfig.Object);

            //Action
            var token = service.GenerateToken(new Employee { EmployeeId = 103 ,Role="Admin"});
            
            //Assert
            Assert.IsNotNull(token);
        }
    }
    }
