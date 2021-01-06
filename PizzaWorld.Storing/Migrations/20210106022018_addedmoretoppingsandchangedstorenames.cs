using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class addedmoretoppingsandchangedstorenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "Pizza Plaza");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "Pizza Bonanza");

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 5L, "Tomato Sauce" },
                    { 6L, "Shrimp" },
                    { 7L, "Crab" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 7L);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "First Store");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "Second Store");
        }
    }
}
