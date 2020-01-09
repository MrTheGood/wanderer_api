using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_Starlord.Controllers;
using Project_Starlord.Data;
using Project_Starlord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Starlord.Controllers.Tests
{
    [TestClass()]
    public class PinPointControllerTests
    {
        [TestMethod()]
        public void GetPinPointsTest()
        {
            var dataTrips = new List<TripModel>
            {
                new TripModel()
                    {Id = 1, TripName = "trip1", TimestampTo = DateTime.Now, TimestampFrom = DateTime.Now, UserId = 1}
            }.AsQueryable();

            var mockSetTrips = new Mock<DbSet<TripModel>>();

            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Provider).Returns(dataTrips.Provider);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Expression).Returns(dataTrips.Expression);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.ElementType).Returns(dataTrips.ElementType);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.GetEnumerator()).Returns(dataTrips.GetEnumerator());

            var dataPinPoints = new List<PinPointModel>
            {
                new PinPointModel()
                    {Id =1, Latitude = 120000000000, Longitude = 120000000000, TripId = 1}
            }.AsQueryable();

            var mockPinpoints = new Mock<DbSet<PinPointModel>>();

            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.Provider).Returns(dataPinPoints.Provider);
            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.Expression).Returns(dataPinPoints.Expression);
            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.ElementType).Returns(dataPinPoints.ElementType);
            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.GetEnumerator()).Returns(dataPinPoints.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);
            mockContext.Setup(x => x.PinPoints).Returns(mockPinpoints.Object);

            var service = new PinPointController(mockContext.Object);

            var _ = service.GetPinPoints(1);

            Assert.IsNotNull(_.Result.Value);
        }

        [TestMethod()]
        public void SavePinPointsTest()
        {
            var dataTrips = new List<TripModel>
            {
                new TripModel()
                    {Id = 1, TripName = "trip1", TimestampTo = DateTime.Now, TimestampFrom = DateTime.Now, UserId = 1}
            }.AsQueryable();

            var mockSetTrips = new Mock<DbSet<TripModel>>();

            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Provider).Returns(dataTrips.Provider);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Expression).Returns(dataTrips.Expression);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.ElementType).Returns(dataTrips.ElementType);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.GetEnumerator()).Returns(dataTrips.GetEnumerator());

            var dataPinPoints = new List<PinPointModel>
            {
                new PinPointModel()
                    {Id =1, Latitude = 120000000000, Longitude = 120000000000, TripId = 1}
            }.AsQueryable();

            var mockPinpoints = new Mock<DbSet<PinPointModel>>();

            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.Provider).Returns(dataPinPoints.Provider);
            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.Expression).Returns(dataPinPoints.Expression);
            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.ElementType).Returns(dataPinPoints.ElementType);
            mockPinpoints.As<IQueryable<PinPointModel>>().Setup(m => m.GetEnumerator()).Returns(dataPinPoints.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);
            mockContext.Setup(x => x.PinPoints).Returns(mockPinpoints.Object);

            var service = new PinPointController(mockContext.Object);

            var newPinpoint = new PinPointModel()
            {
                TripId = 1,
                Latitude = 12,
                Longitude = 12
            };

            var _ = service.SavePinPoints(newPinpoint);

            Assert.AreEqual(newPinpoint.Longitude ,_.Result.Value.Longitude);
            Assert.AreEqual(newPinpoint.Latitude, _.Result.Value.Latitude);
            Assert.AreEqual(newPinpoint.TripId, _.Result.Value.TripId);
        }
    }
}