using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_Starlord.Controllers;
using Project_Starlord.Data;
using Project_Starlord.Helpers;
using Project_Starlord.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_Starlord.Controllers.Tests
{
    [TestClass()]
    public class FollowerControllerTests
    {
        [TestMethod()]
        public void PostFollowerTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword(),
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}.HashPassword()
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var followerData = new List<FollowerModel>
            {
            }.AsQueryable();

            var followerMockSet = new Mock<DbSet<FollowerModel>>();

            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(followerData.Provider);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(followerData.Expression);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(followerData.ElementType);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(followerData.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Followers).Returns(followerMockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new FollowerController(mockContext.Object);

            var result = service.PostFollower("aa", 2);

            Assert.AreEqual(result.Result.Value.FollowedId, 2);
        }

        [TestMethod()]
        public void PostFollowerWithIncorrectTokenTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword(),
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}.HashPassword()
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var followerData = new List<FollowerModel>
            {
            }.AsQueryable();

            var followerMockSet = new Mock<DbSet<FollowerModel>>();

            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(followerData.Provider);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(followerData.Expression);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(followerData.ElementType);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(followerData.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Followers).Returns(followerMockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new FollowerController(mockContext.Object);

            var result = service.PostFollower("BB", 2);

            Assert.IsNull(result.Result.Value);
        }

        [TestMethod()]
        public void PostFollowerRemoveWhenAlreadyFollowingTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword(),
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}.HashPassword()
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var followerData = new List<FollowerModel>
                {
                    new FollowerModel()
                    {
                        Id = 1,
                        FollowedId = 2,
                        FollowerId = 1
                    }
                }.AsQueryable();

            var followerMockSet = new Mock<DbSet<FollowerModel>>();

            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(followerData.Provider);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(followerData.Expression);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(followerData.ElementType);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(followerData.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Followers).Returns(followerMockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new FollowerController(mockContext.Object);

            var result = service.PostFollower("aa", 2);

            Assert.IsNull(result.Result);
        }

        [TestMethod()]
        public void GetFollowersTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword(),
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}.HashPassword()
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var followerData = new List<FollowerModel>
                {
                    new FollowerModel()
                    {
                        Id = 1,
                        FollowedId = 2,
                        FollowerId = 1
                    }
                }.AsQueryable();

            var followerMockSet = new Mock<DbSet<FollowerModel>>();

            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(followerData.Provider);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(followerData.Expression);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(followerData.ElementType);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(followerData.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Followers).Returns(followerMockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new FollowerController(mockContext.Object);

            var result = service.GetFollowers(1);

            Assert.IsNotNull(result.Result.Value);
        }

        [TestMethod()]
        public void GetFollowersRetunsNullWhenNoneFoundTest()
        {
            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword(),
                new UserModel()
                    {Id = 2, Token = "aaa", Username = "user2", Password = "pass2", Email = "2@gmail"}.HashPassword()
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var followerData = new List<FollowerModel>
                {
                    new FollowerModel()
                    {
                        Id = 1,
                        FollowedId = 2,
                        FollowerId = 1
                    }
                }.AsQueryable();

            var followerMockSet = new Mock<DbSet<FollowerModel>>();

            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Provider).Returns(followerData.Provider);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.Expression).Returns(followerData.Expression);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.ElementType).Returns(followerData.ElementType);
            followerMockSet.As<IQueryable<FollowerModel>>().Setup(m => m.GetEnumerator()).Returns(followerData.GetEnumerator());

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .Options;

            var mockContext = new Mock<MyDbContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            mockContext.Setup(x => x.Followers).Returns(followerMockSet.Object);

            mockContext.SetupProperty(x => x.Trips);
            mockContext.SetupProperty(x => x.PinPoints);

            var service = new FollowerController(mockContext.Object);

            var result = service.GetFollowers(2);

            Assert.IsNull(result.Result.Value);
        }
    }
}