using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Models
{
    public class Membros
    {
        [Column("# id_empregado")]
        public int EmpregadoId { get; set; }

        [Column("# id_project")]
        public int ProjetoId { get; set; }

    }
}
