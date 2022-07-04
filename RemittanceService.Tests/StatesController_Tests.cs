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
    public class StatesController_Tests
    {

        [Fact]
        public async Task Get_Test()
        {
            //Arrange
            Mock<IStatesDAL> statesDAL = new Mock<IStatesDAL>();

            List<StatesReadDto> states = new List<StatesReadDto>
            {
                new StatesReadDto{code = "AL",name="Alabama" },
                new StatesReadDto{code = "AZ",name="Arizona" },
                new StatesReadDto{code = "CO",name="Colorado" },
                new StatesReadDto{code = "DC",name="District of Columbia" },
                new StatesReadDto{code = "IL",name="Illinois" },
            };


            statesDAL.Setup(x => x.GetStatesAsync()).ReturnsAsync(states);

            StatesController controller = new StatesController(statesDAL.Object);


            //Act
            var response = await controller.Get();

            ObjectResult result = (Microsoft.AspNetCore.Mvc.ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
            Assert.NotNull(result.Value);
        }
    }
}
