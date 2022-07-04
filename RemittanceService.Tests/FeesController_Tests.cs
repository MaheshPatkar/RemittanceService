using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Remittance_Provider.Controllers;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RemittanceService.Tests
{
    public class FeesController_Tests
    {
        [Fact]
        public async Task Get_Test()
        {
            //Arrange

            Mock<IFeesDAL> feesDAL = new Mock<IFeesDAL>();
            FeesParams feesParams = new FeesParams();

            List<FeesReadDto> feeslist = new List<FeesReadDto>
            {
                new FeesReadDto{amount = "1000",fee="100" },
                new FeesReadDto{amount = "2000",fee="200" },
                new FeesReadDto{amount = "3000",fee="150" },
                new FeesReadDto{amount = "6000",fee="200" }
            };


            feesDAL.Setup(x => x.GetFees(feesParams)).ReturnsAsync(feeslist);
            FeesController controller = new FeesController(feesDAL.Object);

            //Act
            var response = await controller.Get(feesParams);

            ObjectResult result = (ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
            Assert.NotNull(result.Value);
        }


    }
}
