using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project_Starlord.Helpers;
using Project_Starlord.Models;

namespace Project_Starlord.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ResetTokenModel> ResetTokens { get; set; }
        public DbSet<TripModel> Trips { get; set; }
        public DbSet<PinPointModel> PinPoints { get; set; }
        public DbSet<FollowerModel> Followers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<UserModel> users = new List<UserModel>();

            UserModel user1 = new UserModel
            {
                Email = "007@hr.nl",
                Password = "geheim",
                Username = "SecretAgent",
                Id = 2
            };

            users.Add(user1.HashPassword());

            UserModel user2 = new UserModel
            {
                Email = "admin@admin.nl",
                Password = "geheim",
                Username = "Admin",
                Id = 1
            };

            users.Add(user2.HashPassword());

            modelBuilder.Entity<UserModel>().HasData(users);

            List<TripModel> trips = new List<TripModel>();

            trips.Add(new TripModel
            {
                TimestampFrom = DateTime.MinValue,
                TimestampTo = DateTime.Now,
                TripName = "trip1",
                UserId = 1,
                Id = 1
            });

            trips.Add(new TripModel
            {
                TimestampFrom = DateTime.MinValue,
                TimestampTo = DateTime.Now,
                TripName = "trip2",
                UserId = 2,
                Id = 2
            });

            trips.Add(new TripModel
            {
                TimestampFrom = DateTime.Now,
                TimestampTo = DateTime.Now,
                TripName = "Tyas zijn vakantie",
                UserId = 2,
                Id = 3
            });

            modelBuilder.Entity<TripModel>().HasData(trips);

            List<PinPointModel> pinpoints = new List<PinPointModel>();

            pinpoints.Add(new PinPointModel
            {
                Latitude = 50000000000000,
                Longitude = 20000000000000,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 1,
                Sequence = 1
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 40000000000000,
                Longitude = 60000000000000,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 2,
                Sequence = 3
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 300000000000000,
                Longitude = 12000000000000,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 3,
                Sequence = 2
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 280000000000000,
                Longitude = 47000000000000,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 4,
                Sequence = 4
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 792000000000000,
                Longitude = 147000000000000,
                Timestamp = DateTime.Now,
                TripId = 2,
                Id = 5,
                Sequence = 2
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 123000000000000,
                Longitude = 862000000000000,
                Timestamp = DateTime.Now,
                TripId = 2,
                Id = 6,
                Sequence = 1
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 1200000000000000,
                Longitude = 1300000000000000,
                Timestamp = DateTime.Now,
                TripId = 2,
                Id = 7,
                Sequence = 3
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 51000000000000,
                Longitude = 4000000000000,
                Timestamp = DateTime.Now,
                TripId = 3,
                Id = 8,
                Sequence = 1
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 55000000000000,
                Longitude = 18000000000000,
                Timestamp = DateTime.Now,
                TripId = 3,
                Id = 9,
                Sequence = 3
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 56000000000000,
                Longitude = 12000000000000,
                Timestamp = DateTime.Now,
                TripId = 3,
                Id = 10,
                Sequence = 4
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 51000000000000,
                Longitude = 4000000000000,
                Timestamp = DateTime.Now,
                TripId = 3,
                Id = 11,
                Sequence = 2
            });

            modelBuilder.Entity<PinPointModel>().HasData(pinpoints);

            List<FollowerModel> followers = new List<FollowerModel>();

            followers.Add(new FollowerModel { 
                Id = 1,
                FollowerId = 1,
                FollowedId = 2
            });

            modelBuilder.Entity<FollowerModel>().HasData(followers);
        }
    }
}