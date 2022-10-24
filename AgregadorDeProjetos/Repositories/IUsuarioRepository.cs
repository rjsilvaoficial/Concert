using AgregadorDeProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Repositories
{
    public interface IUsuarioRepository
    {
        public void Adicionar(Usuario usuario);
        public void Commit();
        public Usuario ObterUsuario(string login);
    }
}
