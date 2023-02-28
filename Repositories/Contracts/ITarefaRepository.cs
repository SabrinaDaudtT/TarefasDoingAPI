using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasDoingAPI.Models;

namespace TarefasDoingAPI.Repositories.Contracts
{
    public interface ITarefaRepository
    {
        void Sicronizacao(List<Tarefas> tafefas);

        void Restauracao(ApplicationUser usuario ,DateTime dataUltimaSicronizacao);
    }
}
