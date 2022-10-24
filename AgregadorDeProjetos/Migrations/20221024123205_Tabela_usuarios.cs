using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgregadorDeProjetos.Migrations
{
    public partial class Tabela_usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_membros_empregados_# id_empregado",
                table: "membros");

            migrationBuilder.DropForeignKey(
                name: "FK_membros_projetos_# id_project",
                table: "membros");

            migrationBuilder.DropForeignKey(
                name: "FK_projetos_empregados_# gerente",
                table: "projetos");

            migrationBuilder.DropIndex(
                name: "IX_projetos_# gerente",
                table: "projetos");

            migrationBuilder.DropIndex(
                name: "IX_membros_# id_project",
                table: "membros");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "projetos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "projetos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_projetos_# gerente",
                table: "projetos",
                column: "# gerente");

            migrationBuilder.CreateIndex(
                name: "IX_membros_# id_project",
                table: "membros",
                column: "# id_project");

            migrationBuilder.AddForeignKey(
                name: "FK_membros_empregados_# id_empregado",
                table: "membros",
                column: "# id_empregado",
                principalTable: "empregados",
                principalColumn: "id_empregado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_membros_projetos_# id_project",
                table: "membros",
                column: "# id_project",
                principalTable: "projetos",
                principalColumn: "id_project",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projetos_empregados_# gerente",
                table: "projetos",
                column: "# gerente",
                principalTable: "empregados",
                principalColumn: "id_empregado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
