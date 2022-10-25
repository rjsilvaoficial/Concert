using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.VIewModels
{
    public class InputEmpregadoViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [RegularExpression("[A-Z][A-Za-z]", ErrorMessage = "Nome recebe apenas letras!")]
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [RegularExpression("[A-Z][A-Za-z]", ErrorMessage = "Sobrenome recebe apenas letras!")]
        public string UltimoNome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [RegularExpression("^[1-9]{9}$", ErrorMessage = "Telefone aceita apenas números no formato: xxxxxxxxx!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email inválido!")]
        public string Email { get; set; }
    }
}
