using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PhotoTrailsWebServices.DataAccessService.Tests
{
    [TestClass()]
    public class TrailDataAccessTests
    {
        [TestMethod()]
        public void GetAllTrails_OrderByName()
        {
            var data = new List<trail>
            {
                new trail { id=1, name="AAA" },
                new trail { id=1, name="ZZZ" },
                new trail { id=1, name="BBB" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<trail>>();
            mockSet.As<IQueryable<trail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<trail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<trail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<trail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<phototrailsEntities>();
            mockContext.Setup(c => c.trail).Returns(mockSet.Object);

            TrailDataAccess trailDataAccess = new TrailDataAccess(mockContext.Object);
            var trails = trailDataAccess.GetAllTrails();

            Assert.AreEqual(3, trails.Count);
            Assert.AreEqual("AAA", trails[0].name);
            Assert.AreEqual("BBB", trails[1].name);
            Assert.AreEqual("ZZZ", trails[2].name);
        }
    }
}