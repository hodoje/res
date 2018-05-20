using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PowerConsumptionData
    {
        public DateTime Timestamp { get; set; }
        public double Consumption { get; set; }
        public string GeoAreaId { get; set; }
    }
}
