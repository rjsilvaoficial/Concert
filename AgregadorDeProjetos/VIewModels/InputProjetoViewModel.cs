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
        [RegularExpression("[A-Z][A-Za-z]", ErrorMessage = "Nome do projeto recebe apenas letras!")]
        public string NomeDoProjeto { get; set; }

        [Required(ErrorMessage = "Um projeto precisa de data de criação!")]
        public DateTime DataDaCriacao { get; set; }

        public DateTime DataDoTermino { get; set; }

        [RegularExpression("^[1-9]{1,4}$", ErrorMessage = "Você precisa atribuir o id de um de nossos 9999 colaboradores para gerente!")]
        public string Gerente { get; set; }
    }
}
