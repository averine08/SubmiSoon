using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubmiSoonApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedAt",
                table: "Attempts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedAt",
                table: "Attempts");
        }
    }
}
