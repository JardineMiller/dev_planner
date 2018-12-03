using Microsoft.EntityFrameworkCore.Migrations;

namespace dev_planner_backend.Migrations
{
    public partial class ChangeItemPersonIdToOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_People_PersonId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Items",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_PersonId",
                table: "Items",
                newName: "IX_Items_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_People_OwnerId",
                table: "Items",
                column: "OwnerId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_People_OwnerId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Items",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OwnerId",
                table: "Items",
                newName: "IX_Items_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_People_PersonId",
                table: "Items",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
