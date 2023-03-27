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

        /*Tarefa IdTarefaAPI - App IdTarefa = TarefaLocal */
        public List<Tarefas> Sicronizacao(List<Tarefas> tarefas)
        {
            //Cadastrar novos Registros
            var tarefasNovas = tarefas.Where(a => a.IdTarefaAPI == 0);
            if(tarefasNovas.Count() > 0)
            {
                foreach (var tarefa in tarefasNovas)
                {
                    _banco.Tarefas.Add(tarefa);
                }
            }

            //Atualização de Registros (Excluido)
            var tarefasExcluidasAtualizadas = tarefas.Where(a => a.IdTarefaAPI != 0);
            if (tarefasExcluidasAtualizadas.Count() > 0)
            {
                foreach (var tarefa in tarefasExcluidasAtualizadas)
                {
                    _banco.Tarefas.Update(tarefa);
                }
            }

            _banco.SaveChanges();

            return tarefasNovas.ToList();

        }

        public List<Tarefas> Restauracao(ApplicationUser usuario, DateTime dataUltimaSicronizacao)
        {
            var query = _banco.Tarefas.Where(a => a.UsuarioId == usuario.Id).AsQueryable();

            if (dataUltimaSicronizacao != null)
            {
                query.Where(a => a.Criado >= dataUltimaSicronizacao || a.Atualizado >= dataUltimaSicronizacao);
            }

            return query.ToList<Tarefas>();
        }
    }
}
