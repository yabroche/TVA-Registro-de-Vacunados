using Microsoft.EntityFrameworkCore;
using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }

        


    }
}
