using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class addpizzapartsasobjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crust",
                table: "APizzaModel");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "APizzaModel");

            migrationBuilder.AddColumn<long>(
                name: "CrustEntityId",
                table: "APizzaModel",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SizeEntityId",
                table: "APizzaModel",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inches = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APizzaModelEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Topping_APizzaModel_APizzaModelEntityId",
                        column: x => x.APizzaModelEntityId,
                        principalTable: "APizzaModel",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModel_CrustEntityId",
                table: "APizzaModel",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModel_SizeEntityId",
                table: "APizzaModel",
                column: "SizeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_APizzaModelEntityId",
                table: "Topping",
                column: "APizzaModelEntityId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Crust_CrustEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Size_SizeEntityId",
                table: "APizzaModel");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropIndex(
                name: "IX_APizzaModel_CrustEntityId",
                table: "APizzaModel");

            migrationBuilder.DropIndex(
                name: "IX_APizzaModel_SizeEntityId",
                table: "APizzaModel");

            migrationBuilder.DropColumn(
                name: "CrustEntityId",
                table: "APizzaModel");

            migrationBuilder.DropColumn(
                name: "SizeEntityId",
                table: "APizzaModel");

            migrationBuilder.AddColumn<string>(
                name: "Crust",
                table: "APizzaModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "APizzaModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
