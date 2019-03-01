using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dev_planner_backend.Migrations
{
    public partial class AddCreatedDateToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Items",
                nullable: false,
                defaultValue: new DateTimeOffset(1970, 1, 1, 0, 0, 0,  TimeSpan.Zero));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Items");
        }
    }
}
