using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Starlord.Migrations
{
    public partial class Add_Seed_Data_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                column: "Timestamp",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimestampTo",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 555, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimestampTo",
                value: new DateTime(2019, 11, 25, 15, 33, 17, 559, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "geheim");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "geheim");
        }
    }
}
