using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IRepository<T,V>
    {
        IEnumerable<T> GetAll();
        T GetById(V id);
        bool Insert(T entity);
        bool Delete(V id);
        bool Update(T entity);
    }
}