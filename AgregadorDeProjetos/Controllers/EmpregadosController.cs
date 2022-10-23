using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgregadorDeProjetos.Data;
using AgregadorDeProjetos.Models;

namespace AgregadorDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpregadosController : ControllerBase
    {
        private readonly MeuContexto _context;

        public EmpregadosController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/Empregados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empregado>>> GetEmpregados()
        {
            return await _context.Empregados.ToListAsync();
        }

        // GET: api/Empregados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empregado>> GetEmpregado(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);

            if (empregado == null)
            {
                return NotFound();
            }

            return empregado;
        }

        // PUT: api/Empregados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpregado(int id, Empregado empregado)
        {
            if (id != empregado.EmpregadoId)
            {
                return BadRequest();
            }

            _context.Entry(empregado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpregadoExists(id))
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

        // POST: api/Empregados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empregado>> PostEmpregado(Empregado empregado)
        {
            _context.Empregados.Add(empregado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpregado", new { id = empregado.EmpregadoId }, empregado);
        }

        // DELETE: api/Empregados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empregado>> DeleteEmpregado(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);
            if (empregado == null)
            {
                return NotFound();
            }

            _context.Empregados.Remove(empregado);
            await _context.SaveChangesAsync();

            return empregado;
        }

        private bool EmpregadoExists(int id)
        {
            return _context.Empregados.Any(e => e.EmpregadoId == id);
        }
    }
}
