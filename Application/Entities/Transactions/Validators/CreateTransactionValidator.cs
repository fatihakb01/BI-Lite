using Application.Entities.Transactions.Features.Commands;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Entities.Transactions.Validators;

public class CreateTransactionValidator : AbstractValidator<CreateTransaction.Command>
{
    public CreateTransactionValidator(IDateTimeProvider clock)
    {
        RuleFor(x => x.TransactionDto).SetValidator(new TransactionDtoValidator(clock));
    }
}
