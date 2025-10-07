namespace Application.Entities.TransactionLineItems.DTOs;

public class TransactionLineItemDto : BaseTransactionLineItemDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TransactionId { get; set; }
    public Guid ProductId { get; set; }
}
