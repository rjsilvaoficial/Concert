using Microsoft.EntityFrameworkCore.Migrations;

namespace AgregadorDeProjetos.Migrations
{
    public partial class Atualizacao_muitos_para_muitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
