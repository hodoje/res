using DataAccess;
using Entities.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConsumptionUnitTests.PowerConsumptionUnitTests.DataAccess
{
    [TestFixture]
    class DatabaseContextTests
    {
        [Test]
        public void PowerConsumptionDataSet_Get_DbSetForPowerConsumptionData()
        {
            var databaseContext = new DatabaseContext();

            var dbSet = databaseContext.PowerConsumptionDataSet;

            Assert.IsNotNull(dbSet);
        }

        [Test]
        public void GeoArea_Get_DbSetForGeoArea()
        {
            var databaseContext = new DatabaseContext();

            var dbSet = databaseContext.GeoAreaSet;

            Assert.IsNotNull(dbSet);
        }
    }
}
