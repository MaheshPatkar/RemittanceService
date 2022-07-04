using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Remittance_Provider;
using Remittance_Provider.Controllers;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RemittanceService.Tests
{
    public class TransactionsController_Tests
    {
        private Mock<ITransactionDAL> _transactionDAL { get; set; }
        private Mock<ICountriesDAL> _countriesDAL { get; set; }
        private TransactionParams transactionParams { get; set; }
        private TransactionResponse transactionResponse { get; set; }
        private TransactionsController controller { get; set; }
        public TransactionsController_Tests()
        {
            _transactionDAL = new Mock<ITransactionDAL>();
            _countriesDAL = new Mock<ICountriesDAL>();
            transactionParams = new TransactionParams();
            controller = new TransactionsController(_transactionDAL.Object, _countriesDAL.Object);
        }



        [Fact]
        public async Task Post_Test_ResponseCode200()
        {
            //Arrange
            transactionResponse = new TransactionResponse { responseStatus = 200, transactionId = Guid.NewGuid() };
            _transactionDAL.Setup(x => x.SubmitTransactionAsync(transactionParams)).ReturnsAsync(transactionResponse);

            _countriesDAL.Setup(x => x.isValidCountryAsync(It.IsAny<string>())).ReturnsAsync(true);
            //Action

            var response = await controller.Post(transactionParams);
            ObjectResult result = (ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);

        }

        [Fact]
        public async Task Post_Test_ResponseCode201()
        {
            //Arrange
            transactionResponse = new TransactionResponse { responseStatus = 201, transactionId = Guid.NewGuid() };
            _transactionDAL.Setup(x => x.SubmitTransactionAsync(transactionParams)).ReturnsAsync(transactionResponse);
            _countriesDAL.Setup(x => x.isValidCountryAsync(It.IsAny<string>())).ReturnsAsync(true);
            //Action
            TransactionsController controller = new TransactionsController(_transactionDAL.Object, _countriesDAL.Object);
            var response = await controller.Post(transactionParams);
            ObjectResult result = (ObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, StatusCodes.Status201Created);
        }


        [Fact]
        public async Task Get_Test_CompletedTransaction()
        {
            TransactionReadResponse testresponse = new TransactionReadResponse
            {
                transactionId = Guid.NewGuid(),
                responseStatus = Constants.COMPLETED
            };

            //Arrange
            _transactionDAL.Setup(x => x.GetTransactionAsync(It.IsAny<string>())).ReturnsAsync(testresponse);

            //Action
            TransactionsController controller = new TransactionsController(_transactionDAL.Object, _countriesDAL.Object);
            var response = await controller.Get(It.IsAny<string>());
            ObjectResult result = (ObjectResult)response;
            TransactionReadResponse readResponse
                = (TransactionReadResponse)result.Value;

            //Assert
            Assert.Equal(readResponse.responseStatus, Constants.COMPLETED);
        }


    }
}
