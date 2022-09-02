using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fravaersflexer.Migrations
{
    public partial class Persontables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Person");
        }
    }
}
