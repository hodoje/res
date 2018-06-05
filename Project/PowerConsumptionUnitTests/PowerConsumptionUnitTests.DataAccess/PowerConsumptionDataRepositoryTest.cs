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
    class PowerConsumptionDataRepositoryTests
    {
        [Test]
        public void PowerConsumptionDataRepositoryConstructorTest()
        {
            var mock = new Mock<DatabaseContext>();

            PowerConsumptionDataRepository pcdr = new PowerConsumptionDataRepository(mock.Object);
        }

        [Test]
        public void DatabaseContext_Get_DatabaseContext()
        {
            var mock = new Mock<DatabaseContext>();

            PowerConsumptionDataRepository pcdr = new PowerConsumptionDataRepository(mock.Object);

            var dbContext = pcdr.DatabaseContext;

            Assert.IsNotNull(dbContext);
        }
    }
}
