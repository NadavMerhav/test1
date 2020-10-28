using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthForYou.Migrations
{
    public partial class MedicTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicTeam",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Avaiable = table.Column<DateTime>(nullable: false),
                    YearsOfexp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicTeam", x => x.DoctorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicTeam");
        }
    }
}
