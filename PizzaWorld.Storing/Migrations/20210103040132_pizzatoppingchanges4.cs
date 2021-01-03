using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class pizzatoppingchanges4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppings_Topping_ToppingEntityId",
                table: "PizzaToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppings_Toppings_ToppingEntityId",
                table: "PizzaToppings",
                column: "ToppingEntityId",
                principalTable: "Toppings",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppings_Toppings_ToppingEntityId",
                table: "PizzaToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppings_Topping_ToppingEntityId",
                table: "PizzaToppings",
                column: "ToppingEntityId",
                principalTable: "Topping",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
