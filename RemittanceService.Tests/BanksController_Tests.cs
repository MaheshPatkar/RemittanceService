using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Remittance_Provider.Controllers;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RemittanceService.Tests
{
   public class BanksController_Tests
    {
        [Fact]
        public async Task Get_Test()
        {
            //Arrange
            Mock<IBankDAL> bankDAL = new Mock<IBankDAL>();

            List<BankReadDto> banks = new List<BankReadDto>
            {
                new BankReadDto{code = "CAN",name ="Canara Bank" },
                new BankReadDto{code = "SBI",name ="State Bank of India" },
                new BankReadDto{code = "RBI",name ="Reserve Bank of India" }
            };

            bankDAL.Setup(x => x.GetBanksByCountryCodeAsync(It.IsAny<string>())).ReturnsAsync(banks);

            BanksController controller = new BanksController(bankDAL.Object);

            //Act
            var response = await controller.Get(It.IsAny<string>());
            ObjectResult result = (ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);

        }


    }
}
