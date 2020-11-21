using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndADO.Contracts
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetBy(int id);
        T Update(T state);
        void DeleteBy(T state);
        void DeleteBy(int id);
        int Insert(T state);
    }
}
