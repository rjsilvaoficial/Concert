using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgregadorDeProjetos.Data;
using AgregadorDeProjetos.Models;
using System.ComponentModel.DataAnnotations;
using AgregadorDeProjetos.Repositories;
using AgregadorDeProjetos.VIewModels;

namespace AgregadorDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpregadosController : ControllerBase
    {
        private readonly IEmpregadoRepository _empregadoRepository;

        public EmpregadosController(IEmpregadoRepository empregadoRepository)
        {
            _empregadoRepository = empregadoRepository;
        }

        // GET: api/Empregados
        /// <summary>
        /// Busca uma lista de empregados com paginação!
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empregado>>> GetEmpregados([FromQuery, Range(1, int.MaxValue)] int pagina = 1,
                                                                              [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            try
            {
                var empregados = await _empregadoRepository.GetEmpregados(pagina, quantidade);

                if (empregados.Count() == 0)
                    return NoContent();

                return Ok(empregados);
            }
            catch (Exception)
            {
                return Problem();
            }

        }


        // GET: api/Empregados/5
        /// <summary>
        /// ´Busca um empregado pelo id!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Empregado>> GetEmpregado(int id)
        {
            try
            {
                var empregado = await _empregadoRepository.GetEmpregado(id);

                if (empregado == null)
                {
                    return NotFound();
                }

                return empregado;
            }
            catch (Exception)
            {
                return Problem();
            }

        }



        // PUT: api/Empregados/5
        /// <summary>
        /// Atualiza os dados para um empregado!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="empregadoInput"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpregado([FromRoute] int id, [FromBody] InputEmpregadoViewModel empregadoInput)
        {

            try
            {
                var empregadoUpdate = await _empregadoRepository.PutEmpregado(id, empregadoInput);
                if(empregadoUpdate != null)
                {
                    return Ok(empregadoUpdate);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return Problem();
            }

        }


        // POST: api/Empregados
        /// <summary>
        /// Cria um empregado!
        /// </summary>
        /// <param name="empregadoInputViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Empregado>> PostEmpregado(InputEmpregadoViewModel empregadoInputViewModel)
        {
            var empregado = new Empregado
            {
                PrimeiroNome = empregadoInputViewModel.PrimeiroNome,
                UltimoNome = empregadoInputViewModel.UltimoNome,
                Email = empregadoInputViewModel.Email,
                Telefone = empregadoInputViewModel.Telefone
            };

            try
            {
                await _empregadoRepository.PostEmpregado(empregado);
                return CreatedAtAction("GetEmpregado", new { id = empregado.EmpregadoId }, empregado);
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        // DELETE: api/Empregados/5
        /// <summary>
        /// Exclui um empregado pelo id!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empregado>> DeleteEmpregado(int id)
        {
            try
            {
                var empregado = await _empregadoRepository.DeleteEmpregado(id);
                if (empregado == null)
                {
                    return NotFound();
                }

                return empregado;
            }
            catch (Exception)
            {
                return Problem();
            }

        }

    }
}
