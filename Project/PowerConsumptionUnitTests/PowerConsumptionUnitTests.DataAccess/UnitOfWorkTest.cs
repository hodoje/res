using DataAccess;
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
    class UnitOfWorkTests
    {
        [Test]
        public void UnitOfWork_Constructor_NotNull()
        {
            var mockDbContext = new Mock<DatabaseContext>();

            UnitOfWork unitOfWork = new UnitOfWork(mockDbContext.Object);

            Assert.IsNotNull(unitOfWork);
        }

        [Test]
        public void UnitOfWork_Constructor_IsNull()
        {

            UnitOfWork unitOfWork = new UnitOfWork();

            Assert
        }
    }
}
