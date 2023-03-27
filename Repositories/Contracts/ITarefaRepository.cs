using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasDoingAPI.Models;

namespace TarefasDoingAPI.Repositories.Contracts
{
    public interface ITarefaRepository
    {
        List<Tarefas> Sicronizacao(List<Tarefas> tafefas);

        List<Tarefas> Restauracao(ApplicationUser usuario ,DateTime dataUltimaSicronizacao);
    }
}
