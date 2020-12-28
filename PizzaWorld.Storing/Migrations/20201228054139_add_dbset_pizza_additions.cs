using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class add_dbset_pizza_additions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Crust_CrustEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Size_SizeEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_APizzaModel_APizzaModelEntityId",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crust",
                table: "Crust");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "Crust",
                newName: "Crusts");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_APizzaModelEntityId",
                table: "Toppings",
                newName: "IX_Toppings_APizzaModelEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaModel_Crusts_CrustEntityId",
                table: "APizzaModel",
                column: "CrustEntityId",
                principalTable: "Crusts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaModel_Sizes_SizeEntityId",
                table: "APizzaModel",
                column: "SizeEntityId",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_APizzaModel_APizzaModelEntityId",
                table: "Toppings",
                column: "APizzaModelEntityId",
                principalTable: "APizzaModel",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Crusts_CrustEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Sizes_SizeEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_APizzaModel_APizzaModelEntityId",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "Crusts",
                newName: "Crust");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_APizzaModelEntityId",
                table: "Topping",
                newName: "IX_Topping_APizzaModelEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crust",
                table: "Crust",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaModel_Crust_CrustEntityId",
                table: "APizzaModel",
                column: "CrustEntityId",
                principalTable: "Crust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaModel_Size_SizeEntityId",
                table: "APizzaModel",
                column: "SizeEntityId",
                principalTable: "Size",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_APizzaModel_APizzaModelEntityId",
                table: "Topping",
                column: "APizzaModelEntityId",
                principalTable: "APizzaModel",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
