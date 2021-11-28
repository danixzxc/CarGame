using System.Collections.Generic;

public interface IRepository<TKey, TValue> //обобщенный интерфейс 
{
    IReadOnlyDictionary<TKey, TValue> Collection { get; }
}
