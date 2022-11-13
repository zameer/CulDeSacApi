using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CulDeSacApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLibraryCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LibraryAccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryCards_LibraryAccounts_LibraryAccountId",
                        column: x => x.LibraryAccountId,
                        principalTable: "LibraryAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_LibraryAccountId",
                table: "LibraryCards",
                column: "LibraryAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryCards");
        }
    }
}
