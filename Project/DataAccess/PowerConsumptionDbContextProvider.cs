using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PowerConsumptionDbContextProvider : IDbContextProvider<PowerConsumptionDbContext>
    {
        public PowerConsumptionDbContext GetDbContext()
        {
            return new PowerConsumptionDbContext();
        }
    }
}
