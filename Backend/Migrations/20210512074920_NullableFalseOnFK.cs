using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class NullableFalseOnFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleAttributes_Vehicles_VehicleVIN",
                table: "VehicleAttributes");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleVIN",
                table: "VehicleAttributes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleAttributes_Vehicles_VehicleVIN",
                table: "VehicleAttributes",
                column: "VehicleVIN",
                principalTable: "Vehicles",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleAttributes_Vehicles_VehicleVIN",
                table: "VehicleAttributes");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleVIN",
                table: "VehicleAttributes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleAttributes_Vehicles_VehicleVIN",
                table: "VehicleAttributes",
                column: "VehicleVIN",
                principalTable: "Vehicles",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
