using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthForYou.Migrations
{
    public partial class Expertise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Expertise",
                table: "MedicTeam",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expertise",
                table: "MedicTeam");
        }
    }
}
