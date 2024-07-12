using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utils.Morant.Migrations
{
    /// <inheritdoc />
    public partial class Uri_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortUri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Short_url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expires_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUri", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUri");
        }
    }
}
