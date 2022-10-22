using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgregadorDeProjetos.Migrations
{
    public partial class Instanciando_o_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empregados",
                columns: table => new
                {
                    id_empregado = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    primeironome = table.Column<string>(name: "primeiro-nome", nullable: true),
                    últimonome = table.Column<string>(name: "último-nome", nullable: true),
                    telefone = table.Column<int>(nullable: false),
                    endereço = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empregados", x => x.id_empregado);
                });

            migrationBuilder.CreateTable(
                name: "membros",
                columns: table => new
                {
                    id_empregado = table.Column<int>(name: "# id_empregado", nullable: false),
                    id_project = table.Column<int>(name: "# id_project", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membros", x => new { x.id_empregado, x.id_project });
                });

            migrationBuilder.CreateTable(
                name: "projetos",
                columns: table => new
                {
                    id_project = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: false),
                    datadacriação = table.Column<DateTime>(name: "data-da-criação", nullable: false),
                    datatérmino = table.Column<DateTime>(name: "data-término", nullable: true),
                    gerente = table.Column<int>(name: "# gerente", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projetos", x => x.id_project);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empregados");

            migrationBuilder.DropTable(
                name: "membros");

            migrationBuilder.DropTable(
                name: "projetos");
        }
    }
}
