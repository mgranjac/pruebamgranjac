using System.Collections.Generic;

namespace prueba.dominio.repositorio
{
    public interface IBaseRepositorio<TEntidad> where TEntidad : class
    {
        void Add(TEntidad obj);
        void Delete(TEntidad obj);
        void Delete(int id);
        TEntidad Get(int id);
        List<TEntidad> GetAll();
        void Update(TEntidad obj);
    }
}
