using FluentValidation;
using kart.Core.Dto.RequestModel;

namespace kart.Service.Api.Validators
{
    public class ProductRequestModelValidator : AbstractValidator<ProductRequestModel>
    {
        public ProductRequestModelValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.CategoryId).GreaterThan(100).WithMessage("Category id must be greater than 100");
            RuleFor(x => x.ProductDesc).NotEmpty().WithMessage("Description cannot be empty.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.UserId).GreaterThan(1500).WithMessage("Seller id must be greater than 1500.");
            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be greater than or equal to 0.");
        }
    }
}
