using DataAccess;
using DataProxy;
using Entities.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConsumptionUnitTests.PowerConsumptionUnitTests.DataProxy
{
    [TestFixture]
    class PowerConsumptionCachedDataTest
    {
        [Test]
        public void PowerConsumptionCachedData_ContsructorTest()
        {
            var pccd = new PowerConsumptionCachedData(new CacheManager<PowerConsumptionData>(),
                                                        new UnitOfWork(new DatabaseContext()));

            Assert.IsNotNull(pccd);
        }


    }
}
