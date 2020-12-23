using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Storage
{
    public interface IStorage<T> where T : class
    {
        string StorageType { get; }
        List<T> All { get; }
        T this[Guid id] { get; set; }
        void Add(T value);
        void RemoveAt(Guid id);
        bool Has(Guid id);
    }
}
