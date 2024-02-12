using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic.Words.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AA6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "16e68ea8-4df2-45e0-8ec5-c478669ea2c5", "b1151bca-c64d-4628-82e2-730671212bc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "af52e0d7-d825-4ca3-855a-03d5ed4a34a0", "22317872-4d40-43f9-af26-24f16d75a7d5" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 7, 27, 197, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 7, 27, 197, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 7, 27, 197, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 7, 27, 197, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 7, 27, 197, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 7, 27, 197, DateTimeKind.Local).AddTicks(8833));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
