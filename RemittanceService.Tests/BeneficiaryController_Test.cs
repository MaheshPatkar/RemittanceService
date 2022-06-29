using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Remittance_Provider.Controllers;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System.Threading.Tasks;
using Xunit;

namespace RemittanceService.Tests
{
    public class BeneficiaryController_Tests
    {

        [Fact]
        public async Task Get_Test()
        {
            //Arrange
            Mock<IBeneficiaryDAL> beneficiaryDAL = new Mock<IBeneficiaryDAL>();

            BeneficiaryParams beneficiaryParams = new BeneficiaryParams
            {
                accountNumber = 100001,
                bankCode = "CN"
            };

            beneficiaryDAL.Setup(x => x.GetBeneficiaryAsync(beneficiaryParams)).ReturnsAsync("Mahesh");

            BeneficiaryController controller = new BeneficiaryController(beneficiaryDAL.Object);

            //Act
            var response = await controller.Get(beneficiaryParams);
            ObjectResult result = (ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
            Assert.NotNull(result.Value);
        }
    }
}
