using AgregadorDeProjetos.Data;
using AgregadorDeProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MeuContexto _context;

        public UsuarioRepository(MeuContexto context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Login == login);

        }
    }
}
