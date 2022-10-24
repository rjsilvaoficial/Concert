using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgregadorDeProjetos.Data;
using AgregadorDeProjetos.Models;
using AgregadorDeProjetos.VIewModels;

namespace AgregadorDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly MeuContexto _context;

        public ProjetosController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/Projetos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        // GET: api/Projetos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutputProjectViewModel>> GetProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return NotFound();
            }
            var projetoOutput = new OutputProjectViewModel
            {
                ProjetoId = projeto.ProjetoId,
                DataDaCriacao = projeto.DataDaCriacao,
                DataDoTermino = projeto.DataDoTermino,
                GerenteId = projeto.EmpregadoId,
                Gerente = _context.Empregados.FirstOrDefault(e => e.EmpregadoId == projeto.EmpregadoId)
            };

            return projetoOutput;
        }

        // PUT: api/Projetos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(int id, Projeto projeto)
        {
            if (id != projeto.ProjetoId)
            {
                return BadRequest();
            }

            _context.Entry(projeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projetos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OutputProjectViewModel>> PostProjeto(InputProjetoViewModel projetoVM)
        {
            var projeto = new Projeto
            {
                NomeDoProjeto = projetoVM.NomeDoProjeto,
                DataDaCriacao = projetoVM.DataDaCriacao,
                DataDoTermino = projetoVM.DataDoTermino,
                EmpregadoId = projetoVM.Gerente
            };
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProjeto", new { id = projeto.ProjetoId }, projeto);
        }

        // DELETE: api/Projetos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projeto>> DeleteProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return projeto;
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projetos.Any(e => e.ProjetoId == id);
        }
    }
}
