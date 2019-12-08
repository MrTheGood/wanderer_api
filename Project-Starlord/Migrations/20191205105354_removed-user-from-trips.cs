using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Starlord.Migrations
{
    public partial class removeduserfromtrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_UserId",
                table: "Trips");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 651, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 651, DateTimeKind.Local).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 651, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 651, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 651, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 651, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 651, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimestampTo",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 644, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimestampTo",
                value: new DateTime(2019, 11, 25, 15, 39, 28, 650, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "5DSldrrtWHc8L8QBXQ561zR+MEiR+JQmIRtvWiXCrF7RJoVx");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "saLye4TVUGn83DoIqmVxMUcjX+HuKahEuE7C/rk1FrhvCi8p");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
