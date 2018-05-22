using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PowerConsuptionDbContext : DbContext
    {
        public DbSet<PowerConsumptionData> DbPowerConsuptionDataSet { get; set; }
        public DbSet<GeoArea> DbGeoAreaSet { get; set; }
    }
}
