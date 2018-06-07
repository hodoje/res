using DataAccess;
using DataProxy;
using Entities.Models;
using Moq;
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

        [Test]
        public void PowerConsumptionCachedData_NoDateEntered_GetAll()
        {
            var data = new List<PowerConsumptionData>()
            {
                new PowerConsumptionData()
                {
                    Id = 0,
                    Timestamp = DateTime.Now,
                    Consumption = 0,
                    GeoArea = null,
                    GeoAreaId = "SRB"
                },
                new PowerConsumptionData()
                {
                    Id = 1,
                    Timestamp = DateTime.Now,
                    Consumption = 0,
                    GeoArea = null,
                    GeoAreaId = "SRB"
                },
                new PowerConsumptionData()
                {
                    Id = 2,
                    Timestamp = DateTime.Now,
                    Consumption = 0,
                    GeoArea = null,
                    GeoAreaId = "SRB"
                },
                new PowerConsumptionData()
                {
                    Id = 3,
                    Timestamp = DateTime.Now,
                    Consumption = 0,
                    GeoArea = null,
                    GeoAreaId = "SRB"
                }
            }.AsEnumerable();

            var inputDate = new InputDate()
            {
                From = new DateTime(1, 1, 1, 0, 0, 0, 0),
                To = new DateTime(),
            };

            var mockUOF = new Mock<UnitOfWork>();
            mockUOF.Setup(x => x.PowerConsumptionDataRepository.GetAll()).Returns(data.ToList());

            var pccd = new PowerConsumptionCachedData(new CacheManager<PowerConsumptionData>(),
                                                        mockUOF.Object);

            var result = pccd.Get(inputDate);

            Assert.AreEqual(result.Count(), 4);
        }
    }
}
