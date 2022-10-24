using AgregadorDeProjetos.Models;
using AgregadorDeProjetos.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Repositories
{
    public interface IEmpregadoRepository
    {

        Task<List<Empregado>> GetEmpregados(int pagina, int quantidade);

        Task<Empregado> GetEmpregado(int id);

        Task<Empregado> PutEmpregado(int id, InputEmpregadoViewModel empregadoAtualizado);

        Task<Empregado> PostEmpregado(Empregado empregadoNovo);

        Task<Empregado> DeleteEmpregado(int id);

    }
}
