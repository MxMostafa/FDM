﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Infra.Migrations
{
    /// <inheritdoc />
    public partial class removetest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "CategoryGroups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "CategoryGroups",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
