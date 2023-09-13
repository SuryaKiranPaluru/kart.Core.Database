
using FluentValidation;
using kart.Core.Dto.RequestModel;

namespace kart.Service.Api.Validators
{
    public class CartRequestModelValidator: AbstractValidator<CartRequestModel>
    {
        public CartRequestModelValidator()
        {

            RuleFor(x => x.ProductId).NotEmpty().GreaterThan(500).WithMessage("Product id must be greater than 500 and not Empty.");
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(1500).WithMessage("Seller id must be greater than 1500 and not Empty.");
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0).WithMessage("Quantity must be greater than 0 and not Empty.");


        }
    }
}
