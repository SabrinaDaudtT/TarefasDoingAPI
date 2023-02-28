using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasDoingAPI.Database;
using TarefasDoingAPI.Models;
using TarefasDoingAPI.Repositories.Contracts;

namespace TarefasDoingAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefasDoingContext _banco;
        public TarefaRepository(TarefasDoingContext banco)
        {
            _banco = banco;      
        }

        public void Restauracao(ApplicationUser usuario, DateTime dataUltimaSicronizacao)
        {
            var query = _banco.Tarefas.Where(a => a.UsuarioId == usuario.Id).AsQueryable();

            if(dataUltimaSicronizacao != null)
            {
                query.Where(a => a.Criado >= dataUltimaSicronizacao || a.Atualizado >= dataUltimaSicronizacao);
            }

            query.ToList<Tarefas>();
        }

        public void Sicronizacao(List<Tarefas> tafefas)
        {
            //Cadastrar novos Registros

            //Atualização de Registros (Excluido)
            throw new NotImplementedException();
        }
    }
}
