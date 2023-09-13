using FluentValidation;
using kart.Core.Dto.RequestModel;
using kart.Service.Api.Controllers;
using kart.Service.Buisness;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.UnitTest.ControllerTest
{
    public class CartControllerTest
    {
        public CartController cartController;
        public Mock<ICartService> mockCartService;
        public Mock<IValidator<CartRequestModel>> mockValidatorService;

        public CartControllerTest()
        {
            mockCartService = new Mock<ICartService>();
            cartController = new CartController(mockCartService.Object, mockValidatorService.Object);

        }


    }
}
