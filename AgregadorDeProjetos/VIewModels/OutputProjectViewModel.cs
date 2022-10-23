using AgregadorDeProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.VIewModels
{
    public class OutputProjectViewModel
    {
        public int ProjetoId { get; set; }

        public string NomeDoProjeto { get; set; }

        public DateTime DataDaCriacao { get; set; }

        public DateTime? DataDoTermino { get; set; }

        public int GerenteId { get; set; }

        public Empregado Gerente { get; set; }

        //public ICollection<Membro>? Membros { get; set; }
    }
}
