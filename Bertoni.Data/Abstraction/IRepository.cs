using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Data.Abstraction
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IList<T> GetAll();
    }
}
