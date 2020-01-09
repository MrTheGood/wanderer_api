using Project_Starlord.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_Starlord.Models;
using Moq;
using Project_Starlord.Data;

namespace Project_Starlord.Controllers.Tests
{
    [TestClass]
    public class TripControllerTests
    {
        [TestMethod]
        public void PostTripWithPinpointsTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new TripController(mockContext.Object);

            var titudesArray = new Titudes[1];

            var a = new Titudes()
            {
                Lat = 20,
                Long = 20
            };

            titudesArray[0] = a;

            var model = new ReceivedInfo()
            {
                Token = "aa",
                Name = "test",
                From = DateTime.Now,
                To = DateTime.Now,
                Pinpoints = titudesArray
            };

            var _ = service.PostTripWithPinpoints(model);
            mockContext.Verify(x => x.Add(It.IsAny<TripModel>()), Times.Once);
        }

        [TestMethod]
        public void PostTripWithPinpointsWithOutPinpointsTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new TripController(mockContext.Object);

            var titudesArray = new Titudes[0];

            var model = new ReceivedInfo()
            {
                Token = "aa",
                Name = "test",
                From = DateTime.Now,
                To = DateTime.Now,
                Pinpoints = titudesArray
            };

            var _ = service.PostTripWithPinpoints(model);
            mockContext.Verify(x => x.Add(It.IsAny<PinPointModel>()), Times.Never);
        }

        [TestMethod]
        public void PostTripWithPinpointsWithWrongTokenTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new TripController(mockContext.Object);

            var titudesArray = new Titudes[1];

            var a = new Titudes()
            {
                Lat = 20,
                Long = 20
            };

            titudesArray[0] = a;

            var model = new ReceivedInfo()
            {
                Token = "WRONG",
                Name = "test",
                From = DateTime.Now,
                To = DateTime.Now,
                Pinpoints = titudesArray
            };

            var _ = service.PostTripWithPinpoints(model);

            Assert.IsTrue(_.IsCompleted);
        }

        [TestMethod()]
        public void GetTripsTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

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

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);

            var service = new TripController(mockContext.Object);

            var _ = service.GetTrips(1);

            Assert.IsNotNull(_.Result.Value);
        }

        [TestMethod()]
        public void GetTripsWithWrongUserTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

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

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);

            var service = new TripController(mockContext.Object);

            var _ = service.GetTrips(2);

            Assert.IsNull(_.Result.Value);
        }

        [TestMethod()]
        public void GetFollowerTripsTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"},
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dataTrips = new List<TripModel>
            {
                new TripModel()
                    {Id = 2, TripName = "trip1", TimestampTo = DateTime.Now, TimestampFrom = DateTime.Now, UserId = 2}
            }.AsQueryable();

            var mockSetTrips = new Mock<DbSet<TripModel>>();

            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Provider).Returns(dataTrips.Provider);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Expression).Returns(dataTrips.Expression);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.ElementType).Returns(dataTrips.ElementType);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.GetEnumerator()).Returns(dataTrips.GetEnumerator());

            var dataFollowers = new List<FollowerModel>
            {
                new FollowerModel()
                    {FollowedId = 2, FollowerId = 1, Id = 1 }
            }.AsQueryable();

            var mockSetFollowers = new Mock<DbSet<FollowerModel>>();

            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(dataFollowers.Provider);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(dataFollowers.Expression);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(dataFollowers.ElementType);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(dataFollowers.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);
            mockContext.Setup(x => x.Followers).Returns(mockSetFollowers.Object);

            var service = new TripController(mockContext.Object);

            var _ = service.GetFollowerTrips("aa");

            Assert.IsNotNull(_.Result.Value);
        }

        [TestMethod()]
        public void GetFollowerTripsWithOutCorrectTokenTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"},
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dataTrips = new List<TripModel>
            {
                new TripModel()
                    {Id = 2, TripName = "trip1", TimestampTo = DateTime.Now, TimestampFrom = DateTime.Now, UserId = 2}
            }.AsQueryable();

            var mockSetTrips = new Mock<DbSet<TripModel>>();

            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Provider).Returns(dataTrips.Provider);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Expression).Returns(dataTrips.Expression);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.ElementType).Returns(dataTrips.ElementType);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.GetEnumerator()).Returns(dataTrips.GetEnumerator());

            var dataFollowers = new List<FollowerModel>
            {
                new FollowerModel()
                    {FollowedId = 2, FollowerId = 1, Id = 1 }
            }.AsQueryable();

            var mockSetFollowers = new Mock<DbSet<FollowerModel>>();

            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(dataFollowers.Provider);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(dataFollowers.Expression);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(dataFollowers.ElementType);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(dataFollowers.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);
            mockContext.Setup(x => x.Followers).Returns(mockSetFollowers.Object);

            var service = new TripController(mockContext.Object);

            var _ = service.GetFollowerTrips("BB");

            Assert.IsNull(_.Result.Value);
        }

        [TestMethod()]
        public void GetFollowerTripsForUserWithOutFollowersTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"},
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dataTrips = new List<TripModel>
            {
                new TripModel()
                    {Id = 2, TripName = "trip1", TimestampTo = DateTime.Now, TimestampFrom = DateTime.Now, UserId = 2}
            }.AsQueryable();

            var mockSetTrips = new Mock<DbSet<TripModel>>();

            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Provider).Returns(dataTrips.Provider);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Expression).Returns(dataTrips.Expression);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.ElementType).Returns(dataTrips.ElementType);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.GetEnumerator()).Returns(dataTrips.GetEnumerator());

            var dataFollowers = new List<FollowerModel>
            {
                new FollowerModel()
                    {FollowedId = 2, FollowerId = 1, Id = 1 }
            }.AsQueryable();

            var mockSetFollowers = new Mock<DbSet<FollowerModel>>();

            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(dataFollowers.Provider);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(dataFollowers.Expression);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(dataFollowers.ElementType);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(dataFollowers.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);
            mockContext.Setup(x => x.Followers).Returns(mockSetFollowers.Object);

            var service = new TripController(mockContext.Object);

            var _ = service.GetFollowerTrips("aaa");

            Assert.IsNull(_.Result.Value);
        }

        [TestMethod()]
        public void GetFollowerTripsForUserWithOutTripsTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"},
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dataTrips = new List<TripModel>
            {
                new TripModel()
                    {Id = 2, TripName = "trip1", TimestampTo = DateTime.Now, TimestampFrom = DateTime.Now, UserId = 1}
            }.AsQueryable();

            var mockSetTrips = new Mock<DbSet<TripModel>>();

            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Provider).Returns(dataTrips.Provider);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.Expression).Returns(dataTrips.Expression);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.ElementType).Returns(dataTrips.ElementType);
            mockSetTrips.As<IQueryable<TripModel>>().Setup(m => m.GetEnumerator()).Returns(dataTrips.GetEnumerator());

            var dataFollowers = new List<FollowerModel>
            {
                new FollowerModel()
                    {FollowedId = 2, FollowerId = 1, Id = 1 }
            }.AsQueryable();

            var mockSetFollowers = new Mock<DbSet<FollowerModel>>();

            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(dataFollowers.Provider);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(dataFollowers.Expression);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(dataFollowers.ElementType);
            mockSetFollowers.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(dataFollowers.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Trips).Returns(mockSetTrips.Object);
            mockContext.Setup(x => x.Followers).Returns(mockSetFollowers.Object);

            var service = new TripController(mockContext.Object);

            var _ = service.GetFollowerTrips("aa");

            Assert.IsNull(_.Result.Value);
        }
    }
}