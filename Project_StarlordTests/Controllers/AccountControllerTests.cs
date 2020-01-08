﻿using Microsoft.EntityFrameworkCore;
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
            var appSettingsClass = new AppSettings() { Secret = "" };

            var appSettings = new Mock<IOptions<AppSettings>>();

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

            var userService = new UserService(appSettings.Object, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.Login(new UserModel()
            { Id = 1, Token = "aa", Username = "user", Password = "pass", Email = "@gmail" });

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void LoginWrongPasswordTest()
        {
            var appSettings = new Mock<IOptions<AppSettings>>();

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

            var userService = new UserService(appSettings.Object, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.Login(new UserModel()
            { Id = 1, Token = "aa", Username = "user", Password = "pass2", Email = "@gmail" });
        }

        [TestMethod]
        public void LoginWrongUsernameTest()
        {
            var appSettings = new Mock<IOptions<AppSettings>>();

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

            var userService = new UserService(appSettings.Object, mockContext.Object);

            var service = new AccountController(mockContext.Object, userService);

            var result = service.Login(new UserModel()
            { Id = 1, Token = "aa", Username = "user2", Password = "pass", Email = "@gmail" });

            Assert.IsNull(result.Result);
        }
    }
}