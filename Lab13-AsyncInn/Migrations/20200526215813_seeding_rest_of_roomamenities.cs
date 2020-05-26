using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab13_AsyncInn.Migrations
{
    public partial class seeding_rest_of_roomamenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "RoomId", "AmenitiesId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 2 },
                    { 4, 1 },
                    { 5, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 5, 3 });
        }
    }
}
