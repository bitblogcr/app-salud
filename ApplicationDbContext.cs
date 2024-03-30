using Microsoft.EntityFrameworkCore;
using Salud.Models;

namespace Salud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PersonasEntity> Personas { get; set; }
        public DbSet<ActividadEntity> Actividad { get; set; } 

        public DbSet<DietaEntity> Dieta { get; set; } 

        public DbSet<MetaSalud> metaSalud { get; set; } 
    }
}
