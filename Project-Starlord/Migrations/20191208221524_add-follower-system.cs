using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Starlord.Migrations
{
    public partial class addfollowersystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<int>(nullable: false),
                    FollowedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Followers",
                columns: new[] { "Id", "FollowedId", "FollowerId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 6,
                column: "Timestamp",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "PinPoints",
                keyColumn: "Id",
                keyValue: 7,
                column: "Timestamp",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 938, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimestampTo",
                value: new DateTime(2019, 12, 8, 23, 15, 23, 949, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Un0fkDvTt0TYw7Vx08dhD+8rOS6vzU1mUbZIrPXTefjOq2ko");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "ao+3Gm/c78eiT4C7i7GFIF+iXuBDx88Agl1mlF1q7HuLeavy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Followers");

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
    }
}
