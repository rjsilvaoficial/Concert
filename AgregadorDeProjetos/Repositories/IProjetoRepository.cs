using AgregadorDeProjetos.Models;
using AgregadorDeProjetos.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Repositories
{
    public interface IProjetoRepository
    {
        Task<List<Projeto>> GetProjetos(int pagina, int quantidade);

        Task<Projeto> GetProjeto(int id);

        Task<Projeto> PutProjeto(int id, InputProjetoViewModel projetoAtualizado);

        Task<Projeto> PostProjeto(Projeto projetoNovo);

        Task<Projeto> DeleteProjeto(int id);
    }
}
