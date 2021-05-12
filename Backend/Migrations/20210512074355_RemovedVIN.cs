using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class RemovedVIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VIN",
                table: "VehicleAttributes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "VehicleAttributes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
