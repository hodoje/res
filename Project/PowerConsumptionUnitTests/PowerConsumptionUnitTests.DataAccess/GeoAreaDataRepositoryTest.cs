using DataAccess;
using DataAccess.ModelRepositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConsumptionUnitTests.PowerConsumptionUnitTests.DataAccess
{
    [TestFixture]
    class GeoAreaDataRepositoryTests
    {
        [Test]
        public void GeoAreaDataRepositoryConstructorTest()
        {
            var mock = new Mock<DatabaseContext>();

            GeoAreaRepository gar = new GeoAreaRepository(mock.Object);
        }

        [Test]
        public void DatabaseContext_Get_DatabaseContext()
        {
            var mock = new Mock<DatabaseContext>();

            GeoAreaRepository gar = new GeoAreaRepository(mock.Object);

            var dbContext = gar.DatabaseContext;

            Assert.IsNotNull(dbContext);
        }

    }
}
