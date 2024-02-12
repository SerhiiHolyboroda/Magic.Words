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
            migrationBuilder.AddColumn<int>(
                name: "ShopItemId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ShopItemId",
                table: "OrderDetails",
                column: "ShopItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ShopItem_ShopItemId",
                table: "OrderDetails",
                column: "ShopItemId",
                principalTable: "ShopItem",
                principalColumn: "ShopItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ShopItem_ShopItemId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ShopItemId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ShopItemId",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c6848a5c-602e-4eb4-b4b3-fda9782e917a", "cfcb55a7-81ff-433c-8394-c85e826598aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ecd82e10-3195-40c0-b784-1ad8b51c53d8", "6381a779-148d-4c0a-aa57-708aeef5f519" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 18, 42, 29, 942, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 18, 42, 29, 942, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 18, 42, 29, 942, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 18, 42, 29, 942, DateTimeKind.Local).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 18, 42, 29, 942, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 18, 42, 29, 942, DateTimeKind.Local).AddTicks(4418));
        }
    }
}
