using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 485, DateTimeKind.Local).AddTicks(9891), "Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 485, DateTimeKind.Local).AddTicks(9935), "Industrial, Garden & Outdoors" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 485, DateTimeKind.Local).AddTicks(9940), "Grocery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 22, 51, 19, 486, DateTimeKind.Local).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 22, 51, 19, 486, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 22, 51, 19, 486, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 22, 51, 19, 486, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 487, DateTimeKind.Local).AddTicks(2245), "Quia amet koştum ipsa yapacakmış.", "Nostrum." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 487, DateTimeKind.Local).AddTicks(2273), "Düşünüyor velit laboriosam et eaque.", "Ab yapacakmış." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 487, DateTimeKind.Local).AddTicks(2312), "Nesciunt koyun uzattı voluptatum beatae.", "Sarmal." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 488, DateTimeKind.Local).AddTicks(8252), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 2.153197993814090m, 599.33m, "Tasty Plastic Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 51, 19, 488, DateTimeKind.Local).AddTicks(8276), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 7.927879578965170m, 430.52m, "Handmade Steel Mouse" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 471, DateTimeKind.Local).AddTicks(996), "Sports, Music & Home" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 471, DateTimeKind.Local).AddTicks(1012), "Clothing, Outdoors & Toys" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 471, DateTimeKind.Local).AddTicks(1016), "Outdoors" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 31, 15, 24, 19, 471, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 31, 15, 24, 19, 471, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 31, 15, 24, 19, 471, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 31, 15, 24, 19, 471, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 472, DateTimeKind.Local).AddTicks(7959), "Consequatur quia çakıl bilgiyasayarı çorba.", "Veritatis." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 472, DateTimeKind.Local).AddTicks(8031), "Yapacakmış gidecekmiş dolorem commodi nihil.", "Bundan qui." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 472, DateTimeKind.Local).AddTicks(8078), "Numquam bilgisayarı magni commodi camisi.", "Aspernatur." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 475, DateTimeKind.Local).AddTicks(102), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 6.806019029358030m, 710.20m, "Generic Soft Cheese" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 31, 15, 24, 19, 475, DateTimeKind.Local).AddTicks(126), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 9.864575321511730m, 861.63m, "Rustic Frozen Shoes" });
        }
    }
}
