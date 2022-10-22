using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Models
{
    [Table("projetos")]
    public class Projeto
    {
        [Column("id_project")]
        public int ProjetoId { get; set; }

        [Column("nome")]
        [Required(ErrorMessage = "Um projeto precisa de um nome!")]
        public string NomeDoProjeto { get; set; }

        [Column("data-da-criação")]
        [Required(ErrorMessage = "Um projeto precisa de data de criação!")]
        public DateTime DataDaCriacao { get; set; }

        [Column("data-término")]
        public DateTime? DataDoTermino{ get; set; }

        [Column("# gerente")]
        public int EmpregadoId { get; set; }





    }
}
