// <auto-generated />
using System;
using AgregadorDeProjetos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgregadorDeProjetos.Migrations
{
    [DbContext(typeof(MeuContexto))]
    [Migration("20221022231441_Instanciando_o_DB")]
    partial class Instanciando_o_DB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AgregadorDeProjetos.Models.Empregado", b =>
                {
                    b.Property<int>("EmpregadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_empregado")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnName("endereço")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnName("primeiro-nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Telefone")
                        .HasColumnName("telefone")
                        .HasColumnType("int");

                    b.Property<string>("UltimoNome")
                        .HasColumnName("último-nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("EmpregadoId");

                    b.ToTable("empregados");
                });

            modelBuilder.Entity("AgregadorDeProjetos.Models.Membro", b =>
                {
                    b.Property<int>("EmpregadoId")
                        .HasColumnName("# id_empregado")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnName("# id_project")
                        .HasColumnType("int");

                    b.HasKey("EmpregadoId", "ProjetoId");

                    b.ToTable("membros");
                });

            modelBuilder.Entity("AgregadorDeProjetos.Models.Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_project")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDaCriacao")
                        .HasColumnName("data-da-criação")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDoTermino")
                        .HasColumnName("data-término")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmpregadoId")
                        .HasColumnName("# gerente")
                        .HasColumnType("int");

                    b.Property<string>("NomeDoProjeto")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ProjetoId");

                    b.ToTable("projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
