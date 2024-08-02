using prueba.dominio.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.repositorio
{
    public class BaseRepositorio<TEntidad> : IBaseRepositorio<TEntidad> where TEntidad : class
    {
        protected readonly PruebaDbContext _pruebaDbContext;

        public BaseRepositorio(PruebaDbContext pruebaDbContext)
        {
            _pruebaDbContext = pruebaDbContext;
        }

        public void Add(TEntidad obj)
        {
            _pruebaDbContext.Set<TEntidad>().Add(obj);
        }

        public void Delete(TEntidad obj)
        {
            _pruebaDbContext.Set<TEntidad>().Remove(obj);
        }

        public void Delete(int id)
        {
            TEntidad obj = Get(id);
            Delete(obj);
        }

        public TEntidad Get(int id)
        {
            return _pruebaDbContext.Set<TEntidad>().Find(id);
        }

        public List<TEntidad> GetAll()
        {
            return _pruebaDbContext.Set<TEntidad>().ToList();
        }

        public void Update(TEntidad obj)
        {
            _pruebaDbContext.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
