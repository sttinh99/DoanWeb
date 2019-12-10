using Microsoft.EntityFrameworkCore.Migrations;

namespace TestCase.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Recceipt",
                table: "Appointments",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recceipt",
                table: "Appointments");
        }
    }
}
