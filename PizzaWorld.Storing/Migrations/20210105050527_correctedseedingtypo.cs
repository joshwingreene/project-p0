using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class correctedseedingtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 3L,
                column: "Inches",
                value: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 3L,
                column: "Inches",
                value: 12);
        }
    }
}
