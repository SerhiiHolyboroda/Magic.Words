using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic.Words.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AA7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Subscriptions_SubscriptionId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c302529d-2825-4e8e-a38d-de508581c06f", "6823661e-062f-4a40-bccd-573f638ef44d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e0f9e681-e727-4692-befc-32fc7fb021b7", "72e4ce96-f897-4e8c-986c-bbc53f902497" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 12, 26, 486, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 12, 26, 486, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 12, 26, 486, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 12, 26, 486, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 12, 26, 486, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 11, 23, 12, 26, 486, DateTimeKind.Local).AddTicks(6509));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Subscriptions_SubscriptionId",
                table: "OrderDetails",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Subscriptions_SubscriptionId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Subscriptions_SubscriptionId",
                table: "OrderDetails",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
