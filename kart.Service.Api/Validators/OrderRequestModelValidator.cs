using FluentValidation;
using kart.Core.Dto.RequestModel;

namespace kart.Service.Api.Validators
{
    public class OrderRequestModelValidator : AbstractValidator<OrderRequestModel>
    {
        public OrderRequestModelValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(1500).WithMessage("Seller id must be greater than 1500.");
            RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("PaymentMethod is required.");
            RuleFor(x => x.ShipmentAddress).NotEmpty().WithMessage("ShipmentAddress is required.");
        }
    }
}
