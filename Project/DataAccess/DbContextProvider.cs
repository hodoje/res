using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbContextProvider : IDbContextProvider<PowerConsuptionDbContext>
    {
        public PowerConsuptionDbContext GetDbContext()
        {
            return new PowerConsuptionDbContext();
        }
    }
}
