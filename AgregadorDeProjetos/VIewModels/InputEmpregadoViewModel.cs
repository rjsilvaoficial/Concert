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
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
    }
}
