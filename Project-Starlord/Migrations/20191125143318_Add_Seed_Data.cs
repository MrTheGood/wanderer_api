using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Starlord.Migrations
{
    public partial class Add_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Token", "Username" },
                values: new object[] { 2, "007@hr.nl", "geheim", null, "SecretAgent" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Token", "Username" },
                values: new object[] { 1, "admin@admin.nl", "geheim", null, "Admin" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "TimestampFrom", "TimestampTo", "TripName", "UserId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(2166), "trip2", 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "TimestampFrom", "TimestampTo", "TripName", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 25, 15, 33, 17, 555, DateTimeKind.Local).AddTicks(7724), "trip1", 1 });

            migrationBuilder.InsertData(
                table: "PinPoints",
                columns: new[] { "Id", "Latitude", "Longitude", "Timestamp", "TripId" },
                values: new object[,]
                {
                    { 5, 792m, 147m, new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7918), 2 },
                    { 6, 123m, 862m, new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7931), 2 },
                    { 7, 1200m, 1300m, new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7938), 2 },
                    { 1, 50m, 20m, new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(5838), 1 },
                    { 2, 40m, 60m, new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7791), 1 },
                    { 3, 300m, 12m, new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7908), 1 },
                    { 4, 280m, 47m, new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7914), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
