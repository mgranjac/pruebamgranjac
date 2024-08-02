using prueba.dominio.entidades;
using prueba.dominio.repositorio;

namespace prueba.repositorio
{
    public class TareaRepositorio : BaseRepositorio<Tarea>, ITareaRepositorio
    {
        public TareaRepositorio(PruebaDbContext pruebaDbContext)
           :base(pruebaDbContext)
        {

        }
    }
}
