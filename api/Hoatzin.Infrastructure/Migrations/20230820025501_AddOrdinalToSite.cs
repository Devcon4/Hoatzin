﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hoatzin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdinalToSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordinal",
                table: "Sites",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ordinal",
                table: "Sites");
        }
    }
}
