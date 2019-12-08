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

            modelBuilder.Entity<TripModel>().HasData(trips);

            List<PinPointModel> pinpoints = new List<PinPointModel>();

            pinpoints.Add(new PinPointModel
            {
                Latitude = 50,
                Longitude = 20,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 1
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 40,
                Longitude = 60,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 2
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 300,
                Longitude = 12,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 3
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 280,
                Longitude = 47,
                Timestamp = DateTime.Now,
                TripId = 1,
                Id = 4
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 792,
                Longitude = 147,
                Timestamp = DateTime.Now,
                TripId = 2,
                Id = 5
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 123,
                Longitude = 862,
                Timestamp = DateTime.Now,
                TripId = 2,
                Id = 6
            });

            pinpoints.Add(new PinPointModel
            {
                Latitude = 1200,
                Longitude = 1300,
                Timestamp = DateTime.Now,
                TripId = 2,
                Id = 7
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