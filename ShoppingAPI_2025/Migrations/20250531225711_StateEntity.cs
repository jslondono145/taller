using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI_2025.Migrations
{
    public partial class StateEntity : Migration
    {
        protected override void Up(MigrationBuilder databaseMigrationBuilder)
        {
            databaseMigrationBuilder.CreateTable(
                name: "States",
                columns: tableDefinition => new
                {
                    EntityId = tableDefinition.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = tableDefinition.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssociatedCountryId = tableDefinition.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = tableDefinition.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = tableDefinition.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationDate = tableDefinition.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: tableConstraints =>
                {
                    tableConstraints.PrimaryKey("PK_States", stateEntity => stateEntity.EntityId);
                    tableConstraints.ForeignKey(
                        name: "FK_States_Countries_AssociatedCountryId",
                        column: stateEntity => stateEntity.AssociatedCountryId,
                        principalTable: "Countries",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    tableConstraints.ForeignKey(
                        name: "FK_States_States_StateId",
                        column: stateEntity => stateEntity.StateId,
                        principalTable: "States",
                        principalColumn: "EntityId");
                });

            databaseMigrationBuilder.CreateIndex(
                name: "IX_States_AssociatedCountryId",
                table: "States",
                column: "AssociatedCountryId");

            databaseMigrationBuilder.CreateIndex(
                name: "IX_States_StateName_AssociatedCountryId",
                table: "States",
                columns: new[] { "StateName", "AssociatedCountryId" },
                unique: true);

            databaseMigrationBuilder.CreateIndex(
                name: "IX_States_StateId",
                table: "States",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder databaseMigrationBuilder)
        {
            databaseMigrationBuilder.DropTable(
                name: "States");
        }
    }
}
