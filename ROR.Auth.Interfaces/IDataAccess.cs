using System;
using System.Collections.Generic;
using System.Text;

namespace ROR.Auth.Interfaces
{
    public interface IDataAccess<T>
    {
        IEnumerable<T> search();
        T get(long Id);
        T post(T Product);
        void put(string Id, T Product);
        void delete(string Id);
    }
}
