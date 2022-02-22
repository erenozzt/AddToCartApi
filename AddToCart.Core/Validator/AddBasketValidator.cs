using AddToCart.Model.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddToCart.Core.Validator
{
    public class AddBasketValidator : AbstractValidator<Cart>
    {
        public AddBasketValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId must not be null.").NotEqual(0).WithMessage("ProductId must not 0.");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("You must add quantity.").NotEqual(0).WithMessage("The number of products to be added to the cart cannot be 0.");
        }
    }
}
