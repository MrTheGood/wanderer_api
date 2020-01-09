using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_Starlord.Controllers;
using Project_Starlord.Data;
using Project_Starlord.Helpers;
using Project_Starlord.Models;
using Project_Starlord.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Starlord.Controllers.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void LoginTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.Login(new UserModel()
            { Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail" });

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void LoginWrongPasswordTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.Login(new UserModel()
            { Id = 1, Token = "aa", Username = "user", Password = "pass2", Email = "@gmail" });

            Assert.AreEqual(result.Status, System.Threading.Tasks.TaskStatus.Faulted);
        }

        [TestMethod]
        public void LoginWrongUsernameTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.Login(new UserModel()
            { Id = 1, Token = "aa", Username = "user2", Password = "pass", Email = "@gmail" });

            Assert.IsNull(result.Result);
        }

        [TestMethod()]
        public void GetUserModelTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();

            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var followerData = new List<FollowerModel>
            { }.AsQueryable();

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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.GetUserModel(1, "aa");

            Assert.AreEqual(result.Result.Value, "{\"IsFollowing\":false,\"Id\":1,\"Username\":\"user\",\"Email\":\"@gmail\",\"Password\":\"\",\"Token\":\"\"}");
        }

        [TestMethod()]
        public void GetUserModelWithFollowerTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

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
                new FollowerModel(){FollowedId = 2, FollowerId = 1, Id = 1}
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.GetUserModel(2, "aa");

            Assert.AreEqual(result.Result.Value, "{\"IsFollowing\":true,\"Id\":2,\"Username\":\"user2\",\"Email\":\"2@gmail\",\"Password\":\"\",\"Token\":\"\"}");
        }

        [TestMethod()]
        public void GetUserModelWithWrongIdTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

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
                new FollowerModel(){FollowedId = 2, FollowerId = 1, Id = 1}
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.GetUserModel(3, "aa");

            Assert.AreEqual(result.Result.Value, null);
        }

        [TestMethod()]
        public void GetUserModelWithWrongTokenTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

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
                new FollowerModel(){FollowedId = 2, FollowerId = 1, Id = 1}
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.GetUserModel(2, "BB");

            Assert.AreEqual(result.Result.Value, null);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var newUser = new UserModel()
            {
                Password = "blaat",
                Email = "corki@gmail.com",
                Username = "Codeaur"
            };

            var result = service.Register(newUser);

            Assert.AreEqual(result.Result.Value.Username, newUser.Username);
            Assert.AreEqual(result.Result.Value.Email, newUser.Email);
        }

        [TestMethod()]
        public void RegisterWithOutPasswordTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var newUser = new UserModel()
            {
                Email = "corki@gmail.com",
                Username = "Codeaur"
            };

            var result = service.Register(newUser);

            Assert.AreEqual(result.Result, null);
        }

        [TestMethod()]
        public void RegisterWithOutEmailTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var newUser = new UserModel()
            {
                Username = "Codeaur",
                Password = "blaat"
            };

            var result = service.Register(newUser);

            Assert.AreEqual(result.Result, null);
        }

        [TestMethod()]
        public void RegisterWithOutUsernameTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var newUser = new UserModel()
            {
                Password = "blaat",
                Email = "corki@gmail.com"
            };

            var result = service.Register(newUser);

            Assert.AreEqual(result.Result, null);
        }

        [TestMethod()]
        public void SearchUserTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.SearchUser("us");

            Assert.AreEqual(result.Result.Value, "[{\"Id\":1,\"Username\":\"user\",\"Email\":\"@gmail\",\"Password\":null,\"Token\":\"aa\"}]");
        }

        [TestMethod()]
        public void SearchUserWithOutValueTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.SearchUser("");

            Assert.AreEqual(result.Result.Value, "[{\"Id\":1,\"Username\":\"user\",\"Email\":\"@gmail\",\"Password\":null,\"Token\":\"aa\"}]");
        }

        [TestMethod()]
        public void SearchUserWithOutUserFoundTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.SearchUser("blaat");

            Assert.AreEqual(result.Result.Value, null);
        }

        [TestMethod()]
        public void SearchUserNoInputTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

            var data = new List<UserModel>
            {
                new UserModel()
                    {Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail"}.HashPassword()
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.SearchUserNoInput();

            Assert.AreEqual(result.Result.Value, "[{\"Id\":1,\"Username\":\"user\",\"Email\":\"@gmail\",\"Password\":null,\"Token\":\"aa\"}]");
        }

        [TestMethod()]
        public void SearchFollowersTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

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
                new FollowerModel(){FollowedId = 2, FollowerId = 1, Id = 1}
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.SearchFollowers("aa");

            Assert.AreEqual(result.Result.Value, "[{\"Id\":2,\"Username\":\"user2\",\"Email\":\"2@gmail\",\"Password\":null,\"Token\":\"aaa\"}]");
        }

        [TestMethod()]
        public void SearchFollowersNoUserFoundTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

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
                new FollowerModel(){FollowedId = 2, FollowerId = 1, Id = 1}
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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.SearchFollowers("BB");

            Assert.AreEqual(result.Result.Value, null);
        }

        [TestMethod()]
        public void SearchFollowersNoFollowersFoundTest()
        {
            var appSettingsClass = new AppSettings() { Secret = "1xNQ0brDZ6TwznGi9p58WRI2gfLJXcvq" };

            IOptions<AppSettings> appSettings = Options.Create(appSettingsClass);

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

            var userService = new UserService(appSettings, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.SearchFollowers("aa");

            Assert.AreEqual(result.Result.Value, null);
        }
    }
}