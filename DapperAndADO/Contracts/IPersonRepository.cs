using DapperAndADO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndADO.Contracts
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Person GetBy(string name);
    }
}
