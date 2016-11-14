using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoTrailsWebServices.DataAccessService;
using PhotoTrailsWebServices.DataTransferObject;
using PhotoTrailsWebServicesTest.DataAccessService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoTrailsWebServices.DataAccessService.Tests
{
    [TestClass()]
    public class TrailDataAccessTests
    {
        private IQueryable<trail> TrailData { get; set; }

        private Mock<phototrailsEntities> MockContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TrailData = new List<trail>
            {
                new trail { id=1, name="BBB", description="BBB description" },
                new trail { id=2, name="ZZZ", description="ZZZ description" },
                new trail { id=3, name="AAA", description="AAA description" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<trail>>();
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => TrailData.FirstOrDefault(t => t.id == (long)ids[0]));
            mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).Returns<object[]>(ids => Task.FromResult(TrailData.FirstOrDefault(t => t.id == (long)ids[0])));
            mockSet.As<IDbAsyncEnumerable<trail>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<trail>(TrailData.GetEnumerator()));
            mockSet.As<IQueryable<trail>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<trail>(TrailData.Provider));
            mockSet.As<IQueryable<trail>>().Setup(m => m.Expression).Returns(TrailData.Expression);
            mockSet.As<IQueryable<trail>>().Setup(m => m.ElementType).Returns(TrailData.ElementType);
            mockSet.As<IQueryable<trail>>().Setup(m => m.GetEnumerator()).Returns(TrailData.GetEnumerator());

            MockContext = new Mock<phototrailsEntities>();
            MockContext.Setup(c => c.trail).Returns(mockSet.Object);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<trail, TrailDTO>();
                cfg.CreateMap<trackpoint, TrackPointDTO>();
            });
        }

        [TestMethod()]
        public void MapperConfigurationValid()
        {
            Mapper.Configuration.AssertConfigurationIsValid();
        }

        [TestMethod()]
        public void TrailByIdNotFound()
        {
            ITrailDataAccess trailDataAccess = new TrailDataAccess(MockContext.Object);
            var trail = trailDataAccess.GetTrailById(10000);

            Assert.IsNull(trail);
        }

        [TestMethod()]
        public async Task TrailByIdAsyncNotFound()
        {
            ITrailDataAccess trailDataAccess = new TrailDataAccess(MockContext.Object);
            var trail = await trailDataAccess.GetTrailByIdAsync(10000);

            Assert.IsNull(trail);
        }

        [TestMethod()]
        public void GetTrailById()
        {
            ITrailDataAccess trailDataAccess = new TrailDataAccess(MockContext.Object);
            var trail = trailDataAccess.GetTrailById(2);

            Assert.IsNotNull(trail);
            Assert.AreEqual(2, trail.id);
            Assert.AreEqual("ZZZ", trail.name);
            Assert.AreEqual("ZZZ description", trail.description);
            Assert.IsNull(trail.duration);
        }

        [TestMethod()]
        public async Task GetTrailByIdAsync()
        {
            ITrailDataAccess trailDataAccess = new TrailDataAccess(MockContext.Object);
            var trail = await trailDataAccess.GetTrailByIdAsync(2);

            Assert.IsNotNull(trail);
            Assert.AreEqual(2, trail.id);
            Assert.AreEqual("ZZZ", trail.name);
            Assert.AreEqual("ZZZ description", trail.description);
        }

        [TestMethod()]
        public void GetAllTrails_OrderByName()
        {
            ITrailDataAccess trailDataAccess = new TrailDataAccess(MockContext.Object);
            var trails = trailDataAccess.GetAllTrails();

            Assert.AreEqual(3, trails.Count);
            Assert.AreEqual("AAA", trails[0].name);
            Assert.AreEqual(3, trails[0].id);
            Assert.AreEqual("BBB", trails[1].name);
            Assert.AreEqual(1, trails[1].id);
            Assert.AreEqual("ZZZ", trails[2].name);
            Assert.AreEqual(2, trails[2].id);
        }

        [TestMethod()]
        public async Task GetAllTrailsAsync_OrderByName()
        {
            ITrailDataAccess trailDataAccess = new TrailDataAccess(MockContext.Object);
            var trails = await trailDataAccess.GetAllTrailsAsync();

            Assert.AreEqual(3, trails.Count);
            Assert.AreEqual("AAA", trails[0].name);
            Assert.AreEqual(3, trails[0].id);
            Assert.AreEqual("BBB", trails[1].name);
            Assert.AreEqual(1, trails[1].id);
            Assert.AreEqual("ZZZ", trails[2].name);
            Assert.AreEqual(2, trails[2].id);
        }
    }
}