using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy
{
    public interface IPowerConsumptionCachedData
    {
        ICacheManager<PowerConsumptionData> CacheManager { get; }
        string Key { get; set; }
        InputDate InputDate { set; }

        IEnumerable<PowerConsumptionData> Get();
    }
}
