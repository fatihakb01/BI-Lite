using System.Linq.Expressions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UniquenessChecker<TEntity>(DataContext context) 
    : IUniquenessChecker<TEntity> where TEntity : class
{
    // Returns true if no entity matches the predicate
    public async Task<bool> IsUniqueAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default
    )
    {
        return !await context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
    }
}
