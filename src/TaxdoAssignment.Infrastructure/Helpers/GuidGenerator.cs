using MassTransit;
using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Infrastructure;

public sealed class GuidGenerator : IGuidGenerator
{
    public Guid Generate() => NewId.NextSequentialGuid();
}
