using Application.Entities.TransactionLineItems.Features.Commands;
using FluentValidation;

namespace Application.Entities.TransactionLineItems.Validators;

public class EditTransactionLineItemValidator : AbstractValidator<EditTransactionLineItem.Command>
{
    public EditTransactionLineItemValidator()
    {
        RuleFor(x => x.TransactionLineItemDto).SetValidator(new TransactionLineItemDtoValidator());
    }
}
