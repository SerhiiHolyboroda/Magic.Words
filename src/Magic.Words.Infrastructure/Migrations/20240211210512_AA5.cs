using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic.Words.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AA5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "574cd22e-9c28-4a14-adb6-bac7108122fd", "2c5efbd0-c201-4278-ab7b-4240b9c448b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d900c721-777f-44a1-a6f1-95f2b41f8ee7", "9dcdc65b-2469-4cc3-bd1c-4b3012762f3c" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 5, 9, 875, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 5, 9, 875, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 5, 9, 875, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 5, 9, 875, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 5, 9, 875, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 5, 9, 875, DateTimeKind.Local).AddTicks(1514));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dd036213-74cd-4bac-a859-a7787463a3d0", "74b31286-d324-40a6-b709-7bb123eabffa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7d350066-6a57-4592-b13f-5309b9f9f4d3", "91d5d73e-40c5-4594-86b3-322f4e056702" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 22, 55, 20, 255, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 22, 55, 20, 255, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 22, 55, 20, 255, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 22, 55, 20, 255, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 22, 55, 20, 255, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 22, 55, 20, 255, DateTimeKind.Local).AddTicks(76));
        }
    }
}
