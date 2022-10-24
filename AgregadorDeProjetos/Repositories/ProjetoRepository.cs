using AgregadorDeProjetos.Data;
using AgregadorDeProjetos.Models;
using AgregadorDeProjetos.VIewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly MeuContexto _context;

        public ProjetoRepository(MeuContexto context)
        {
            _context = context;
        }



        public async Task<List<Projeto>> GetProjetos(int pagina, int quantidade)
        {
            try
            {
                var projetos = await _context.Projetos.Skip((pagina - 1) * quantidade).Take(quantidade).ToListAsync();
                return projetos;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }


        public async Task<Projeto> GetProjeto(int id)
        {
            try
            {
                var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.ProjetoId == id);

                if (projeto != null)
                {
                    return projeto;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }


        public async Task<Projeto> PutProjeto(int id, InputProjetoViewModel projetoAtualizado)
        {
            Projeto projetoOriginal = await _context.Projetos.FirstOrDefaultAsync(p => p.ProjetoId == id);

            if (projetoOriginal != null)
            {
                _context.Attach<Projeto>(projetoOriginal);

                projetoOriginal.NomeDoProjeto = projetoOriginal.NomeDoProjeto;
                projetoOriginal.DataDaCriacao = projetoAtualizado.DataDaCriacao;
                projetoOriginal.DataDoTermino = projetoAtualizado.DataDoTermino;

                try
                {
                    _context.Projetos.Update(projetoOriginal);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }

            }
            return null;
        }


        public async Task<Projeto> PostProjeto(Projeto projetoNovo)
        {
            try
            {
                _context.Projetos.Add(projetoNovo);
                await _context.SaveChangesAsync();

                return projetoNovo;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }


        public async Task<Projeto> DeleteProjeto(int id)
        {
            try
            {
                var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.EmpregadoId == id);
                if (projeto == null)
                {
                    return null;
                }

                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();

                return projeto;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
