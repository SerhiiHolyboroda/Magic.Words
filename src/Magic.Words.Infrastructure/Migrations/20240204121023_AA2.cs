using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Magic.Words.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AA2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "2f6afe78-b3c4-4e9b-b396-5cbfa90a20f0", "ApplicationUser", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "DFADAS!@#@#@!", null, false, "2964b4a1-30d4-420b-9d66-312cd317eb61", false, "user1@example.com" },
                    { "user2", 0, "45a8c1c6-f506-4a5c-b312-bb817e9adcf9", "ApplicationUser", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "ADsaD@!dsadsa", null, false, "7207055d-1b6a-4e72-b66e-07678e131e6d", false, "user2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "ApplicationUserId", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, "user1", "Content for Topic 1", new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6044), "Topic 1" },
                    { 2, "user2", "Content for Topic 2", new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6094), "Topic 2" },
                    { 3, "user1", "Content for Topic 3", new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6097), "Topic 3" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "ApplicationUserId", "Content", "CreatedAt", "TopicId" },
                values: new object[,]
                {
                    { 1, "user2", "Comment 1 for Topic 1", new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6141), 1 },
                    { 2, "user1", "Comment 2 for Topic 1", new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6145), 1 },
                    { 3, "user2", "Comment 1 for Topic 2", new DateTime(2024, 2, 4, 14, 10, 22, 333, DateTimeKind.Local).AddTicks(6148), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");
        }
    }
}
