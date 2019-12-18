using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Starlord.Migrations
{
    public partial class Add_Sequence_On_Pinpoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "PinPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 1, new DateTime(2019, 12, 18, 13, 16, 14, 440, DateTimeKind.Local).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 3, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 2, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 4, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 2, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 1, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 3, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 1, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 3, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1397) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 4, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Sequence", "Timestamp" },
                values: new object[] { 2, new DateTime(2019, 12, 18, 13, 16, 14, 441, DateTimeKind.Local).AddTicks(1405) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "PinPoints");

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 8,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 9,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 10,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 11,
                column: "Timestamp",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 235, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TimestampFrom", "TimestampTo" },
                values: new object[] { new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(1172), new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Y22tutaOHdLc9kZr4E37dsmX73m8C2FudjOKaY0fvh2mts65");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "NCkw/vo8ipnotl8M16h3/qE2YIhjbzKmFCR5r00kHeWZpsXX");
        }
    }
}
