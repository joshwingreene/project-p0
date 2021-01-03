using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class pizzatoppingchanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 3L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 1L, "Cheese" });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 2L, "Pepperoni" });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 3L, "Sausage" });
        }
    }
}
