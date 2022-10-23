﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Models
{
    [Table("empregados")]
    public class Empregado
    {
        //public Empregado()
        //{
        //    Membros = new List<Membro>();
        //}

        [Column("id_empregado")]
        public int EmpregadoId { get; set; }

        [Column("primeiro-nome")]
        public string PrimeiroNome { get; set; }

        [Column("último-nome")]
        public string UltimoNome { get; set; }

        [Column("telefone")]
        public int Telefone { get; set; }

        [Column("endereço")]
        public string Email { get; set; }

        //public ICollection<Membro>? Membros { get; set; }






    }
}
