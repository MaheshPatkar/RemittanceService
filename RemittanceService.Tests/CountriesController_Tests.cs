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
    public class CountriesController_Tests
    {

        [Fact]
        public async Task Get_Test()
        {
            //Arrange
            Mock<ICountriesDAL> countriesDAL = new Mock<ICountriesDAL>();

            List<CountryReadDto> countrieslst = new List<CountryReadDto>
            {
                new CountryReadDto{code = "AD",name="Andorra" },
                new CountryReadDto{code = "AE",name="United Arab Emirates" },
                new CountryReadDto{code = "AF",name="Afghanistan" },
                new CountryReadDto{code = "AG",name="Antigua and Barbuda" },
                new CountryReadDto{code = "AI",name="Anguilla" },
            };


            countriesDAL.Setup(x => x.GetCountriesAsync()).ReturnsAsync(countrieslst);

            CountriesController controller = new CountriesController(countriesDAL.Object);


            //Act
            var response = await controller.Get();

            ObjectResult result = (Microsoft.AspNetCore.Mvc.ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
            Assert.NotNull(result.Value);
        }
    }
}
