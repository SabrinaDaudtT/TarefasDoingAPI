using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasDoingAPI.Models;
using TarefasDoingAPI.Repositories;

namespace TarefasDoingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsuarioController(UsuarioRepository usuarioRepository, SignInManager<ApplicationUser> signInManager)
        {
            _usuarioRepository = usuarioRepository;
            _signInManager = signInManager;
        }

        
        public ActionResult Login([FromBody] UsuarioDTO usuarioDTO)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("ConfirmacaoSenha");

            if (ModelState.IsValid)
            {
                ApplicationUser usuario = _usuarioRepository.Obter(usuarioDTO.Email,usuarioDTO.Senha);
                if(usuario != null)
                {
                    //Login no Identity
                    _signInManager.SignInAsync(usuario, false);

                    // retorna Token (JWT)
                    return Ok();
                }
                else
                {
                    return NotFound("Usuário não encontrado!");
                }
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
        }
    }
}
