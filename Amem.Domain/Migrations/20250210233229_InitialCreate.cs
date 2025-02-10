using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiturgiasDiarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    PrimeiraLeitura = table.Column<string>(type: "text", nullable: true),
                    SalmoResponsorial = table.Column<string>(type: "text", nullable: true),
                    SegundaLeitura = table.Column<string>(type: "text", nullable: true),
                    Evangelho = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiturgiasDiarias", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiturgiasDiarias");
        }
    }
}
