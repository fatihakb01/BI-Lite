using System;
using System.Reflection.Metadata;

namespace Domain.Interfaces;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
