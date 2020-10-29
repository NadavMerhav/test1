using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthForYou.Migrations
{
    public partial class Fullname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullname",
                table: "AspNetUsers");
        }
    }
}
