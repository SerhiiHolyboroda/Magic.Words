using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic.Words.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AA3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Topics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6fadd724-49dd-48da-ac7e-bcdaccb352b6", "b0d18a7a-3ff9-4ce8-8e38-44b07fc26ab5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec94618f-9e9a-4b2d-9e37-e971ca294f98", "e79e291e-e6b5-4c47-be1c-6d20d91924be" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "isActive" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 50, 3, 674, DateTimeKind.Local).AddTicks(9053), true });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "isActive" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 50, 3, 674, DateTimeKind.Local).AddTicks(9058), true });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "isActive" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 50, 3, 674, DateTimeKind.Local).AddTicks(9061), true });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "isActive" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 50, 3, 674, DateTimeKind.Local).AddTicks(8971), true });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "isActive" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 50, 3, 674, DateTimeKind.Local).AddTicks(9016), true });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "isActive" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 50, 3, 674, DateTimeKind.Local).AddTicks(9019), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f6afe78-b3c4-4e9b-b396-5cbfa90a20f0", "2964b4a1-30d4-420b-9d66-312cd317eb61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "45a8c1c6-f506-4a5c-b312-bb817e9adcf9", "7207055d-1b6a-4e72-b66e-07678e131e6d" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6097));
        }
    }
}
