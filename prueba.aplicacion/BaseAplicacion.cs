using prueba.dominio;
using prueba.dominio.aplicacion;
using prueba.dominio.repositorio;
using prueba.dominio.servicio;
using System.Collections.Generic;

namespace prueba.aplicacion
{
    public class BaseAplicacion<TEntidad> : IBaseAplicacion<TEntidad> where TEntidad : class
    {
        private IUnitOfWork _unitOfWork;
        private readonly IBaseRepositorio<TEntidad> _baseRepositorio;
        private readonly IBaseServicio<TEntidad> _baseServicio;

        public BaseAplicacion(IBaseServicio<TEntidad> baseServicio,
            IBaseRepositorio<TEntidad> baseRepositorio,
            IUnitOfWork unitOfWork)
        {
            _baseServicio = baseServicio;
            _baseRepositorio = baseRepositorio;
            _unitOfWork = unitOfWork;
        }

        public virtual void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Add(TEntidad obj)
        {
            _baseRepositorio.Add(obj);
        }

        public void Delete(TEntidad obj)
        {
            _baseRepositorio.Delete(obj);
        }

        public void Delete(int id)
        {
            _baseRepositorio.Delete(id);
        }

        public TEntidad Get(int id)
        {
            return _baseRepositorio.Get(id);
        }

        public List<TEntidad> GetAll()
        {
            return _baseRepositorio.GetAll();
        }

        public void Update(TEntidad obj)
        {
            _baseRepositorio.Update(obj);
        }
    }
}
