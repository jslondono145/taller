using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI_2025.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder databaseMigrationBuilder)
        {
            databaseMigrationBuilder.CreateTable(
                name: "Countries",
                columns: tableDefinition => new
                {
                    EntityId = tableDefinition.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = tableDefinition.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = tableDefinition.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationDate = tableDefinition.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: tableConstraints =>
                {
                    tableConstraints.PrimaryKey("PK_Countries", countryEntity => countryEntity.EntityId);
                });

            databaseMigrationBuilder.CreateIndex(
                name: "IX_Countries_CountryName",
                table: "Countries",
                column: "CountryName",
                unique: true);
        }

        protected override void Down(MigrationBuilder databaseMigrationBuilder)
        {
            databaseMigrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
