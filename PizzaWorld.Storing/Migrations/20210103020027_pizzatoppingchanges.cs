using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class pizzatoppingchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_APizzaModel_APizzaModelEntityId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_APizzaModelEntityId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "APizzaModelEntityId",
                table: "Toppings");

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaEntityId = table.Column<long>(type: "bigint", nullable: true),
                    ToppingEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_APizzaModel_PizzaEntityId",
                        column: x => x.PizzaEntityId,
                        principalTable: "APizzaModel",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingEntityId",
                        column: x => x.ToppingEntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_PizzaEntityId",
                table: "PizzaToppings",
                column: "PizzaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingEntityId",
                table: "PizzaToppings",
                column: "ToppingEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaToppings");

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

            migrationBuilder.AddColumn<long>(
                name: "APizzaModelEntityId",
                table: "Toppings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_APizzaModelEntityId",
                table: "Toppings",
                column: "APizzaModelEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_APizzaModel_APizzaModelEntityId",
                table: "Toppings",
                column: "APizzaModelEntityId",
                principalTable: "APizzaModel",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
