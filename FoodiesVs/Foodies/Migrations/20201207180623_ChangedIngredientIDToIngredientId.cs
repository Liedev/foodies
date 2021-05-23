using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodies.Migrations
{
    public partial class ChangedIngredientIDToIngredientId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredientID",
                schema: "Foodies",
                table: "Ingredient",
                newName: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredientId",
                schema: "Foodies",
                table: "Ingredient",
                newName: "IngredientID");
        }
    }
}
