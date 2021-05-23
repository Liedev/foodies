using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodies.Migrations
{
    public partial class ChangedCountToAmountInMealIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                schema: "Foodies",
                table: "MealIngredient");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                schema: "Foodies",
                table: "MealIngredient",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Foodies",
                table: "MealIngredient");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                schema: "Foodies",
                table: "MealIngredient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
