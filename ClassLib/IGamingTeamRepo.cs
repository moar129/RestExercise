using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public interface IGamingTeamRepo<T>
    {
        T Add(T obj);
        T? GetById(int id);
        IEnumerable<T> Get();
        T? Update(int id,T obj);
        T? Delete(int id);
    }
}
