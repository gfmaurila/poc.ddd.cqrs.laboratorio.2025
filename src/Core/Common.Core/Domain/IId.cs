namespace Common.Core.Domain;

public interface IId : IComparable, IComparable<IId>, IComparable<Guid>, IEquatable<IId>
{
    Guid Value { get; }
}
