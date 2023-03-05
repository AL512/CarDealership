using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СarDealership.WebApi.Migrations
{
    public partial class EntityVersionControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Cars",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Cars");
        }
    }
}
