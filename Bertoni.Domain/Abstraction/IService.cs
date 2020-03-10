using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Domain.Abstraction
{
    public interface IService<T> where T : class
    {
        T GetById(int id);
        IList<T> GetAll();
        IList<T> QueryBy(Func<T, bool> filter);
    }
}
