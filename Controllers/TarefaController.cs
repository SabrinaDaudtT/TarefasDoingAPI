using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasDoingAPI.Models;
using TarefasDoingAPI.Repositories.Contracts;

namespace TarefasDoingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TarefaController(ITarefaRepository tarefaRepository, UserManager<ApplicationUser> userManager)
        {
            _tarefaRepository = tarefaRepository;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("sincronizar")]
        public ActionResult Sincronizacao([FromBody]List<Tarefas> taferas)
        {
            return Ok (_tarefaRepository.Sicronizacao(taferas));
        }

        [Authorize]
        [HttpGet("restaurar")]
        public ActionResult Restaurar(DateTime data)
        {
            var usuario = _userManager.GetUserAsync(HttpContext.User).Result;
            return Ok(_tarefaRepository.Restauracao(usuario, data));
        }
    }
}
