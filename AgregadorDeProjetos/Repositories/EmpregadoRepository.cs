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
    public class EmpregadoRepository : IEmpregadoRepository
    {
        private readonly MeuContexto _context;

        public EmpregadoRepository(MeuContexto context)
        {
            _context = context;
        }

        public async Task<List<Empregado>> GetEmpregados(int pagina, int quantidade)
        {
            try
            {
                var empregados = await _context.Empregados.Skip((pagina - 1) * quantidade).Take(quantidade).ToListAsync();
                return empregados;
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public async Task<Empregado> GetEmpregado(int id)
        {
            try
            {
                var empregado = await _context.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == id);

                if (empregado != null)
                {
                    return empregado;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public async Task<Empregado> PutEmpregado(int id, InputEmpregadoViewModel empregadoAtualizado)
        {
            Empregado empregadoOriginal = await _context.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == id);

            if (empregadoOriginal != null)
            {
                _context.Attach<Empregado>(empregadoOriginal);

                empregadoOriginal.PrimeiroNome = empregadoAtualizado.PrimeiroNome;
                empregadoOriginal.UltimoNome = empregadoAtualizado.UltimoNome;
                empregadoOriginal.Telefone = int.Parse(empregadoAtualizado.Telefone);
                empregadoOriginal.Email = empregadoAtualizado.Email;

                try
                {
                    _context.Empregados.Update(empregadoOriginal);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }

            }
            return null;
        }

        public async Task<Empregado> PostEmpregado(Empregado empregadoNovo)
        {
            try
            {
                _context.Empregados.Add(empregadoNovo);
                await _context.SaveChangesAsync();

                return empregadoNovo;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public async Task<Empregado> DeleteEmpregado(int id)
        {
            try
            {
                var empregado = await _context.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == id);
                if (empregado == null)
                {
                    return null;
                }

                _context.Empregados.Remove(empregado);
                await _context.SaveChangesAsync();

                return empregado;
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

    }
}
