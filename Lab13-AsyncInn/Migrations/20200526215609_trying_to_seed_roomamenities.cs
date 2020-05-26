using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab13_AsyncInn.Migrations
{
    public partial class trying_to_seed_roomamenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_AmenitiesId",
                table: "RoomAmenities");

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "RoomId", "AmenitiesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "RoomId", "AmenitiesId" },
                values: new object[] { 6, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenitiesId",
                table: "RoomAmenities",
                column: "AmenitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_AmenitiesId",
                table: "RoomAmenities");

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenitiesId",
                table: "RoomAmenities",
                column: "AmenitiesId",
                unique: true);
        }
    }
}
