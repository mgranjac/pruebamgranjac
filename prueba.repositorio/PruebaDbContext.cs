using prueba.dominio.entidades;
using System.Data.Entity;

namespace prueba.repositorio
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext()
            : base("Prueba")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Tarea> Tarea { get; set; }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
