using DataAccess;
using DataAccess.ModelRepositories;
using Entities;
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
        public void UnitOfWork_AddAndSavePowerConsumptionDataEntity_ViaContext()
        {
            var data = new List<PowerConsumptionData>
            {
                new PowerConsumptionData()
                {
                    Id = 1,
                    Timestamp = new DateTime(2018, 6, 7),
                    GeoAreaId = "SRB",
                    Consumption = 0
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<PowerConsumptionData>>();

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(x => x.PowerConsumptionDataSet).Returns(mockSet.Object);

            var unitOfWork = new UnitOfWork(mockContext.Object);

            var result = unitOfWork.PowerConsumptionDataRepository.Add(data.First());

        }
    }
}
