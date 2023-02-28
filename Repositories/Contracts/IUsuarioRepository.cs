using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasDoingAPI.Models;

namespace TarefasDoingAPI.Repositories.Contracts
{
    public interface IUsuarioRepository 
    {
        void Cadastrar(ApplicationUser usuario, string senha);

        ApplicationUser Obter(string email, string senha);
    }
}
