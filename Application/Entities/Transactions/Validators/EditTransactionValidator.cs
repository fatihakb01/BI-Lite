using Application.Entities.Transactions.Features.Commands;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Entities.Transactions.Validators;

public class EditTransactionValidator : AbstractValidator<EditTransaction.Command>
{
    public EditTransactionValidator(IDateTimeProvider clock)
    {
        RuleFor(x => x.TransactionDto).SetValidator(new TransactionDtoValidator(clock));
    }
}
