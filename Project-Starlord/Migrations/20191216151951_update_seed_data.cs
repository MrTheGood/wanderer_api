using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Starlord.Migrations
{
    public partial class update_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "TimestampFrom", "TimestampTo", "TripName", "UserId" },
                values: new object[] { 3, new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(1172), new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(1182), "Tyas zijn vakantie", 2 });

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

            migrationBuilder.InsertData(
                table: "PinPoints",
                columns: new[] { "Id", "Latitude", "Longitude", "Timestamp", "TripId" },
                values: new object[,]
                {
                    { 8, 51m, 4m, new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9056), 3 },
                    { 9, 55m, 18m, new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9063), 3 },
                    { 10, 56m, 12m, new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9072), 3 },
                    { 11, 51m, 4m, new DateTime(2019, 12, 16, 16, 19, 50, 241, DateTimeKind.Local).AddTicks(9079), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3361));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                column: "Timestamp",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                column: "Timestamp",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 962, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 957, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 5, 11, 53, 53, 961, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "xh+TXWUEQyYnE0U/sXhuaVrFCIC27Xmfus5x09Yf49GIySFL");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "/tosKJRV4COUnemgqaAsMx4O8scSMJ5ocqPdy3mYJ5ZUn2mW");
        }
    }
}
