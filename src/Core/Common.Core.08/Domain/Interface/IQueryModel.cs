namespace Common.Core._08.Domain.Interface;

/// <summary>
/// Interface marcadora para representar um modelo de query (ReadOnly).
/// </summary>
public interface IQueryModel
{
}

/// <summary>
/// Interface marcadora para representar um modelo de query (ReadOnly).
/// </summary>
/// <typeparam name="TKey">O tipo da chave.</typeparam>
public interface IQueryModel<out TKey> : IQueryModel where TKey : IEquatable<TKey>
{
    TKey Id { get; }
}
