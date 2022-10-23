﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.VIewModels
{
    public class InputProjectViewModel
    {
        [Required(ErrorMessage = "Um projeto precisa de um nome!")]
        public string NomeDoProjeto { get; set; }

        [Required(ErrorMessage = "Um projeto precisa de data de criação!")]
        public DateTime DataDaCriacao { get; set; }


        public DateTime DataDoTermino { get; set; }

        [Required(ErrorMessage = "Gerente precisa de um número inteiro!")]
        public int Gerente { get; set; }
    }
}
