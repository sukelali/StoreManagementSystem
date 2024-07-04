using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddItemDescriptionToRIMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "RequisitionItems",
                type: "text",
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "RequisitionItems");

            
        }
    }
}
