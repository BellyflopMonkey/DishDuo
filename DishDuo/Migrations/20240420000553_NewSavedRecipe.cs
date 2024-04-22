using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishDuo.Migrations
{
    public partial class NewSavedRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedRecipes_OrderRecipeDetails_RecipeId",
                table: "SavedRecipes");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedRecipes_Recipe_RecipeId",
                table: "SavedRecipes",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedRecipes_Recipe_RecipeId",
                table: "SavedRecipes");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedRecipes_OrderRecipeDetails_RecipeId",
                table: "SavedRecipes",
                column: "RecipeId",
                principalTable: "OrderRecipeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
