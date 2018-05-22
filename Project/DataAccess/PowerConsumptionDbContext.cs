using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PowerConsumptionDbContext : DbContext
    {
        public DbSet<PowerConsumptionData> DbPowerConsumptionDataSet { get; set; }
        public DbSet<GeoArea> DbGeoAreaSet { get; set; }
    }
}
