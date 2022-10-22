using AgregadorDeProjetos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Data
{
    public class MeuContexto : DbContext
    {
        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options) { }

        public DbSet<Empregado> Empregados { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Membro> Membros { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membro>().HasKey(chaveComposta => new { chaveComposta.EmpregadoId, chaveComposta.ProjetoId });
        }




    }
}
