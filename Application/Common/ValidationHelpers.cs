using Domain.Interfaces;

namespace Application.Validators.Common;

public static class ValidationHelpers
{
    /// <summary>
    /// Ensures a property is unique if its value has changed.
    /// Works for any entity type TEntity.
    /// </summary>
    public static Func<TCommand, string?, CancellationToken, Task<bool>> UniqueIfChanged<TCommand, TEntity>(
        IRepository<TEntity> repository,
        IUniquenessChecker<TEntity> uniquenessChecker,
        Func<TEntity, string?> propertySelector,
        Func<TCommand, Guid> idSelector)
        where TEntity : class
    {
        return async (command, newValue, ct) =>
        {
            var existing = await repository.GetByIdAsync(idSelector(command), ct);
            if (existing == null) return true;

            var oldValue = propertySelector(existing);
            if (oldValue == newValue) return true;

            return await uniquenessChecker.IsUniqueAsync(
                entity => propertySelector(entity) == newValue, ct);
        };
    }
}
