using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.VIewModels
{
    public class RegistrarViewModelInput
    {
        [Required(ErrorMessage = "Campo Login é obrigatório!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório!")]
        //[Compare(nameof(Login), ErrorMessage = "Esse campo compara Email e Login e o segundo não pode divergir do primeiro")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório!")]
        public string Senha { get; set; }
    }
}
