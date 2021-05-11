using Microsoft.EntityFrameworkCore.Migrations;

namespace MapMvp1.Migrations
{
    public partial class AddedSpeedinLocationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "LocationHistories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "LocationHistories");
        }
    }
}
