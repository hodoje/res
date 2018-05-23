using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Models;

namespace DataAccess
{
    interface IRepositoryWithDate<T, V>: IRepository<T, V>
    {
        IEnumerable<T> GetUnderSpecificDate(InputDate inputDate);
    }
}