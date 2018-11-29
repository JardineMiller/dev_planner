using Microsoft.EntityFrameworkCore.Migrations;

namespace dev_planner_backend.Migrations
{
    public partial class AddedItemOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_PersonId",
                table: "Items",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_People_PersonId",
                table: "Items",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_People_PersonId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PersonId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Items");
        }
    }
}
