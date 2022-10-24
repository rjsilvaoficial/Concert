using AgregadorDeProjetos.Models;
using AgregadorDeProjetos.Repositories;
using AgregadorDeProjetos.Services;
using AgregadorDeProjetos.VIewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgregadorDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            IConfiguration configuration,
            IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Este recurso loga na aplicação!
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            var usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if (usuario == null)
            {
                return BadRequest("Login e/ou senha inválidos!");
            }

            var usuarioViewModelOutput = new UsuarioViewModelOutput
            {
                Codigo = usuario.UsuarioId,
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };

            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput

            });
        }

        /// <summary>
        /// Este recurso registra um novo usuário!
        /// </summary>
        /// <param name="registrarViewModelInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrar(RegistrarViewModelInput registrarViewModelInput)
        {

            var usuario = new Usuario();
            usuario.Login = registrarViewModelInput.Login;
            usuario.Email = registrarViewModelInput.Email;
            usuario.Senha = registrarViewModelInput.Senha;

            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", usuario);
        }
    }
}
