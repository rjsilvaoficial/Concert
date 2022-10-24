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
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        public string UltimoNome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [RegularExpression("^[1-9]{9}$", ErrorMessage = "Telefone aceita apenas números no formato: xxxxxxxxx!")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Digite um e-mail em formato válido!")]
        public string Email { get; set; }
    }
}
