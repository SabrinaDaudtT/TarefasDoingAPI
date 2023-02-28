using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TarefasDoingAPI.Models;

namespace TarefasDoingAPI.Database
{
    public class TarefasDoingContext : IdentityDbContext<ApplicationUser>
    {
        public TarefasDoingContext(DbContextOptions<TarefasDoingContext> options) : base(options)
        {

        }

        public DbSet<Tarefas> Tarefas { get; set; }
    }
}
