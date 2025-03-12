using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZRegionWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09acb658-9fb7-4cb9-a2cc-507236c088f4"), "Easy" },
                    { new Guid("4c736a86-7e36-4ad5-b228-f807d8cddd33"), "Medium" },
                    { new Guid("c7656a0a-8d3a-459f-8f54-fdfca219afb0"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0126ad40-97c6-4082-8b2f-0088a644156c"), "AUK", "Auckland", "https://www.doc.govt.nz/globalassets/images/regions/auckland/auckland-region.jpg" },
                    { new Guid("071f8490-aa7c-47e7-9313-2bd79a5542de"), "WLG", "Wellington", "https://www.doc.govt.nz/globalassets/images/regions/wellington/wellington-region.jpg" },
                    { new Guid("2ff92ecb-1eba-4424-9f5c-f5a8361ddb5c"), "CAN", "Canterbury", "https://www.doc.govt.nz/globalassets/images/regions/canterbury/canterbury-region.jpg" },
                    { new Guid("41981686-7482-4c4a-9dd9-5125868a25cf"), "OTA", "Otago", "https://www.doc.govt.nz/globalassets/images/regions/otago/otago-region.jpg" },
                    { new Guid("7754f540-1fe9-4e27-aa90-08af22acb110"), "STL", "Southland", "https://www.doc.govt.nz/globalassets/images/regions/southland/southland-region.jpg" },
                    { new Guid("a4a43444-236e-4a70-9c6a-5f5dd75966b4"), "WKO", "Waikato", "https://www.doc.govt.nz/globalassets/images/regions/waikato/waikato-region.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("09acb658-9fb7-4cb9-a2cc-507236c088f4"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4c736a86-7e36-4ad5-b228-f807d8cddd33"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c7656a0a-8d3a-459f-8f54-fdfca219afb0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0126ad40-97c6-4082-8b2f-0088a644156c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("071f8490-aa7c-47e7-9313-2bd79a5542de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2ff92ecb-1eba-4424-9f5c-f5a8361ddb5c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("41981686-7482-4c4a-9dd9-5125868a25cf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7754f540-1fe9-4e27-aa90-08af22acb110"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4a43444-236e-4a70-9c6a-5f5dd75966b4"));
        }
    }
}
