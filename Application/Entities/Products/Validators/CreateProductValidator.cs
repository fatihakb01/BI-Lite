using Application.Entities.Products.Features.Commands;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Entities.Products.Validators;

public class CreateProductValidator : AbstractValidator<CreateProduct.Command>
{
    public CreateProductValidator(IUniquenessChecker<Product> uniquenessChecker)
    {
        // General rules
        RuleFor(x => x.ProductDto).SetValidator(new ProductDtoValidator());

        // Check for unique Name and SKU
        RuleFor(x => x.ProductDto.Name)
            .MustAsync(async (name, ct) =>
                await uniquenessChecker.IsUniqueAsync(c => c.Name == name, ct))
            .When(x => !string.IsNullOrWhiteSpace(x.ProductDto.Name))
            .WithMessage("Product name must be unique");

        RuleFor(x => x.ProductDto.SKU)
            .MustAsync(async (sku, ct) =>
                await uniquenessChecker.IsUniqueAsync(c => c.SKU == sku, ct))
            .When(x => !string.IsNullOrWhiteSpace(x.ProductDto.SKU))
            .WithMessage("Product's SKU must be unique");
    }
}
