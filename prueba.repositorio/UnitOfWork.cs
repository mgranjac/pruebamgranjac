using prueba.dominio;

namespace prueba.repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private PruebaDbContext _pruebaDbContext;

        public UnitOfWork(PruebaDbContext pruebaDbContext)
        {
            _pruebaDbContext = pruebaDbContext;
        }

        public void Commit()
        {
            _pruebaDbContext.SaveChanges();
        }
    }
}
