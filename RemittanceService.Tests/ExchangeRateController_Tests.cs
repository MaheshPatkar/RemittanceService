using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Remittance_Provider.Controllers;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RemittanceService.Tests
{
    public class ExchangeRateController_Tests
    {
        [Fact]
        public async Task Get_Test()
        {
            //Arrange
            Mock<IExchangeRateDAL> exchangeRateDal = new Mock<IExchangeRateDAL>();

            ExchangeRateParams exchangeRate = new ExchangeRateParams();

            ExchangeRateReadDto exchangeRateReadDto = new ExchangeRateReadDto
            {
                destinationCountry = "US",
                sourceCountry = "US",
                exchangeRate = "1",
                exchangeRateToken = DateTime.UtcNow.ToString()
            };

            exchangeRateDal.Setup(x => x.GetExchangeRateAsync(exchangeRate)).ReturnsAsync(exchangeRateReadDto);

            ExchangeRateController controller = new ExchangeRateController(exchangeRateDal.Object);

            //Act
            var response = await controller.Get(exchangeRate);

            ObjectResult result = (ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
            Assert.NotNull(result.Value);
        }

    }
}
