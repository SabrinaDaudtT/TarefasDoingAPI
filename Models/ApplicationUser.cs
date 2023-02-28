using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasDoingAPI.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string FullName { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual ICollection<Tarefas> Tarefas { get; set; }
    }
}
