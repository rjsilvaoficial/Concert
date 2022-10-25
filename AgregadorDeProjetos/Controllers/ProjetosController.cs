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
using AgregadorDeProjetos.Repositories;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace AgregadorDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetosController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        // GET: api/Empregados
        /// <summary>
        /// Busca uma lista de projetos!
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetEmpregados([FromQuery, Range(1, int.MaxValue)] int pagina = 1,
                                                                              [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            try
            {
                var projetos = await _projetoRepository.GetProjetos(pagina, quantidade);

                if (projetos.Count() == 0)
                    return NoContent();

                return Ok(projetos);
            }
            catch (Exception)
            {
                return Problem();
            }

        }


        // GET: api/Empregados/5
        /// <summary>
        /// ´Busca um projeto pelo id!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OutputProjetoViewModel>> GetProjeto(int id)
        {
            try
            {
                var projeto = await _projetoRepository.GetProjeto(id);

                if (projeto == null)
                {
                    return NotFound();
                }

                return projeto;
            }
            catch (Exception)
            {
                return Problem();
            }

        }


        // PUT: api/Empregados/5
        /// <summary>
        /// Atualiza os dados de um projeto!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projetoInput"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpregado([FromRoute] int id, [FromBody] InputProjetoViewModel projetoInput)
        {

            try
            {
                var projetoUpdate = await _projetoRepository.PutProjeto(id, projetoInput);
                if (projetoUpdate != null)
                {
                    return Ok(projetoUpdate);
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
        /// Cria um projeto!
        /// </summary>
        /// <param name="projetoInputViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OutputProjetoViewModel>> PostProjeto(InputProjetoViewModel projetoInputViewModel)
        {
            var projeto = new Projeto
            {
                NomeDoProjeto = projetoInputViewModel.NomeDoProjeto,
                DataDaCriacao = projetoInputViewModel.DataDaCriacao,
                DataDoTermino = projetoInputViewModel.DataDoTermino,
                EmpregadoId = int.Parse(projetoInputViewModel.Gerente)
            };

            try
            {
                await _projetoRepository.PostProjeto(projeto);
                return CreatedAtAction("GetProjeto", new { id = projeto.ProjetoId }, projeto);
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        // DELETE: api/Empregados/5
        /// <summary>
        /// Exclui um projeto pelo id!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projeto>> DeleteEmpregado(int id)
        {
            try
            {
                var projeto = await _projetoRepository.DeleteProjeto(id);
                if (projeto == null)
                {
                    return NotFound();
                }

                return projeto;
            }
            catch (Exception)
            {
                return Problem();
            }

        }

    }
}
