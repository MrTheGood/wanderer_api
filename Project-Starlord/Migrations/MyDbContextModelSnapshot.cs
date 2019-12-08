﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Starlord.Data;

namespace Project_Starlord.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project_Starlord.Models.PinPointModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("PinPoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = 50m,
                            Longitude = 20m,
                            Timestamp = new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(1370),
                            TripId = 1
                        },
                        new
                        {
                            Id = 2,
                            Latitude = 40m,
                            Longitude = 60m,
                            Timestamp = new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3361),
                            TripId = 1
                        },
                        new
                        {
                            Id = 3,
                            Latitude = 300m,
                            Longitude = 12m,
                            Timestamp = new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3420),
                            TripId = 1
                        },
                        new
                        {
                            Id = 4,
                            Latitude = 280m,
                            Longitude = 47m,
                            Timestamp = new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3425),
                            TripId = 1
                        },
                        new
                        {
                            Id = 5,
                            Latitude = 792m,
                            Longitude = 147m,
                            Timestamp = new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3429),
                            TripId = 2
                        },
                        new
                        {
                            Id = 6,
                            Latitude = 123m,
                            Longitude = 862m,
                            Timestamp = new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3443),
                            TripId = 2
                        },
                        new
                        {
                            Id = 7,
                            Latitude = 1200m,
                            Longitude = 1300m,
                            Timestamp = new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3448),
                            TripId = 2
                        });
                });

            modelBuilder.Entity("Project_Starlord.Models.ResetTokenModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsTokenUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResetTokens");
                });

            modelBuilder.Entity("Project_Starlord.Models.TripModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TimestampFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimestampTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("TripName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TimestampFrom = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TimestampTo = new DateTime(2019, 12, 5, 11, 53, 53, 957, DateTimeKind.Local).AddTicks(5361),
                            TripName = "trip1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            TimestampFrom = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TimestampTo = new DateTime(2019, 12, 5, 11, 53, 53, 961, DateTimeKind.Local).AddTicks(7635),
                            TripName = "trip2",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Project_Starlord.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "007@hr.nl",
                            Password = "/tosKJRV4COUnemgqaAsMx4O8scSMJ5ocqPdy3mYJ5ZUn2mW",
                            Username = "SecretAgent"
                        },
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.nl",
                            Password = "xh+TXWUEQyYnE0U/sXhuaVrFCIC27Xmfus5x09Yf49GIySFL",
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("Project_Starlord.Models.PinPointModel", b =>
                {
                    b.HasOne("Project_Starlord.Models.TripModel", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
