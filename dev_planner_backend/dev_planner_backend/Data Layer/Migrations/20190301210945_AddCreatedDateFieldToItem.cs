using Microsoft.EntityFrameworkCore.Migrations;

namespace dev_planner_backend.Migrations
{
    public partial class AddCreatedDateFieldToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Items",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Items",
                newName: "Created");
        }
    }
}
