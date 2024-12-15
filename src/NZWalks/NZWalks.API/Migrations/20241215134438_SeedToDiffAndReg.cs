using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedToDiffAndReg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("75fac35a-7795-460c-be95-bc89514b6817"), "Easy" },
                    { new Guid("7887e703-bad7-4c34-be97-112605673f74"), "Hard" },
                    { new Guid("7f5e1f21-4f05-45e1-95b5-3d5be3aca5f0"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("07d44bb6-cf74-4b1c-99af-9472e30272b5"), "WLT", "Welington", "some-image-from-Welington.jpg" },
                    { new Guid("0ebdfe73-77bb-4a85-b798-c3230f77f6d4"), "BLH", "Bellingham", "some-image-from-Bellingham.jpg" },
                    { new Guid("3176866f-c7ac-412e-b676-07ae4e1bb97a"), "AKL", "Auckland", "some-image-from-Auckland.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("75fac35a-7795-460c-be95-bc89514b6817"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7887e703-bad7-4c34-be97-112605673f74"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7f5e1f21-4f05-45e1-95b5-3d5be3aca5f0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("07d44bb6-cf74-4b1c-99af-9472e30272b5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0ebdfe73-77bb-4a85-b798-c3230f77f6d4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3176866f-c7ac-412e-b676-07ae4e1bb97a"));
        }
    }
}
