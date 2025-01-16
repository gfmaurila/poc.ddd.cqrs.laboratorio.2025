namespace Common.Core.Domain.Events.Decorators;

[AttributeUsage(AttributeTargets.Class)]
public class AggregateTypeAttribute(string aggregateType) : Attribute
{
    public string AggregateType { get; } = aggregateType;
}
