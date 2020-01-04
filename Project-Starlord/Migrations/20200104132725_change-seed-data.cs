using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Starlord.Migrations
{
    public partial class changeseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 50000000000000m, 20000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(7673) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 40000000000000m, 60000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9166) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 300000000000000m, 12000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 280000000000000m, 47000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 792000000000000m, 147000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 123000000000000m, 862000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 1200000000000000m, 1300000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 51000000000000m, 4000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9221) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 55000000000000m, 18000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 56000000000000m, 12000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 51000000000000m, 4000000000000m, new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(9232) });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimestampTo",
                value: new DateTime(2020, 1, 4, 14, 27, 25, 7, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimestampTo",
                value: new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TimestampFrom", "TimestampTo" },
                values: new object[] { new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(5718), new DateTime(2020, 1, 4, 14, 27, 25, 9, DateTimeKind.Local).AddTicks(5723) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "/kTY0LJqs2bRIB/dmzvvNwpmKPqZjc9A3WQBCE5cZJzSuM86");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "SnpFKor8blt7TiI+PxWXMO/KXWTn+ahQ28DrkdCMAmPGVZMS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 50m, 20m, new DateTime(2019, 12, 18, 13, 16, 14, 440, DateTimeKind.Local).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 40m, 60m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 300m, 12m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 280m, 47m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 792m, 147m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 123m, 862m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 1200m, 1300m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 51m, 4m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 55m, 18m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1397) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 56m, 12m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Latitude", "Longitude", "Timestamp" },
                values: new object[] { 51m, 4m, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 18, 13, 16, 14, 435, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 18, 13, 16, 14, 440, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TimestampFrom", "TimestampTo" },
                values: new object[] { new DateTime(2019, 12, 18, 13, 16, 14, 440, DateTimeKind.Local).AddTicks(6184), new DateTime(2019, 12, 18, 13, 16, 14, 440, DateTimeKind.Local).AddTicks(6189) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "dLsbZd1J92/PY/Z+EH108b6DYA22cnfu7qjfigNZ4ByLYbxJ");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "6iEbKanx9Iu+zA8ebz4R186nitpSpK9ogE0e/cU9qy8bxpuD");
        }
    }
}
