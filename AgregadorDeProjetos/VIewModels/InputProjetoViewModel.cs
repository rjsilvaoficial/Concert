using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.VIewModels
{
    public class InputProjetoViewModel
    {
        [Required(ErrorMessage = "Um projeto precisa de um nome!")]
        public string NomeDoProjeto { get; set; }

        [Required(ErrorMessage = "Um projeto precisa de data de criação!")]
        public DateTime DataDaCriacao { get; set; }

        public DateTime DataDoTermino { get; set; }

        //[RegularExpression("([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9])", ErrorMessage = "Você precisa atribuir um id de gerente válido ao projeto!")]
        [RegularExpression("^[1-9]{1,4}$", ErrorMessage = "Você precisa atribuir um id de gerente válido ao projeto!")]
        public int Gerente { get; set; }
    }
}
